using UnityEngine;
using System.Collections;

public class FaceSwap : MonoBehaviour
{
    public Sprite idleFace;
    public Sprite movingFace;
    private SpriteRenderer face;

    private WalkAnimation walkAnim;

	void Start ()
    {
        walkAnim = GetComponentInParent<WalkAnimation>();
        face = GetComponent<SpriteRenderer>();
        face.sprite = idleFace;
	}

	void Update ()
    {
        if (walkAnim.isWalking)
        {
            face.sprite = movingFace;
        }
        else
        {
            face.sprite = idleFace;
        }
	}
}
