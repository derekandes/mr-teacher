using UnityEngine;
using System.Collections;
using Prime31.ZestKit;

public class DestroyOutOfBounds : MonoBehaviour
{
	void Update ()
    {
        //destroy if fallen below play area
	    if (transform.localPosition.y < GameManager.instance.downBound - 5f)
        {
            ZestKit.instance.stopAllTweensWithTarget(gameObject.transform);
            Destroy(gameObject);
        }
    }
}
