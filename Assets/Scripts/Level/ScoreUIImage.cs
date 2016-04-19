using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreUIImage : MonoBehaviour
{
    private Image image;

    void Awake ()
    {
        image = GetComponent<Image>();
    }

	void Update ()
    {
	    if (GameManager.instance.levelEnded)
        {
            image.enabled = true;
        }
        else
        {
            image.enabled = false;
        }
	}
}
