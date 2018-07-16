using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_PowerStation : MonoBehaviour { // This script triggers events after repairing the power station

    // Repair state
    bool isRepairing = false;
    bool isRepaired = false;
    bool isStoneDropped = false;

    // Speed that each event happens at
    public float platformMovingSpeed;
    public float kunMovingSpeed;
    public float crossFadeSpeed;


    public Transform platformRotPoint;
    public Transform kunHead;
    public Transform treeRotPoint;
    public Transform giantStone;


    // Get reference for camera screen shake.
    public GameObject cameraObj;
    public GameObject player;

    AudioSource myAudioPlayer;


    // The two layers for crossfading.
    SpriteRenderer brokenLayer;
    SpriteRenderer repairedLayer;


    // This timer is used to temporarily
    // lock player control during
    // animation
    public float animFreezeTime;
    float freezeTimer;
    bool freezeTimerStart = false;


	// Use this for initialization
	void Start () {
        myAudioPlayer = GetComponent<AudioSource>();
        freezeTimer = animFreezeTime;

        brokenLayer = transform.GetChild(0).GetComponent<SpriteRenderer>();
        repairedLayer = transform.GetChild(1).GetComponent<SpriteRenderer>();

	}
	
	// Update is called once per frame
	void Update () {
        
        if (isRepairing){

            // Crossfade to repaired sprite
            // when power station is reparied.
            if (brokenLayer.color.a >= 0.01f)
            {
                brokenLayer.color -= new Color(0, 0, 0, crossFadeSpeed);
            }

            if (repairedLayer.color.a <= 0.99f)
            {
                repairedLayer.color += new Color(0, 0, 0, crossFadeSpeed);
            }

            // Rotate the platform and move KUN head
            // when the power station is repaired.
            RotatePlatform();
            RotateAndMoveKUNHead();

            // Stone drops and tree falls
            // after platform and KUN head finish moving.
            if (kunHead.rotation.z <= 0.01f)
            {
                cameraObj.GetComponent<Camera_ScreenShake>().StartShake(0.8f, 0.05f, 0.2f);
                DropStone();
            }


            // Finish repairing process
            // after stone dropped.
            if (isStoneDropped){
                isRepairing = false;
                isRepaired = true;
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


	private void OnTriggerStay2D(Collider2D collision)
	{

        // When player interacts with power station with GEAR in hand,
        // remove GEAR from hand and mark repaired.
        if (collision.tag == "Player" && collision.gameObject.GetComponent<Player_Items>().whatsInHand == General_ItemList.GEAR){
            if (Input.GetKeyDown(KeyCode.Space) && !isRepaired){
                collision.gameObject.GetComponent<Player_Items>().whatsInHand = General_ItemList.NONE;
                isRepairing = true;


                myAudioPlayer.Play(); // Play sound effect.
                player.GetComponent<Player_Animation>().SetPick(); // Trigger animation
                freezeTimerStart = true; // Start short animation freeze.
            }
        }
	}


    // Smooth rotation for platform
    void RotatePlatform(){
        platformRotPoint.rotation = Quaternion.Slerp(platformRotPoint.rotation, Quaternion.Euler(0, 0, 16), platformMovingSpeed * Time.deltaTime);
    }


    // Smooth movement for KUN
    void RotateAndMoveKUNHead(){
        kunHead.rotation = Quaternion.Slerp(kunHead.rotation, Quaternion.Euler(0, 0, 0), kunMovingSpeed * Time.deltaTime);
        kunHead.position = Vector3.Lerp(kunHead.position, new Vector3(122.7f, 2.4f, kunHead.position.z), kunMovingSpeed * Time.deltaTime);
    }


    // Relocate giant stone so that it drops.
    void DropStone(){
        if (!isStoneDropped){
            giantStone.position = new Vector3(32.89f, 9.4f, giantStone.position.z);
            isStoneDropped = true;
        }
    }

}
