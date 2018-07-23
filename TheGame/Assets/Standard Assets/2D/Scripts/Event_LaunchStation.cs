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
    public Vector3 launchingCameraPos;
    public float flyAwayViewSize;
    public Vector3 flyAwayCameraPos;


    public float sittingPos;

    public SpriteRenderer lightRenderer; // The light column.

    SpriteRenderer textOnScreen;
    AudioSource myAudioPlayer;


	// Use this for initialization
	void Start () {
        myAudioPlayer = GetComponent<AudioSource>();
        textOnScreen = transform.GetChild(1).GetComponent<SpriteRenderer>();

        phase2Timer = phase2LaunchingTime;
	}
	

	// Update is called once per frame
	void Update () {

        UpdatePlayerAnimation();
        UpdateTextOnMonitor();
        UpdateLightColumn();


        if (isLaunching){

            // When in phase 1,
            // KUN rises.
            if (launchingPhase == PHASE1)
            {
                kun.transform.position += Vector3.up * (launchingSpeed / 2) * Time.deltaTime;

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
                // Normalize camera view.
                cameraObj.GetComponent<Camera_CustomizeView>().BackToNormal();

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
            }
            else if (launchingPhase == PHASE2)
            {

                // If in phase 2,
                // reset launching timer.
                phase2Timer = phase2LaunchingTime;
            }
        }
	}


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Input.GetKeyDown(KeyCode.Space)){
            if (!isCutsceneOn && !isLaunching)
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


    void UpdateTextOnMonitor(){
        if (isLaunching){
            textOnScreen.color = new Color(textOnScreen.color.r, textOnScreen.color.g, textOnScreen.color.b, 1f);
        }else{
            textOnScreen.color = new Color(textOnScreen.color.r, textOnScreen.color.g, textOnScreen.color.b, 0f);
        }
    }


    void UpdateLightColumn(){
        if (isLaunching || isCutsceneOn && !isEndingTriggered){
            lightRenderer.enabled = true;
        }else{
            lightRenderer.enabled = false;
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

        // When KUN flies up to certain height,
        // trigger ending cutscene.
        if (kun.transform.position.y >= 280f)
        {
            isEndingTriggered = true;
        }


        if (!isEndingTriggered)
        {

            // Customize camera view to flyaway view.
            cameraObj.GetComponent<Camera_CustomizeView>().CustomizeView(flyAwayViewSize, flyAwayCameraPos);


            // Player walks to the side and start looking at KUN.
            if (player.transform.position.x < sittingPos){
                player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
                player.GetComponent<Player_Constraints>().enabled = false;
                player.GetComponent<Player_Movement>().WalkRight();
            }else{
                player.GetComponent<Player_Movement>().Standstill();
                player.GetComponent<Player_Constraints>().enabled = true;
                player.GetComponent<Player_Animation>().StartLookingAtKUN();
            }
        }else{

            // During the second half of the cutscene (endind),
            // camera rooms back to player.
            // Player sits.
            cameraObj.GetComponent<Camera_CustomizeView>().BackToNormal();
            player.GetComponent<Player_Animation>().SetSitDown();
           
        }

    }
}
