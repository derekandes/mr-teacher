using UnityEngine;
using System.Collections;

public class PickupLand : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform player;
    private KidMovement movement = null;

    private bool doCheck = false;
    private float checkDelay = .25f;
    public bool onGround = true;

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

        //if pickup moves, enable movement
        if (onGround && movement != null)
        {
            movement.enabled = true;
        }

        // if in bounds, land near player's feet
        if (doCheck && transform.position.y < (player.position.y + 1))
        {
            rb.isKinematic = true;
            rb.simulated = false;
            onGround = true;

            //stop checking if should land
            doCheck = false;
        }
	}

    IEnumerator Delay ()
    {
        yield return new WaitForSeconds(checkDelay);
        if (!onGround)
        {
            // if not on ground, check if should land
            doCheck = true;
        }
    }
}
