using UnityEngine;
using System.Collections;

public class PickupLand : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform player;
    private KidMovement movement = null;

    private bool check = false;
    private float checkDelay = .5f;

    void Awake ()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        movement = GetComponent<KidMovement>();
    }

    void Start ()
    {
        StartCoroutine(Delay());
    }

	void FixedUpdate ()
    {
	    if (check && transform.position.y < (player.position.y + 1))
        {
            rb.isKinematic = true;
            if (movement != null)
            {
                movement.enabled = true;
            }
        }
	}

    IEnumerator Delay ()
    {
        yield return new WaitForSeconds(checkDelay);
        check = true;
    }
}
