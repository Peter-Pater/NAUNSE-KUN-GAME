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


    // Objects relevant to the cutscene
    public GameObject cameraObj;
    public Transform kunTrans;
    public GameObject transObj;
    public Vector3 kunTargetPos;
    public float kunMovingSpeed;

    Transition trans;
    Player_Movement playerMove;
    Camera_Movement cameraMove;


	// Use this for initialization
	void Start () {
        trans = transObj.GetComponent<Transition>();
        playerMove = player.GetComponent<Player_Movement>();
        cameraMove = cameraObj.GetComponent<Camera_Movement>();
	}
	

	// Update is called once per frame
	void Update () {

        UpdatePlayerControlState();
		
        if (isCutsceneOn){

            // During the cutscene,
            // player walks out out core room first.
            if (cameraMove.currentScene == General_SceneList.COREROOM){
                playerMove.WalkLeft();
            }else if (cameraMove.currentScene == General_SceneList.OUTSIDEKUN){

                // After player left core room,
                // KUN starts to lift.
                if ((trans.isTransiting && trans.isRelocateComplete) || (!trans.isTransiting && !trans.isRelocateComplete))
                {
                    player.transform.parent = kunTrans;
                    kunTrans.position = Vector3.Lerp(kunTrans.position, kunTargetPos, kunMovingSpeed * Time.deltaTime);
                }

                // When KUN reaches the end,
                // stop cutscene.
                if (Vector3.Distance(kunTrans.position, kunTargetPos) < 1f){
                    player.transform.parent = null;
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
            }else if (coreState == PUTBACK && player.GetComponent<Player_Items>().whatsInHand == General_ItemList.CORE){

                // Put on the new core,
                // and starts cutscene.
                player.GetComponent<Player_Items>().whatsInHand = General_ItemList.NONE;
                coreState = REPLACED;
                isCutsceneOn = true;
            }
        }
	}


    // Disable/Enable player control
    // according to cutscene state.
    void UpdatePlayerControlState(){
        if (isCutsceneOn){
            player.GetComponent<Player_Movement>().enabled = false;
        }else{
            player.GetComponent<Player_Movement>().enabled = true;
        }
    }
}
