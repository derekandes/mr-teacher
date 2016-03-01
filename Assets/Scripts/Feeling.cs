using UnityEngine;
using System.Collections;

public class Feeling : MonoBehaviour
{
    private ObjectManager objectManager;
    private SpriteRenderer body;

    public bool happy = false;
    public bool likeRain = false;

    void Start()
    {
        objectManager = gameObject.GetComponent<ObjectManager>();
        body = gameObject.GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        if (objectManager.HoldingObject())
        {
            happy = !likeRain;
            
        }
        else
        {
            happy = likeRain;
            
        }

        //Set body to green for happy, pink for unhappy
        body.color = happy ? new Color32(110, 231, 196, 255) : new Color32(231, 110, 143, 255);
    }
}
