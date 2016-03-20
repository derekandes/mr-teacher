using UnityEngine;
using System.Collections;

public class SpriteSorter : MonoBehaviour
{
    private SpriteRenderer sprite;
    private Transform parent;

	void Start ()
	{
        sprite = GetComponent<SpriteRenderer>();
        parent = transform.root;
	}

	void LateUpdate ()
	{
        sprite.sortingOrder = (int)Camera.main.WorldToScreenPoint(parent.position).y * -1;
    }
}