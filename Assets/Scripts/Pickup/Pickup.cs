using UnityEngine;
using System.Collections;

public class Pickup
{
    public int id;
    public string name;
    public string sprite;
    public float xScale;
    public float yScale;

    public Pickup(int newId, string newName, string newSprite, float newXScale, float newYScale)
    {
        id = newId;
        name = newName;
        sprite = newSprite;
        xScale = newXScale;
        yScale = newYScale;
    }
}
