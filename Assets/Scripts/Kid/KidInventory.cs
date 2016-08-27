using UnityEngine;
using System.Collections;

public class KidInventory : MonoBehaviour
{
    public int wearableId; //-1 if not wearing anything;
    private Transform wearable;
    private SpriteRenderer wearableSprite;
    public Transform particle;
    private ParticleSystem ps = null;

    public int inventory = 0;

    private Pickup thisPickup = null; //for grabbing pickup info

	void Awake ()
	{
        wearableId = -1;
        wearable = transform.Find("Character/Wearable");
        wearableSprite = wearable.GetComponent<SpriteRenderer>();

        if (particle != null)
        {
            ps = particle.GetComponent<ParticleSystem>();
        }
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
            Add(thisPickup.id, 1); // add 1 to inventory

            wearableSprite.sprite = Resources.Load<Sprite>(thisPickup.wornSprite);
            wearable.localPosition = new Vector3(thisPickup.wornXPos, thisPickup.wornYPos, thisPickup.wornZPos);
            wearable.localScale = new Vector3(thisPickup.wornXScale, thisPickup.wornYScale, 1f);
        }
    }

    //add to inventory amount
    public void Add(int id, int amount)
    {
        if (ps != null)
        {
            ps.Play();
        }

        inventory += amount;
        if (id == 0) GameManager.instance.apples += 1;
        if (id == 1) GameManager.instance.mushrooms += 1;
        if (id == 2) GameManager.instance.hedgehogs += 1;
    }
}
