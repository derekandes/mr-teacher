using UnityEngine;
using System.Collections;

public class PlayerInteractions : MonoBehaviour
{
    private GameObject[] interactables;
    public Transform closestInteractable;

    private KidListener kidListener = null;
    private PickupListener pickupListener = null;

	void Awake ()
	{
        interactables = GameObject.FindGameObjectsWithTag("Interactable");
    }

	void Update ()
	{
        if (GameManager.instance.levelEnded) return;

        interactables = GameObject.FindGameObjectsWithTag("Interactable");
        closestInteractable = GetClosestInteractable(interactables);

        kidListener = closestInteractable.gameObject.GetComponent<KidListener>();
        pickupListener = closestInteractable.gameObject.GetComponent<PickupListener>();

        if (kidListener != null)
        {
            if (Input.GetButtonDown("A") && kidListener.listen)
                kidListener.Interact();
        }

        if (pickupListener != null)
        {
            if (Input.GetButtonDown("A") && pickupListener.listen)
                pickupListener.Interact();
        }
    }

    Transform GetClosestInteractable(GameObject[] interactables)
    {
        Transform closestInteractable = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (GameObject interactable in interactables)
        {
            Vector3 distToInteractable = interactable.transform.position - currentPos;
            float distSqrToInteractable = distToInteractable.sqrMagnitude;
            if (distSqrToInteractable < closestDistanceSqr)
            {
                closestDistanceSqr = distSqrToInteractable;
                closestInteractable = interactable.transform;
            }
        }
        return closestInteractable;
    }
}
