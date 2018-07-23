using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_LaunchStation : MonoBehaviour { // This script is about launching KUN.

    // Keep track of launching phase.
    int PHASE1 = 0;
    int PHASE2 = 1;
    int launchingPhase = 0;


    // Keep track of states
    bool isLaunching = false;
    bool isCutsceneOn = false;
    bool isEndingTriggered = false;


    public GameObject player;
    public GameObject kun;
    public GameObject cameraObj;

    public float launchingSpeed;

    public float phase2Height; // The minimal height KUN has to reach in order to get to phase 2.
    public float phase2LaunchingTime; // The minimal launching time KUN has to go through before launching in phase 2.
    public Vector3 floatingPointA; // The range of floating in phase 2.
    public Vector3 floatingPointB;
    public float originalHeight; // The original height before starting launching.
    float phase2Timer;


    public float launchingViewSize;
    Vector3 launchingCameraPos;


    AudioSource myAudioPlayer;


	// Use this for initialization
	void Start () {
        myAudioPlayer = GetComponent<AudioSource>();
        phase2Timer = phase2LaunchingTime;
	}
	

	// Update is called once per frame
	void Update () {

        UpdatePlayerAnimation();


        if (isLaunching){

            // When in phase 1,
            // KUN rises.
            if (launchingPhase == PHASE1)
            {
                kun.transform.position += Vector3.up * launchingSpeed * Time.deltaTime;

                // Camera follows KUN in phase 1.
                launchingCameraPos = kun.transform.position + new Vector3(-47.8f, 10.2f, 0);
                launchingCameraPos = new Vector3(launchingCameraPos.x, launchingCameraPos.y, -10);
            }else if (launchingPhase == PHASE2){

                // When in phase 2,
                // KUN floats at the same height.
                // Count phase 2 timer.
                KUNFloating();
                phase2Timer -= Time.deltaTime;
            }


            // When launching,
            // change camera view to customize view.
            cameraObj.GetComponent<Camera_CustomizeView>().CustomizeView(launchingViewSize, launchingCameraPos);


            // If player walked away before KUN reaches the minimal height,
            // stop launching.
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)){
                isLaunching = false;
            }

            // Update phase state based on kun's current situation.
            UpdatePhaseState();


        }else if (isCutsceneOn){
            
            DoCutscene();


        }else if (!isCutsceneOn){

            // If launching is stopped before triggering ending cutscene,
            if (launchingPhase == PHASE1)
            {
                // If still in phase 1,
                // goes back to original height.
                if (kun.transform.position.y > originalHeight)
                {
                    kun.transform.position += Vector3.down * launchingSpeed * Time.deltaTime;
                }
            }else if (launchingPhase == PHASE2){

                // If in phase 2,
                // reset launching timer.
                phase2Timer = phase2LaunchingTime;
            }

            // Normalize camera view.
            cameraObj.GetComponent<Camera_CustomizeView>().BackToNormal();
        }
	}


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Input.GetKeyDown(KeyCode.Space)){
            if (!isCutsceneOn)
            {
                myAudioPlayer.Play();
                isLaunching = true;
            }
        }
    }


    void UpdatePlayerAnimation(){

        if (isLaunching){
            player.GetComponent<Player_Animation>().StartTyping();
        }else{
            player.GetComponent<Player_Animation>().StopTyping();
        }
    }


    void UpdatePhaseState(){
        
        // Goes to phase 2 upon reaching phase 2 height.
        if (kun.transform.position.y >= phase2Height)
        {
            launchingPhase = PHASE2;
        }

        // Start ending cutscene when phase 2 timer's up.
        if (phase2Timer <= 0)
        {
            isLaunching = false;
            player.GetComponent<Player_Movement>().LockControl();
            kun.GetComponent<Animator>().SetTrigger("SetCloseMouth");
            isCutsceneOn = true;
        }
    }


    void KUNFloating(){
        kun.transform.position = Vector3.Lerp(floatingPointA, floatingPointB, Mathf.Sin(Time.time * Mathf.PI * 0.2f));
    }


    void DoCutscene(){
        // When cutscene is triggered,
        // KUN flies away.
        kun.transform.position += Vector3.up * launchingSpeed * Time.deltaTime;
        if (kun.transform.position.y >= 190f)
        {
            isEndingTriggered = true;
        }


        if (!isEndingTriggered)
        {
            cameraObj.GetComponent<Camera_CustomizeView>().CustomizeView(launchingViewSize, launchingCameraPos);
            launchingViewSize += 0.015f;
        }else{
            cameraObj.GetComponent<Camera_CustomizeView>().BackToNormal();
        }

    }
}
