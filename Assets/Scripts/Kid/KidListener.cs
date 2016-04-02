using UnityEngine;
using System.Collections;

public class KidListener : MonoBehaviour
{
    private Transform player;
    public float playerDistance;
    public float listenDistance = 2.5f;
    public bool listen = false;

	void Awake ()
	{
        player = GameObject.FindGameObjectWithTag("Player").transform;
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
        Debug.Log("Kid reacted!");
    }
}
