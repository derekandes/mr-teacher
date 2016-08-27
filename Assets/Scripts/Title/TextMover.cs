using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Prime31.ZestKit;

public class TextMover : MonoBehaviour
{
    public int activeSequence = 2;
    private TitleSequence titleSequence;

	void Start ()
    {
        titleSequence = Camera.main.GetComponent<TitleSequence>();
        TitleSequence.OnTextMove += MoveTextLeft;
	}

    void OnDestroy ()
    {
        TitleSequence.OnTextMove -= MoveTextLeft;
    }

    void MoveTextLeft()
    {
        if (titleSequence.sequence != activeSequence)
            return;

        Vector3 offset = new Vector3(-20f, 0f, 0f);
        Vector3 newPosition = transform.position + offset;

        transform.ZKpositionTo(newPosition, 1.25f)
            .setEaseType(EaseType.ElasticOut)
            .start();
    }
}
