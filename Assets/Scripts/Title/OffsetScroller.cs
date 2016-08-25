using UnityEngine;
using System.Collections;

public class OffsetScroller : MonoBehaviour
{
	public float scrollSpeed = 1f;
	private Vector2 savedOffset;

	void Start ()
	{
		savedOffset = GetComponent<Renderer>().sharedMaterial.GetTextureOffset ("_MainTex");
	}

	void Update ()
	{
        float x = Mathf.Repeat(Time.time * scrollSpeed, 1);
        float y = Mathf.Repeat(Time.time * scrollSpeed, 1);
        Vector2 offset = new Vector2 (x, y);
		GetComponent<Renderer>().sharedMaterial.SetTextureOffset ("_MainTex", offset);
	}

    void OnDisable ()
    {
        GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", savedOffset);
    }
}
