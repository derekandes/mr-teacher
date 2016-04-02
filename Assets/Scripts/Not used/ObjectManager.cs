using UnityEngine;
using System.Collections;

public class ObjectManager : MonoBehaviour
{
    //FOR STANDALONE OBJECTS
    public bool isObject = false;

    //PLAYER REFERENCES
    private Transform player;
    private ObjectManager playerObjectManager;

    //OBJECTS HELD
    public Transform objects; //PARENT TRANSFORM OF OBJECT SPRITES
    //public string[] objectNames = { "umbrella", "raincoat", "headphones" }; //THIS SHOULD DICTATE THE ORDER OF OBJECTS HELD BY PLAYER/KIDS
    public bool[] objectsHeld = { false, false, false }; //USED TO TOGGLE VISIBILITY OF OBJECTS

    void Awake ()
    {
        //GET PLAYER REFERENCES
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerObjectManager = player.GetComponent<ObjectManager>();

        //GET OBJECTS REFERENCE
        objects = transform.Find("Objects");
    }

	void Update ()
	{
        //SET OBJECT VISABILITY
        SetObjectVisibility();
	}

    private void SetObjectVisibility()
    {
        //SET SPRITE VISIBILITY FOR EACH OBJECT HELD
        SpriteRenderer objectSprite;

        for (int i = 0; i < objectsHeld.Length; i++)
        {
            objectSprite = objects.GetChild(i).gameObject.GetComponent<SpriteRenderer>();
            objectSprite.enabled = objectsHeld[i];
        }
    }

    public bool HoldingObject()
    {
        //RETURN TRUE IF HOLDING AN OBJECT
        foreach (bool b in objectsHeld)
        {
            if (b) return true;
        }
        return false;
    }

    //INVOKED BY KID
    public void GiveObjectToPlayer()
    {
        for (int i = 0; i < objectsHeld.Length; i++)
        {
            //IF HOLDING AN OBJECT PLAYER IS NOT, GIVE IT TO PLAYER
            if (objectsHeld[i])
            {
                if (!playerObjectManager.objectsHeld[i])
                {
                    playerObjectManager.objectsHeld[i] = objectsHeld[i];
                    objectsHeld[i] = !objectsHeld[i];
                    Debug.Log("I'm giving it to the player!");

                    //IF OBJECT (NOT KID), DESTROY
                    if (isObject) Destroy(gameObject); else return;
                }
                else Debug.Log("You already have it!");
            }
        }
    }

    //INVOKED BY KID
    public void TakeObjectFromPlayer()
    {
        //TAKE AN OBJECT IF PLAYER IS HOLDING IT
        for (int i = 0; i < playerObjectManager.objectsHeld.Length; i++)
        {
            if (playerObjectManager.objectsHeld[i])
            {
                objectsHeld[i] = playerObjectManager.objectsHeld[i];
                playerObjectManager.objectsHeld[i] = !playerObjectManager.objectsHeld[i];
                Debug.Log("I'm taking this object!");
                return;
            }
        }
        Debug.Log("You don't have anything to give me!");
    }

    //INVOKED BY PLAYER
    public void PlayerDropObject()
    {
        //IF HOLDING AN OBJECT, DROP IT AND RETURN
        for (int i = 0; i < playerObjectManager.objectsHeld.Length; i++)
        {
            if (playerObjectManager.objectsHeld[i])
            {
                GameObject instance = Instantiate(Resources.Load("Object"), transform.localPosition, Quaternion.identity) as GameObject;
                ObjectManager instanceObjectManager = instance.GetComponent<ObjectManager>();
                instanceObjectManager.objectsHeld[i] = playerObjectManager.objectsHeld[i];
                playerObjectManager.objectsHeld[i] = !playerObjectManager.objectsHeld[i];
                Debug.Log("Dropped object!");
                return;
            }
        }
    }
}
