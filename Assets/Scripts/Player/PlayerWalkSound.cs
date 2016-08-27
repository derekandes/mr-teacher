using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerWalkSound : MonoBehaviour
{
    AudioSource a;
    private bool playWalk = false;
    private bool walkPlaying = false;
    public AudioClip walkSound;

    void Start()
    {
        a = GetComponent<AudioSource>();
    }

    void Update ()
    {
        if (GameManager.instance.levelEnded)
        {
            walkPlaying = false;
            a.loop = false;
            a.Stop();
        }

        //GET INPUT AXIS
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        //AUDIO
        if (h + v != 0) playWalk = true;
        else playWalk = false;

        if (playWalk == true && walkPlaying == false)
        {
            walkPlaying = true;
            a.clip = walkSound;
            a.loop = true;
            a.Play();
        }
        else if (playWalk == false)
        {
            walkPlaying = false;
            a.loop = false;
            a.Stop();
        }
    }
}
