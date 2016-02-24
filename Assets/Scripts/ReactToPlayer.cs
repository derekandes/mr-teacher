using UnityEngine;
using System.Collections;

public class ReactToPlayer : MonoBehaviour
{
    //FOR PLAYER CHECK
    private Transform player;
    private float playerDistance;
    public float listenDistance = 2.5f;
    public bool listen = false;

    //OBJECT MANAGER
    private ObjectManager objectManager;

    void Awake ()
    {
        //GET PLAYER REFERENCE
        player = GameObject.FindGameObjectWithTag("Player").transform;

        //GET OBJECT MANAGER
        objectManager = gameObject.GetComponent<ObjectManager>();
    }

	void Update ()
	{
        //IF PLAYER CLOSE, LISTEN
        playerDistance = Vector3.Distance(player.position, transform.position);

        if (playerDistance < listenDistance)
            listen = true;
        else
            listen = false;
	}

    //INVOKED BY PLAYER
    public void React()
    {
        if (Input.GetButtonDown("A"))
        {
            //CHECK IF HOLDING AN OBJECT
            if (objectManager.HoldingObject())
            {
                //IF SO, GIVE IT TO THE PLAYER
                Debug.Log("I'm holding something!");
                objectManager.GiveObjectToPlayer();
            }
            else
            {
                //ELSE, CHECK IF PLAYER HAS AN OBJECT
                Debug.Log("I'm not holding anything!");
                objectManager.TakeObjectFromPlayer();
            }
        }

        //UNUSED INPUTS
        else if (Input.GetButtonDown("X"))
        {
            Debug.Log("You pressed X");
        }
        else if (Input.GetButtonDown("B"))
        {
            Debug.Log("You pressed B");
        }
        else if (Input.GetButtonDown("Y"))
        {
            Debug.Log("You pressed Y");
        }
        else
        {
            Debug.Log("What?!");
        }
    }
}