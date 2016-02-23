using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    //SINGLETON
    public static GameManager instance { get; private set; }

    //GAME BOUNDS
    public float upBound = 0.9f;
    public float downBound = -4.98f;
    public float leftBound = -10.5f;
    public float rightBound = 10.7f;

    void Awake()
    {
        //SINGLETON INSTANCE
        instance = this;
    }

    void OnDestroy()
    {
        //CLEAN UP
        if (instance != null)
        {
            instance = null;
        }
    }
}
