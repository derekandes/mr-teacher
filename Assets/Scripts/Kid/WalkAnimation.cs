using UnityEngine;
using System.Collections;
using Prime31.ZestKit;

public class WalkAnimation : MonoBehaviour
{
    private Vector3 startPos;

    public bool noRotation = false;

	public float amplitude = 2f;
	public float period = .2f;

	public bool walking = false;
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
		if (walking)
		{
			walkTime += Time.deltaTime;
		}
		else
		{
			walkTime = 0f;
		}

		float theta = walkTime / period;
		float distance = Mathf.Abs(amplitude * Mathf.Sin(theta));

		if (CheckWalking())
		{
			walking = true;

			transform.localPosition = startPos + Vector3.up * distance;

            if (!noRotation)
            {
                transform.localRotation = Quaternion.Euler(0, 0, amplitude * 10 * Mathf.Cos(theta));
            }
		}
		else
		{
			if (transform.localPosition != startPos && walking)
			{
                Reset();
            }
		}
	}

    private bool CheckWalking()
    {
        if (!kid)
        {
            if (GameManager.instance.levelEnded) return false;

            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            if (h != 0 || v != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            if (kidMovement != null)
            {
                if (kidMovement.anim)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
            
        return true;
    }
    public void Reset()
    {
        walking = false;

        transform.ZKlocalRotationTo(Quaternion.identity, .1f)
            .setEaseType(EaseType.SineInOut)
            .start();
        transform.ZKlocalPositionTo(startPos, .1f)
            .setEaseType(EaseType.SineInOut)
            .start();
    }
}
