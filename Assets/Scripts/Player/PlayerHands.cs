using UnityEngine;
using System.Collections;
using Prime31.ZestKit;

public class PlayerHands : MonoBehaviour
{
    private PlayerInventory playerInventory;
    private Vector3 startPos;

    public float amplitude = 1.5f;
    public float period = 0.17f;
    private float walkTime = 0f;
    private bool isWalking = false;
    private bool handsUp = false;

	void Start ()
    {
        playerInventory = GetComponentInParent<PlayerInventory>();
        startPos = transform.localPosition;
	}
	
	void Update ()
    {
        if (Input.GetButton("B"))
        {
            handsUp = true;
            transform.localPosition = startPos + Vector3.up * 1.5f;
            return;
        }

        // calculate values for walking animation
        float theta = walkTime / period;
        float distance = Mathf.Abs(amplitude * Mathf.Sin(theta));

        // if walking and not holding object, do animation
        if (Walking())
        {
            isWalking = true;
            walkTime += Time.deltaTime;
            transform.localPosition = startPos + Vector3.up * distance;
        }
        else
        {
            walkTime = 0f;
            if (isWalking || handsUp) // else if was walking or have hands up reset position
                ResetPosition();
        }
	}

    private bool Walking()
    {
        // false if level ended
        if (GameManager.instance.levelEnded) return false;

        // false if holding object
        if (playerInventory.slotId[0] != -1) return false;

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // true if walking
        return (h + v != 0);
    }

    private void ResetPosition()
    {
        isWalking = false;
        handsUp = false;

        transform.ZKlocalPositionTo(startPos, .1f)
            .setEaseType(EaseType.SineInOut)
            .start();
    }
}
