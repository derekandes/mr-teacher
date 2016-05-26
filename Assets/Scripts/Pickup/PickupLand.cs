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
        // if out of bounds, don't land
        if (GameManager.instance.OutOfBounds(transform.position)) return;

        // if in bounds, land near player's feet
	    if (check && transform.position.y < (player.position.y + 1))
        {
            //land
            rb.isKinematic = true;

            //if pickup moves, enable movement
            if (movement != null)
            {
                movement.enabled = true;
            }

            //stop checking
            check = false;
        }
	}

    IEnumerator Delay ()
    {
        yield return new WaitForSeconds(checkDelay);
        check = true;
    }
}
