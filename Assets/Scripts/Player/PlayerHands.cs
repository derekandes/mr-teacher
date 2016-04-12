using UnityEngine;
using System.Collections;

public class PlayerHands : MonoBehaviour
{
    private WalkAnimation handAnim;
    private PlayerInventory playerInventory;

	void Start ()
    {
        playerInventory = GetComponentInParent<PlayerInventory>();
        handAnim = GetComponent<WalkAnimation>();
	}
	
	void Update ()
    {
	    if (playerInventory.slotId[0] == -1)
        {
            handAnim.enabled = true;
        }
        else
        {
            handAnim.Reset();
            handAnim.enabled = false;
        }
	}
}
