using UnityEngine;
using System.Collections;

public class Feeling : MonoBehaviour
{
    private ObjectManager objectManager;

    public bool happy = false;
    public bool likeRain = false;

    void Start()
    {
        objectManager = gameObject.GetComponent<ObjectManager>();
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

    }
}
