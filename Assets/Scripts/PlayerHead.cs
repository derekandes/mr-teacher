using UnityEngine;
using System.Collections;
using Prime31.ZestKit;

public class PlayerHead : MonoBehaviour
{
    //KIDS
    public GameObject[] kids; // SENT FROM INTERACT WITH KID SCRIPT
    public int upsetKids = 0;

    //HEAD COLOR
    private Color noTint, lightRed, mediumRed, darkRed, purpleRed;
    private SpriteRenderer headColor;
    private int headColorStep = 1;

    //HEAD SCALE
    private Vector3 noScale, big, bigger, monster;
    private int headScaleStep = 1;

	void Start ()
	{
        //SET COLORS
        noTint = new Color32(255, 255, 255, 255);
        lightRed = new Color32(255, 169, 169, 255);
        mediumRed = new Color32(255, 92, 92, 255);
        darkRed = new Color32(227, 0, 0, 255);
        purpleRed = new Color32(171, 0, 130, 255);
        headColor = GetComponent<SpriteRenderer>();

        //SET SCALES
        noScale = new Vector3(0.5f, 0.5f, 1f);
        big = new Vector3(1f, 0.95f, 1f);
        bigger = new Vector3(1.36f, 1.42f, 1f);
        monster = new Vector3(2.3f, 2.64f, 1f);
    }

	void Update ()
	{
        CountUpsetKids();

        if (Input.GetButtonDown("Y"))
        {
            HeadColorStep();
        }
	}

    void CountUpsetKids()
    {
        if (kids != null)
        {
            int count = 0;

            foreach (GameObject kid in kids)
            {
                Feeling feeling = kid.GetComponent<Feeling>();
                if (feeling != null)
                {
                    if (!feeling.happy)
                    {
                        count += 1;
                    }
                }
            }
            upsetKids = count;
        }
    }

    void HeadColorStep()
    {
        //TWEEN COLOR
        switch (headColorStep)
        {
            case 0:
                HeadScaleStep(); // SCALE HEAD ON RESET
                headColor.ZKcolorTo(noTint, .25f)
                    .setEaseType(EaseType.Linear)
                    .start();
                break;
            case 1:
                headColor.ZKcolorTo(lightRed, 1f)
                    .start();
                break;
            case 2:
                headColor.ZKcolorTo(mediumRed, 1f)
                    .start();
                break;
            case 3:
                headColor.ZKcolorTo(darkRed, 1f)
                    .start();
                break;
            case 4:
                headColor.ZKcolorTo(purpleRed, 1f)
                    .start();
                break;
            default:
                Debug.Log("Head color step error");
                break;
        }

        //HANDLE COLOR STEP
        if (headColorStep < 4)
            headColorStep++;
        else
            headColorStep = 0;
    }

    void HeadScaleStep()
    {
        //TWEEN SCALE
        switch (headScaleStep)
        {
            case 0:
                transform.ZKlocalScaleTo(noScale, 1f)
                    .setEaseType(EaseType.BounceOut)
                    .start();
                break;
            case 1:
                transform.ZKlocalScaleTo(big, 1f)
                    .setEaseType(EaseType.BounceOut)
                    .start();
                break;
            case 2:
                transform.ZKlocalScaleTo(bigger, 1f)
                    .setEaseType(EaseType.BounceOut)
                    .start();
                break;
            case 3:
                transform.ZKlocalScaleTo(monster, 1f)
                    .setEaseType(EaseType.BounceOut)
                    .start();
                break;
            default:
                Debug.Log("Head scale step error");
                break;
        }

        //HANDLE SCALE STEP
        if (headScaleStep < 3)
            headScaleStep++;
        else
            headScaleStep = 0;
    }
}