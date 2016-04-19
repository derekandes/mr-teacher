using UnityEngine;
using System.Collections;
using Prime31.ZestKit;

public class DestroyOutOfBounds : MonoBehaviour
{
	void Update ()
    {
	    if (transform.localPosition.x < GameManager.instance.leftBound)
        {
            ZestKit.instance.stopAllTweensWithTarget(gameObject.transform);
            Destroy(gameObject);
        }
        if (transform.localPosition.x > GameManager.instance.rightBound)
        {
            ZestKit.instance.stopAllTweensWithTarget(gameObject.transform);
            Destroy(gameObject);
        }
    }
}
