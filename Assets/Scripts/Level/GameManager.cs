using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Prime31.ZestKit;

public class GameManager : MonoBehaviour
{
    //SINGLETON
    public static GameManager instance { get; private set; }

    //GAME BOUNDS
    public float upBound = 0.9f;
    public float downBound = -4.98f;
    public float leftBound = -10.5f;
    public float rightBound = 10.7f;

    public bool levelEnded = false;

    //SCORE
    public int timeLeft;
    public int apples = 0;
    public int mushrooms = 0;
    public int hedgehogs = 0;
    public int totalScore;

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

    void Update ()
    {
        if (Input.GetKey("escape"))
            Application.Quit();

        CalculateScore();

        if (levelEnded)
        {
            if (Input.GetButtonDown("Y"))
            {
                ZestKit.removeAllTweensOnLevelLoad = true;
                SceneManager.LoadScene(0);
            }
        }
    }

    void CalculateScore ()
    {
        int total = 0;
        total += apples * 1;
        total += mushrooms * 3;
        total += hedgehogs * 5;
        totalScore = total;
    }

    public void LevelEnd()
    {
        levelEnded = true;
    }

    public bool OutOfBounds(Vector3 pos)
    {
        if (pos.x < leftBound) return true;
        else if (pos.x > rightBound) return true;
        else if (pos.y > upBound) return true;
        else if (pos.y < downBound) return true;
        else return false;
    }
}
