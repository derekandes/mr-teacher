using UnityEngine;
using System.Collections;

public class ObjectManager : MonoBehaviour
{
    //FOR PLAYER TO CHECK
    public bool hasObject = false;

    //FOR STANDALONE OBJECTS
    public bool isObject = false;

    //PLAYER REFERENCES
    private Transform player;
    private ObjectManager playerObjects;

    //OBJECTS HELD
    public bool umbrella = false;
    public bool raincoat = false;

    //OBJECT SPRITES
    private SpriteRenderer umbrellaSprite;
    private SpriteRenderer raincoatSprite;

    void Awake ()
    {
        //GET PLAYER REFERENCES
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerObjects = player.GetComponent<ObjectManager>();

        //GET OBJECT SPRITES
        umbrellaSprite = transform.Find("Objects/Umbrella").gameObject.GetComponent<SpriteRenderer>();
        raincoatSprite = transform.Find("Objects/Raincoat").gameObject.GetComponent<SpriteRenderer>();
    }

	void Update ()
	{
        //SET OBJECT VISABILITY
        umbrellaSprite.enabled = umbrella;
        raincoatSprite.enabled = raincoat;

        //SET IF HOLDING AN OBJECT
        hasObject = umbrella || raincoat;
	}

    //INVOKED BY KID
    public void GiveObjectToPlayer()
    {
        //IF HOLDING AN OBJECT PLAYER IS NOT, GIVE IT TO PLAYER
        if (umbrella)
        {
            if (!playerObjects.umbrella)
            {
                playerObjects.umbrella = umbrella;
                umbrella = !umbrella;
                Debug.Log("I'm giving it to the player!");

                //IF OBJECT (NOT KID), DESTROY
                if (isObject) Destroy(gameObject); else return;
            }
            //ELSE, PLAYER ALREADY HAS HELD OBJECTS
            else Debug.Log("You already have it!");
        }

        if (raincoat)
        {
            if (!playerObjects.raincoat)
            {
                playerObjects.raincoat = raincoat;
                raincoat = !raincoat;
                Debug.Log("I'm giving it to the player!");

                //IF OBJECT (NOT KID), DESTROY
                if (isObject) Destroy(gameObject); else return;
            }
            //ELSE, PLAYER ALREADY HAS HELD OBJECTS
            else Debug.Log("You already have it!");
        }
    }

    //INVOKED BY KID
    public void TakeObjectFromPlayer()
    {
        //TAKE AN OBJECT IF PLAYER IS HOLDING IT
        if (playerObjects.umbrella)
        {
            umbrella = playerObjects.umbrella;
            playerObjects.umbrella = !playerObjects.umbrella;
            Debug.Log("I'm taking this object!");
        }
        else if (playerObjects.raincoat)
        {
            raincoat = playerObjects.raincoat;
            playerObjects.raincoat = !playerObjects.raincoat;
            Debug.Log("I'm taking this object!");
        }
        else Debug.Log("You don't have anything to give me!");
    }

    //INVOKED BY PLAYER
    public void PlayerDropObject()
    {
        //IF HOLDING UMBRELLA, DROP IT AND RETURN
        if (playerObjects.umbrella)
        {
            //DROP UMBRELLA
            GameObject instance = Instantiate(Resources.Load("Object"), transform.localPosition, Quaternion.identity) as GameObject;
            ObjectManager instanceObject = instance.GetComponent<ObjectManager>();
            instanceObject.umbrella = playerObjects.umbrella;
            playerObjects.umbrella = !playerObjects.umbrella;
            Debug.Log("Dropped umbrella!");
            return;
        }

        //IF HOLDING UMBRELLA, DROP IT AND RETURN
        if (playerObjects.raincoat)
        {
            //DROP RAINCOAT
            GameObject instance = Instantiate(Resources.Load("Object"), transform.localPosition, Quaternion.identity) as GameObject;
            ObjectManager instanceObject = instance.GetComponent<ObjectManager>();
            instanceObject.raincoat = playerObjects.raincoat;
            playerObjects.raincoat = !playerObjects.raincoat;
            Debug.Log("Dropped raincoat!");
            return;
        }
    }
}