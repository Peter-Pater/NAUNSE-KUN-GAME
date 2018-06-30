﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition_toOutsideKUN : MonoBehaviour { // The script transit player and camera to the "Outside KUN" scene.

    public GameObject cameraObj;
    public GameObject player;


    // Positions that Camera and player are supposed to be moved to.
    // Assigned in the inspector.
    public Vector3 playerTargetPos;
    public Vector3 cameraTargetPos;


    // Keep track of transition state
    bool isTransiting = false;
    bool isTransComplete = false;


    float curtainOpacity = 0; // Used to change opacity of the black curtain in front of camera.
    SpriteRenderer curtainRenderer;


	// Use this for initialization
	void Start () {
        curtainRenderer = cameraObj.transform.GetChild(0).GetComponent<SpriteRenderer>();
	}
	

	// Update is called once per frame
	void Update () {
		
        if (isTransiting){
            if (!isTransComplete){

                // Start transiting.
                // Enable player movement.
                // Lock camera.
                player.GetComponent<Player_Movement>().enabled = false;
                cameraObj.GetComponent<Camera_Movement>().LockCamera();


                // Fade in the black curtain
                // so that camera view fades to black.
                if (curtainOpacity < 0.99f){
                    curtainOpacity += 0.01f;
                    curtainRenderer.color = new Color(curtainRenderer.color.r, curtainRenderer.color.g, curtainRenderer.color.b, curtainOpacity);
                }else{

                    // After camera view faded to black,
                    // relocate player and camera to the new position.
                    player.transform.position = playerTargetPos;
                    cameraObj.transform.position = cameraTargetPos;

                    // Change the current scene.
                    // Unlock camera so that it follows player again.
                    cameraObj.GetComponent<Camera_Movement>().currentScene = General_SceneList.OUTSIDEKUN;
                    cameraObj.GetComponent<Camera_Movement>().UnlockCamera();

                    isTransComplete = true;
                }

            }else{

                // After completing transiting player and camera,
                // black curtain fades out so that camera view comes back.
                if (curtainOpacity > 0.01f){
                    curtainOpacity -= 0.01f;
                    curtainRenderer.color = new Color(curtainRenderer.color.r, curtainRenderer.color.g, curtainRenderer.color.b, curtainOpacity);
                }else{

                    // After camera view is back,
                    // reenable player movement.
                    // Transition complete.
                    player.GetComponent<Player_Movement>().enabled = true;
                    isTransiting = false;
                    isTransComplete = false;
                }
            }
        }
	}


	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.tag == "Player"){
            isTransiting = true;
        }
	}
}