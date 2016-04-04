using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public Transform trackingTarget;
    public float xOffset, yOffset;
    public float followSpeed;

	void Update ()
    {
        float xTarget = trackingTarget.position.x + xOffset;
        float yTarget = trackingTarget.position.y + yOffset;

        float xNew = Mathf.Lerp(transform.position.x, xTarget, Time.deltaTime * followSpeed);
        float yNew = Mathf.Lerp(transform.position.y, yTarget, Time.deltaTime * followSpeed);

        transform.position = new Vector3(xNew, yNew, transform.position.z);
	}
}
