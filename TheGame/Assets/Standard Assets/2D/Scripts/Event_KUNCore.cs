using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_KUNCore : MonoBehaviour { // This script controls events regarding KUN's core.

    // Keep track of what state core is currently in.
    int ONTHEGROUND = 0;
    int PUTBACK = 1;
    int REPLACED = 2;
    int coreState = 0;


    // Keep track of whether or not the cutscene is triggered.
    bool isCutsceneOn = false;


    public GameObject toolWall;
    public GameObject player;

    AudioSource myAudioPlayer;


    // Objects relevant to the cutscene
    public GameObject cameraObj;
    public Transform kunTrans;
    public GameObject transObj;
    public Vector3 kunTargetPos;
    public float kunMovingSpeed;

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
        myAudioPlayer = GetComponent<AudioSource>();

        trans = transObj.GetComponent<Transition>();
        playerMove = player.GetComponent<Player_Movement>();
        playerAnimationControl = player.GetComponent<Player_Animation>();
        cameraMove = cameraObj.GetComponent<Camera_Movement>();

        freezeTimer = animFreezeTime;
	}
	

	// Update is called once per frame
	void Update () {
        

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

        if (isCutsceneOn)
        {
            // Disable rigidbody constraints on position
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

                // After player left core room,
                // KUN starts to lift.
                if ((trans.isTransiting && trans.isRelocateComplete) || (!trans.isTransiting && !trans.isRelocateComplete))
                {
                    player.transform.parent = kunTrans;
                    float newHeight = Mathf.Lerp(kunTrans.position.y, kunTargetPos.y, kunMovingSpeed * Time.deltaTime);
                    kunTrans.position = new Vector3(kunTrans.position.x, newHeight, kunTrans.position.z);
                }

                // When KUN reaches the end,
                // stop cutscene.
                if (Mathf.Abs(kunTrans.position.y - kunTargetPos.y) < 1f)
                {
                    player.transform.parent = null;
                    player.GetComponent<Player_Constraints>().enabled = true;
                    player.GetComponent<Player_Movement>().UnlockControl();
                    isCutsceneOn = false;
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

                myAudioPlayer.Play();
                isCutsceneOn = true;
            }
        }
	}

}
