using UnityEngine;
using System.Collections;
using Prime31.ZestKit;

public class WalkAnimation : MonoBehaviour
{
    private Vector3 startPos;

	public float amplitude = 2f;
	public float period = .2f;

    public bool noRotation = false;
    public bool isWalking = false;
    public bool alwaysOn = false;
    private float walkTime = 0f;

    public bool kid = false;
    private KidMovement kidMovement = null;

	void Start ()
	{
		startPos = transform.localPosition;

        if (kid) kidMovement = GetComponentInParent<KidMovement>();
	}
	
	void Update()
	{
		if (isWalking)
			walkTime += Time.deltaTime;
		else
			walkTime = 0f;

		float theta = walkTime / period;
		float distance = Mathf.Abs(amplitude * Mathf.Sin(theta));

		if (CheckWalking())
		{
			isWalking = true;

			transform.localPosition = startPos + Vector3.up * distance;

            if (!noRotation)
            {
                transform.localRotation = Quaternion.Euler(0, 0, amplitude * 10 * Mathf.Cos(theta));
            }
		}
		else
		{
			if (transform.localPosition != startPos && isWalking)
			{
                Reset();
            }
		}
	}

    private bool CheckWalking()
    {
        if (alwaysOn)
            return true;

        if (!kid)
        {
            if (GameManager.instance.levelEnded) return false;

            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            return (h != 0 || v != 0);
        }
        else
        {
            if (kidMovement != null)
            {
                return (kidMovement.anim);
            }
            else
                return false;
        }
    }

    public void Reset()
    {
        isWalking = false;

        transform.ZKlocalRotationTo(Quaternion.identity, .1f)
            .setEaseType(EaseType.SineInOut)
            .start();
        transform.ZKlocalPositionTo(startPos, .1f)
            .setEaseType(EaseType.SineInOut)
            .start();
    }
}
