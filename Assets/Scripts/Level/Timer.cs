using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timer;
    private float time = 60f;
    private int roundSeconds;
    private bool timeUp = false;

	void Update ()
    {
        if (time > 0) time -= Time.deltaTime;
        roundSeconds = Mathf.RoundToInt(time);
        GameManager.instance.timeLeft = roundSeconds;
        timer.text = roundSeconds.ToString();

        if (roundSeconds == 0 && !timeUp)
        {
            timeUp = true;
            GameManager.instance.LevelEnd();
            timer.enabled = false;
        }
	}
}
