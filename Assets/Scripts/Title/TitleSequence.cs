using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Prime31.ZestKit;

public class TitleSequence : MonoBehaviour
{
    public delegate void TextMove();
    public static event TextMove OnTextMove;

    public int sequence = 1;
    private int house_texts = 3;
    private int kid_texts = 3;
    private int press_a_texts = 3;
    private int ready_texts = 2;

    private bool readyToAdvance = false;

    void LateUpdate ()
    {
        if (sequence == 1)
        {
            if (Input.GetButtonDown("A"))
            {
                StartCoroutine(WaitToAdvance());
                sequence += 1;
                MoveCameraDown();
            }
        }

        if (sequence == 2)
        {
            if (Input.GetButtonDown("A") && readyToAdvance)
            {
                StartCoroutine(WaitToAdvance());
                OnTextMove();
                house_texts -= 1;

                if (house_texts == 0)
                {
                    sequence += 1;
                    MoveCameraDown();
                }
            }
        }

        if (sequence == 3)
        {
            if (Input.GetButtonDown("A") && readyToAdvance)
            {
                StartCoroutine(WaitToAdvance());
                OnTextMove();
                kid_texts -= 1;

                if (kid_texts == 0)
                {
                    sequence += 1;
                    MoveCameraDown();
                }
            }
        }

        if (sequence == 4)
        {
            if (Input.GetButtonDown("A") && readyToAdvance)
            {
                StartCoroutine(WaitToAdvance());
                OnTextMove();
                press_a_texts -= 1;

                if (press_a_texts == 0)
                {
                    sequence += 1;
                    MoveCameraDown();
                }
            }
        }

        if (sequence == 5)
        {
            if (readyToAdvance && (Input.GetButtonDown("A") || Input.GetButtonDown("B")))
            {
                StartCoroutine(WaitToAdvance());
                sequence += 1;
                MoveCameraDown();
            }
        }

        if (sequence == 6)
        {
            if (Input.GetButtonDown("A") && readyToAdvance)
            {
                StartCoroutine(WaitToAdvance());
                OnTextMove();
                ready_texts -= 1;

                if (ready_texts == 0)
                {
                    SceneManager.LoadScene(1);
                }
            }
        }

    }

    void MoveCameraDown()
    {
        Vector3 offset = new Vector3(0f, -12f, 0f);
        Vector3 newPosition = transform.position + offset;

        // elastic takes too long to use completion handler... needs to be immediate check
        transform.ZKpositionTo(newPosition, 3f)
            .setEaseType(EaseType.ElasticOut)
            .start();
    }

    IEnumerator WaitToAdvance()
    {
        readyToAdvance = false;
        yield return new WaitForSeconds(1);

        readyToAdvance = true;
    }
}
