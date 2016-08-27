using UnityEngine;
using System.Collections;

public class FaceSwap : MonoBehaviour
{
    public Sprite idleFace;
    public Sprite movingFace;
    private SpriteRenderer face;

    private WalkAnimation walkAnim;
    private KidListener kidListener;

	void Awake ()
    {
        walkAnim = GetComponentInParent<WalkAnimation>();
        kidListener = GetComponentInParent<KidListener>();
        face = GetComponent<SpriteRenderer>();
        face.sprite = idleFace;
	}

	void Update ()
    {
        if (walkAnim.isWalking)
        {
            face.sprite = movingFace;
        }
        else if (kidListener != null && kidListener.doingFeedback)
        {
            face.sprite = movingFace;
        }
        else
        {
            face.sprite = idleFace;
        }
	}
}
