using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_KUNCore : MonoBehaviour { // This script controls events regarding KUN's core.

    // Keep track of what state core is currently in.
    int ONTHEGROUND = 0;
    int PUTBACK = 1;
    int REPLACED = 2;
    int coreState = 0;


    bool isCutsceneOn = false; // Keep track of whether or not the cutscene is triggered.
    bool isWaitingForCutscene = false;
    bool isScreenShaked = false;
    bool isTransfromed = false;
    public float waitingForCutsceneTime;


    // These three sprites will fade in/out during this event.
    SpriteRenderer brokenCoreGround; // Broken core sprite on the ground.
    SpriteRenderer brokenCoreLayer; // Broken core sprite on the wall.
    SpriteRenderer newCoreLayer; // New core sprite on the wall.

    public GameObject toolWall;
    public GameObject player;
    Transform glassTrans;
    float glassTargetHeight;


    AudioSource myAudioPlayer;


    // Objects relevant to the cutscene
    public GameObject cameraObj;
    public Transform kunTrans;
    public GameObject transObj;
    public float kunTargetHeight;
    public float kunMovingSpeed;


    // Size and pos for camera during rising cutscene.
    Vector3 cutsceneCameraPos;
    public float cutsceneCameraViewSize;


    Transition trans;
    Player_Movement playerMove;
    Player_Animation playerAnimationControl;
    Camera_Movement cameraMove;


    // This timer is used to temporarily
    // lock player control during
    // animation
    public float animFreezeTime;
    float freezeTimer;
    bool freezeTimerStart = false;


	// Use this for initialization
	void Start () {

        brokenCoreGround = transform.GetChild(0).GetComponent<SpriteRenderer>();
        newCoreLayer = transform.GetChild(1).GetComponent<SpriteRenderer>();
        brokenCoreLayer = transform.GetChild(2).GetComponent<SpriteRenderer>();


        glassTrans = toolWall.transform.GetChild(1);
        glassTargetHeight = glassTrans.position.y + 1.5f;
        myAudioPlayer = GetComponent<AudioSource>();


        trans = transObj.GetComponent<Transition>();
        playerMove = player.GetComponent<Player_Movement>();
        playerAnimationControl = player.GetComponent<Player_Animation>();
        cameraMove = cameraObj.GetComponent<Camera_Movement>();

        freezeTimer = animFreezeTime;
	}
	

	// Update is called once per frame
	void Update () {

        // If broken core is put back,
        // broken core on ground disappears
        // and appears on the wall.
        if (coreState == PUTBACK){
            if (brokenCoreGround.color.a >= 0.01f){
                brokenCoreGround.color -= new Color(0, 0, 0, 0.7f * Time.deltaTime);
            }
            if (brokenCoreLayer.color.a <= 0.99f){
                brokenCoreLayer.color += new Color(0, 0, 0, 0.7f * Time.deltaTime);
            }

            // Raise the glass too when broken core is put back.
            if (glassTrans.position.y < glassTargetHeight){
                glassTrans.position += 0.7f * Time.deltaTime * Vector3.up;
            }
        }else if (coreState == REPLACED){

            // If core is replaced with new core,
            // broken core on wall disappears
            // and the new one appears.
            if (brokenCoreLayer.color.a >= 0.01f)
            {
                brokenCoreLayer.color -= new Color(0, 0, 0, 0.7f * Time.deltaTime);
            }
            if (newCoreLayer.color.a <= 0.99f)
            {
                newCoreLayer.color += new Color(0, 0, 0, 0.7f * Time.deltaTime);
            }
        }
        

        if (freezeTimerStart)
        {
            playerMove.LockControl();

            freezeTimer -= Time.deltaTime;
            if (freezeTimer <= 0)
            {
                playerMove.UnlockControl();
                freezeTimer = animFreezeTime;
                freezeTimerStart = false;
            }
        }


        // Wait for some time before triggering cutscene.
        if (isWaitingForCutscene){
            waitingForCutsceneTime -= Time.deltaTime;

            if (waitingForCutsceneTime <= 0){
                isCutsceneOn = true;
            }
        }

        if (isCutsceneOn)
        {
            // Disable rigidbody constraints on player
            // since player will be moving without
            // player control.
            playerMove.LockControl();
            player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            player.GetComponent<Player_Constraints>().enabled = false;

            // During the cutscene,
            // player walks out out core room first.
            if (cameraMove.currentScene == General_SceneList.COREROOM)
            {
                playerMove.WalkLeft();
            }
            else if (cameraMove.currentScene == General_SceneList.OUTSIDEKUN)
            {
                // Start screen shake when rising.
                if (!isScreenShaked)
                {
                    cameraObj.GetComponent<Camera_ScreenShake>().StartShake(18f, 0.05f, 0.05f);
                    isScreenShaked = true;
                }

                // Player stands still after went outside.
                playerMove.Standstill();


                // Update cutscene camera pos based on player position.
                cutsceneCameraPos = player.transform.position + new Vector3(-1.2f, -3.2f, 0);
                cutsceneCameraPos = new Vector3(cutsceneCameraPos.x, cutsceneCameraPos.y, -10);


                // After player left core room,
                // KUN starts to rise.
                if ((trans.isTransiting && trans.isRelocateComplete) || (!trans.isTransiting && !trans.isRelocateComplete))
                {
                    cameraObj.GetComponent<Camera_CustomizeView>().CustomizeView(cutsceneCameraViewSize, cutsceneCameraPos);
                    //player.transform.parent = kunTrans;
                    player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
                    KUNRise();
                }


                // After rising to certian height,
                // KUN transforms into "PENG".
                if (kunTrans.position.y >= 27f)
                {
                    KUNTransform();
                }


                // When KUN reaches the end,
                // stop cutscene.
                if (kunTrans.position.y >= kunTargetHeight)
                {
                    StopCutscene();
                }
            }
        }
        
	}


	private void OnTriggerStay2D(Collider2D collision)
	{
        if (collision.tag == "Player" && Input.GetKeyDown(KeyCode.Space)){

            // Put back the broken core on the ground
            // and the tool wall will open.
            if (coreState == ONTHEGROUND){
                coreState = PUTBACK;
                toolWall.GetComponent<Event_ToolWall>().isOpen = true;

                myAudioPlayer.Play();
                playerAnimationControl.SetPick();
                freezeTimerStart = true;
            }else if (coreState == PUTBACK && player.GetComponent<Player_Items>().whatsInHand == General_ItemList.CORE){

                // Put on the new core,
                // and starts cutscene.
                player.GetComponent<Player_Items>().whatsInHand = General_ItemList.NONE;
                coreState = REPLACED;

                kunTrans.GetChild(8).GetComponent<AudioSource>().Stop();
                kunTrans.GetChild(8).GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);

                // Trigger sound effects and animation;
                myAudioPlayer.Play();
                playerAnimationControl.SetReleaseCore();


                playerMove.Standstill();
                isWaitingForCutscene = true;
            }
        }
	}


    void KUNRise(){

        if (kunTrans.position.y < kunTargetHeight)
        {
            kunTrans.position += kunMovingSpeed * Time.deltaTime * Vector3.up;
        }
    }


    void KUNTransform(){
        
        if (!isTransfromed){
            kunTrans.GetComponent<Animator>().SetTrigger("SetTransform");
            isTransfromed = true;
        }
    }


    void StopCutscene(){
        cameraObj.GetComponent<Camera_CustomizeView>().BackToNormal();

        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        player.GetComponent<Player_Constraints>().enabled = true;
        player.GetComponent<Player_Movement>().UnlockControl();

        isCutsceneOn = false;

    }

}
