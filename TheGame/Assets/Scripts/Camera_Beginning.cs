﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Camera_Beginning : MonoBehaviour { // This script manages beginning event.

    public Text title;
    SpriteRenderer blackCurtain;


    public GameObject player;
    public Tutorial_Beginning beginningTutorial;
    public Environment_InsideKunAlert alert;

    public float titleStayingTime;
    public float instructionStayingTime;


    int TITLE = 0;
    int display = 0;


    bool isRevealingScreen = false;
    bool isPlayerAwake = false;
    bool isGameStart = false;


	// Use this for initialization
	void Start () {
        blackCurtain = transform.GetChild(0).GetComponent<SpriteRenderer>();

        player.GetComponent<Rigidbody2D>().gravityScale = 0;
        player.GetComponent<Player_Movement>().LockControl();
	}
	
	// Update is called once per frame
	void Update () {

        if (display == TITLE)
        {
            if (titleStayingTime > 0)
            {
                
                if (title.color.a <= 0.99f)
                {
                    title.color += new Color(0, 0, 0, 0.25f * Time.deltaTime);
                }
                else
                {
                    title.color = new Color(1, 1, 1, 1f);
                    titleStayingTime -= Time.deltaTime;

                    if (Input.GetKeyDown(KeyCode.Space)){
                        titleStayingTime = 0;
                    }
                }
            }
            else
            {
                if (title.color.a >= 0.01f)
                {
                    title.color -= new Color(0, 0, 0, 0.25f * Time.deltaTime);

                    if (title.color.a <= 0.618f){
                        if (!isGameStart)
                        {
                            isRevealingScreen = true;
                        }
                    }
                }
                else
                {
                    title.color = new Color(1, 1, 1, 0f);
                }
            }
        }


        if (isRevealingScreen){
            RevealScreen();
        }

	}


    void RevealScreen(){

        if (blackCurtain.color.a >= 0.01f){
            blackCurtain.color -= new Color(0, 0, 0, 0.22f * Time.deltaTime);
        }else{
            alert.isStarted = true;

            if (!isPlayerAwake)
            {
                player.GetComponent<Player_Animation>().SetWakeUp();

                if (player.GetComponent<Player_Animation>().GetCurrentStateInfo().IsName("SittingOnBed"))
                {
                    isPlayerAwake = true;
                    beginningTutorial.displaySpace = true;
                }
            }
        }

        if (isPlayerAwake && Input.GetKeyDown(KeyCode.Space)){
            if (!isGameStart)
            {
                player.GetComponent<Player_Animation>().SetStandUp();
                player.GetComponent<Rigidbody2D>().gravityScale = 3;
                player.GetComponent<Player_Movement>().UnlockControl();

                isGameStart = true;
                isRevealingScreen = false;
            }
        }
    }
}
