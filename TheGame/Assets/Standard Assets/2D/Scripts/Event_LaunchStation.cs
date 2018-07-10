using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_LaunchStation : MonoBehaviour { // This script is about launching KUN.

    // Keep track of states
    bool isLaunching = false;
    bool isCutsceneOn = false;


    public GameObject kun;
    public float launchingSpeed;
    public float minimalHeight; // The minimal height KUN has to reach in order to launch.
    public float originalHeight;
        

	// Use this for initialization
	void Start () {
		
	}
	

	// Update is called once per frame
	void Update () {
		
        if (isLaunching){

            // When launching,
            // KUN rises.
            kun.transform.position += Vector3.up * launchingSpeed * Time.deltaTime;

            // If player walked away before KUN reaches the minimal height,
            // stop launching.
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)){
                isLaunching = false;
            }

            // When KUN reaches the minial height,
            // triggers the ending cutscene.
            if (kun.transform.position.y >= minimalHeight){
                isLaunching = false;
                isCutsceneOn = true;
            }
        }else if (isCutsceneOn){

            // When cutscene is triggered,
            // KUN flies away.
            kun.transform.position += Vector3.up * launchingSpeed * Time.deltaTime;
        }else if (!isCutsceneOn){

            // If launching is stopped before triggering ending cutscene,
            // KUN goes back to the original height.
            if (kun.transform.position.y > originalHeight){
                kun.transform.position += Vector3.down * launchingSpeed * Time.deltaTime;
            }
        }
	}


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Input.GetKeyDown(KeyCode.Space)){
            isLaunching = true;
        }
    }
}
