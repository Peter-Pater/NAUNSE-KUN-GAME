using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment_KUNHowl : MonoBehaviour { // This script manages repeatetive KUN howling.

    public float maxTime;
    public float minTime;

    public GameObject cameraObj;

    float timer = 0;
    bool isGettingNewTime = true;
    AudioSource myAudioPlayer;


    bool isHowling = false;


	// Use this for initialization
	void Start () {
        myAudioPlayer = GetComponent<AudioSource>();
	}
	

	// Update is called once per frame
	void Update () {

        if (cameraObj.GetComponent<Camera_Movement>().currentScene == General_SceneList.OUTSIDEKUN)
        {
            if (isGettingNewTime)
            {
                timer = Random.Range(minTime, maxTime);
                isGettingNewTime = false;
            }

            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                if (!myAudioPlayer.isPlaying && !isHowling)
                {
                    myAudioPlayer.Play();
                    isHowling = true;
                }

                if (!myAudioPlayer.isPlaying && isHowling)
                {
                    isGettingNewTime = true;
                    isHowling = false;
                }
                
            }
        }
	}
}
