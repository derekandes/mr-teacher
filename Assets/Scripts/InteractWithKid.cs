using UnityEngine;
using System.Collections;

public class InteractWithKid : MonoBehaviour
{ 
    //FOR KID CHECK (NOTE: STAND ALONE OBJECTS USE THE KID TAG AND CAN ALSO BE INTERACTED WITH)
    private GameObject[] kids;
    public Transform closestKid;
    private ReactToPlayer listener = null;

    //FOR INTERACTING WITH PLAYER OBJECTS
    private ObjectManager playerObjectManager;

    void Awake()
    {
        //GET ARRAY OF KIDS
        kids = GameObject.FindGameObjectsWithTag("Kid");

        //GET PLAYER OBJECT MANAGER
        playerObjectManager = gameObject.GetComponent<ObjectManager>();
    }
     
	void Update ()
	{
        //GET CLOSEST KID AND CHECK IF LISTENING
        kids = GameObject.FindGameObjectsWithTag("Kid");    // UPDATES EVERY FRAME BECAUSE OBJECTS BEHAVE LIKE KIDS (USE KID TAG) BUT ARE DESTROYED WHEN PICKED UP.
        closestKid = GetClosestKid(kids);
        listener = closestKid.gameObject.GetComponent<ReactToPlayer>();

        //IF KID LISTENING, INTERACT WHEN ANY BUTTON IS PRESSED
        if (listener != null)
        {
            if (Input.GetButtonDown("A") || Input.GetButtonDown("X") || Input.GetButtonDown("B") || Input.GetButtonDown("Y"))
            {
                if (listener.listen)
                {
                    listener.React();
                }
                else
                {
                    Debug.Log("Nope.");
                }
            }
        }

        //IF B IS PRESSED, TRY TO DROP OBJECT
        if (Input.GetButtonDown("B"))
        {
            playerObjectManager.PlayerDropObject();
        }
	}

    Transform GetClosestKid(GameObject[] kids)
    {
        //RETURN TRANSFORM OF CLOSEST KID
        Transform closestKid = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (GameObject kid in kids)
        {
            Vector3 distToKid = kid.transform.position - currentPos;
            float distSqrToKid = distToKid.sqrMagnitude;
            if (distSqrToKid < closestDistanceSqr)
            {
                closestDistanceSqr = distSqrToKid;
                closestKid = kid.transform;
            }
        }
        return closestKid;
    }
}