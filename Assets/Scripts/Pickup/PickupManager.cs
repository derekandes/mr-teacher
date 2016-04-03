using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PickupManager : MonoBehaviour
{
    //singleton
    public static PickupManager instance { get; private set; }
    public List<Pickup> pickups;

    void Awake ()
    {
        //singleton instance
        instance = this;
    }

	void Start ()
    {
        pickups = new List<Pickup>();

        pickups.Add(new Pickup(0, "Apple", "Sprites/Objects/apple", .15f, .15f, "Sprites/Objects/apple_head", .45f, .45f, .04f, 1.75f, -2f));
        pickups.Add(new Pickup(1, "Mushroom", "Sprites/Objects/mushroom", .15f, .15f, "Sprites/Objects/mushroom_head", .5f, .5f, .04f, 1.69f, -2f));
        pickups.Add(new Pickup(2, "Hedgehog", "Sprites/Objects/hedgehog", .2f, .2f, "Sprites/Objects/hedgehog", .5f, .5f, .49f, -0.06f, -4f));
    }

    void OnDestroy()
    {
        //clean up
        if (instance != null)
        {
            instance = null;
        }
    }
}
