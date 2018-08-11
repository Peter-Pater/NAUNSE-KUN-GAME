using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_BGMManage : MonoBehaviour { // This script manages scene background music.
    
    public float targetVolume;
    bool raiseVolume = false;
    bool lowerVolume = false;

    AudioSource myAudioPlayer;


	// Use this for initialization
	void Start () {
        myAudioPlayer = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
        if (raiseVolume){
            if (myAudioPlayer.volume < targetVolume)
            {
                myAudioPlayer.volume += 0.01f;
            }
            else
            {
                raiseVolume = false;
            };
        }else if (lowerVolume){
            if (myAudioPlayer.volume > 0.05f)
            {
                myAudioPlayer.volume -= 0.01f;
            }
            else
            {
                myAudioPlayer.Stop();
                lowerVolume = false;
            }
        }
	}


    public void PlayBGM(){
        myAudioPlayer.Play();
        raiseVolume = true;

    }


    public void StopBGM(){
        lowerVolume = true;
    }
}
