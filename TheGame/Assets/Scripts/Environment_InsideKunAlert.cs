using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment_InsideKunAlert : MonoBehaviour { // This script manages alert inside KUN.

    public float targetVolume;
    bool raiseVolume = false;
    bool lowerVolume = false;
    public bool isStarted = false;

    AudioSource myAudioPlayer;
    public Camera_Movement camMov;


	// Use this for initialization
	void Start () {
        myAudioPlayer = GetComponent<AudioSource>();
	}
	

	// Update is called once per frame
	void Update () {

        UpdateVolumeState();
	}


    void UpdateVolumeState()
    {

        if (isStarted)
        {
            if (camMov.currentScene == General_SceneList.INSIDEKUN)
            {
                PlayBGM();
            }
            else
            {
                StopBGM();
            }
        }
    }


    void PlayBGM()
    {
        if (!myAudioPlayer.isPlaying)
        {
            myAudioPlayer.Play();
        }

        if (myAudioPlayer.volume < targetVolume)
        {
            myAudioPlayer.volume += 0.01f;
        }
    }


    void StopBGM()
    {
        if (myAudioPlayer.volume > 0.05f)
        {
            myAudioPlayer.volume -= 0.01f;
        }
        else
        {
            myAudioPlayer.Stop();
        }
    }

}
