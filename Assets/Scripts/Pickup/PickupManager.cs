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

        pickups.Add(new Pickup(0, "Apple", "Sprites/Objects/apple", .15f, .15f, "Sprites/Objects/apple_head", .7f, .7f, .04f, 2.42f, -2f));
        pickups.Add(new Pickup(1, "Mushroom", "Sprites/Objects/mushroom", .15f, .15f, "Sprites/Objects/mushroom_head", .75f, .75f, .08f, 2.32f, -2f));
        pickups.Add(new Pickup(2, "Hedgehog", "Sprites/Objects/hedgehog", .2f, .2f, "Sprites/Objects/hedgehog", .7f, .7f, .64f, -0.15f, -4f));
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
