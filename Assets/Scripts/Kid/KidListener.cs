using UnityEngine;
using System.Collections;
using Prime31.ZestKit;

public class KidListener : MonoBehaviour
{
    private Transform player;
    public float playerDistance;
    public float listenDistance = 2.5f;
    public bool listen = false;

    private PlayerInventory playerInventory;
    private KidInventory kidInventory;
    private KidMovement kidMovement;

	void Awake ()
	{
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerInventory = player.GetComponent<PlayerInventory>();
        kidInventory = GetComponent<KidInventory>();
        kidMovement = GetComponent<KidMovement>();
    }

	void Update ()
	{
        playerDistance = Vector3.Distance(player.position, transform.position);

        if (playerDistance < listenDistance)
            listen = true;
        else
            listen = false;
    }

    public void Interact()
    {
        // if player holding an object in slot 0
        if (playerInventory.slotId[0] != -1)
        {
            //and kid isn't wearing anything
            if (kidInventory.wearableId == -1)
            {
                Feedback();
                //wear object from player slot 0
                kidInventory.Wear(playerInventory.slotId[0]);
                //and remove object from player inventory (move other objects down a slot)
                playerInventory.Give();
            }
            //else if kid is wearing something, check if same as object player has in slot 0
            else if (kidInventory.wearableId == playerInventory.slotId[0])
            {
                Feedback();
                //if so, add 1 to player inventory
                kidInventory.Add(kidInventory.wearableId, 1);

                //and remove object from player inventory (move other objects down a slot)
                playerInventory.Give();
            }
        }
    }

    //visual feedback for interaction
    void Feedback()
    {
        //stop any current tween (includes kid movement, which will be restarted on complete)
        ZestKit.instance.stopAllTweensWithTarget(gameObject.transform);

        //do scale "pop"
        Vector3 theScale = new Vector3(transform.localScale.x, 1f, transform.localScale.z);
        transform.localScale = new Vector3(theScale.x, .7f, theScale.z);
        transform.ZKlocalScaleTo(theScale, 1f)
            .setEaseType(EaseType.ElasticOut)
            .setCompletionHandler(t => kidMovement.DecideMovementDelay())
            .start();
    }
}
