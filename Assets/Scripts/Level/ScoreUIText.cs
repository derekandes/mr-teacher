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
            scoreText.text = score.ToString();
        }
        else
        {
            scoreText.text = "x " + score.ToString();
        }

        if (id == 4)
        {
            if (score < 500)
            {
                scoreText.text = "I should try harder.";
            }
            else if (score >= 500 && score < 800)
            {
                scoreText.text = "I'm not going outside today.";
            }
            else if (score >= 800 && score < 1000)
            {
                scoreText.text = "I'm so embarassed.";
            }
            else if (score >= 1000)
            {
                scoreText.text = "This is a tear of joy.";
            }
            else
            {
                scoreText.text = "I think you broke my game.";
            }

        }
    }

    void GetScore()
    {
        if (id == 0) score = GameManager.instance.apples;
        if (id == 1) score = GameManager.instance.mushrooms;
        if (id == 2) score = GameManager.instance.hedgehogs;
        if (id == 3 || id == 4) score = GameManager.instance.totalScore;
    }
}
