﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_DoorPad : MonoBehaviour { // This script opens the exit inside KUN.

    public GameObject kunExit; //Assign KUN exit game object to this variable in the inspector.
    public GameObject player;

    bool triggered = false;

    SpriteRenderer mySpriteRenderer;
    Event_KUNExit exitEventScript;


    // This timer is used to temporarily
    // lock player control during
    // animation
    public float animFreezeTime;
    float freezeTimer;
    bool freezeTimerStart = false;


	// Use this for initialization
	void Start () {
        
        mySpriteRenderer = GetComponent<SpriteRenderer>();

        // Refer to the exit event script.
        exitEventScript = kunExit.GetComponent<Event_KUNExit>();

        // Initialize freeze timer
        freezeTimer = animFreezeTime;
	}


    // Update is called once per frame
    void Update()
    {
        
        if (triggered)
        {
            // When the door pad is triggered,
            // change its color.
            // Move up the exit door.
            mySpriteRenderer.color = Color.green;
            exitEventScript.moveUp();

            // call move down
            //exitEventScript.moveDown();

            if (exitEventScript.upDownComplete)
            {

                // When the exit door finished moving,
                // change the color back.
                mySpriteRenderer.color = Color.white;
                triggered = false;
            }
        }


        if (freezeTimerStart){
            player.GetComponent<Player_Movement>().LockControl();

            freezeTimer -= Time.deltaTime;
            if (freezeTimer <= 0){
                player.GetComponent<Player_Movement>().UnlockControl();
                freezeTimer = animFreezeTime;
                freezeTimerStart = false;
            }
        }
    }


    // Trigger the event when player interacts with the door pad.
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.Space)){
                triggered = true;
                GetComponent<AudioSource>().Play();
                player.GetComponent<Player_Animation>().SetPressButton();
                freezeTimerStart = true;
            }
        }
    }
}
