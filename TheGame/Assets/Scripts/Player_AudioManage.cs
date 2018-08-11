using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_AudioManage : MonoBehaviour { // This script manages player walking audio.

    AudioSource myAudioPlayer;


	// Use this for initialization
	void Start () {
        myAudioPlayer = GetComponent<AudioSource>();
	}
	

	// Update is called once per frame
	void Update () {
		
	}


    public void PlayFootStep(){
        if (!myAudioPlayer.isPlaying)
        {
            myAudioPlayer.Play();
        }
    }


    public void StopFootStep(){
        myAudioPlayer.Stop();
    }
}
