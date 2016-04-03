using UnityEngine;
using System.Collections;

public class KidInventory : MonoBehaviour
{
    public int wearableId; //-1 if not wearing anything;
    private Transform wearable;
    private SpriteRenderer wearableSprite;

    public int inventory = 0;

    private Pickup thisPickup = null; //for grabbing pickup info

	void Awake ()
	{
        wearableId = -1;
        wearable = transform.Find("Wearable");
        wearableSprite = wearable.GetComponent<SpriteRenderer>();
    }

    //wear pickup with id
    public void Wear(int id)
    {
        //set item worn
        wearableId = id;

        //get pickup from id
        foreach (Pickup pickup in PickupManager.instance.pickups)
        {
            if (pickup.id == id)
            {
                thisPickup = pickup;
            }
        }
        //if pickup, set up wearable (add to inventory)
        if (thisPickup != null)
        {
            Add(1); // add 1 to inventory
            wearableSprite.sprite = Resources.Load<Sprite>(thisPickup.wornSprite);
            wearable.localPosition = new Vector3(thisPickup.wornXPos, thisPickup.wornYPos, thisPickup.wornZPos);
            wearable.localScale = new Vector3(thisPickup.wornXScale, thisPickup.wornYScale, 1f);
        }
    }

    //add to inventory amount
    public void Add(int amount)
    {
        inventory += amount;
    }
}
