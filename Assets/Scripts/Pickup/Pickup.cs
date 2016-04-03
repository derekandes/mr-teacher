using UnityEngine;
using System.Collections;

public class Pickup
{
    public int id;
    public string name;
    public string sprite;
    public float xScale;
    public float yScale;
    public string wornSprite;
    public float wornXScale;
    public float wornYScale;
    public float wornXPos;
    public float wornYPos;
    public float wornZPos;

    public Pickup(int newId, string newName, string newSprite, float newXScale, float newYScale,
        string newWornSprite, float newWornXScale, float newWornYScale, float newWornXPos, float newWornYPos, float newWornZPos)
    {
        id = newId;
        name = newName;
        sprite = newSprite;
        xScale = newXScale;
        yScale = newYScale;
        wornSprite = newWornSprite;
        wornXScale = newWornXScale;
        wornYScale = newWornYScale;
        wornXPos = newWornXPos;
        wornYPos = newWornYPos;
        wornZPos = newWornZPos;
    }
}
