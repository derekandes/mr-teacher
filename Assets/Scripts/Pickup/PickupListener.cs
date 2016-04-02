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
        playerInventory.Pickup(id);

        //need to check if being picked up before destorying
        ZestKit.instance.stopAllTweensWithTarget(gameObject.transform); //stop tween on this transform
        Destroy(gameObject);
    }
}
