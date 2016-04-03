using UnityEngine;
using System.Collections;
using Prime31.ZestKit;

public class PickupListener : MonoBehaviour
{
    public int id = 0;

    private Transform player;
    private PlayerInventory playerInventory;

    private float playerDistance;
    private float listenDistance = 2.5f;
    public bool listen = false;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerInventory = player.GetComponent<PlayerInventory>();
    }

    void Update()
    {
        playerDistance = Vector3.Distance(player.position, transform.position);

        if (playerDistance < listenDistance)
            listen = true;
        else
            listen = false;
    }

    public void Interact()
    {
        //if player inventory is full, return
        if (playerInventory.slotId[3] != -1) return;

        //else, have player pickup this id, stop tween on this transform, and destroy this object
        playerInventory.Pickup(id);
        ZestKit.instance.stopAllTweensWithTarget(gameObject.transform);
        Destroy(gameObject);
    }
}
