using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreUIText : MonoBehaviour
{
    public Text scoreText;
    private int score;
    public int id; // -1 = display only

	void Start ()
    {
	
	}
	
	void Update ()
    {
        if (GameManager.instance.levelEnded)
        {
            GetScore();
            SetString();
            scoreText.enabled = true;
        }
        else
        {
            scoreText.enabled = false;
        }
	}

    void SetString()
    {
        if (id == -1) return;

        if (id == 3)
        {
            scoreText.text = score.ToString() + " pts";
        }
        else
        {
            scoreText.text = "x " + score.ToString();
        }
    }

    void GetScore()
    {
        if (id == 0) score = GameManager.instance.apples;
        if (id == 1) score = GameManager.instance.mushrooms;
        if (id == 2) score = GameManager.instance.hedgehogs;
        if (id == 3) score = GameManager.instance.totalScore;
    }
}
