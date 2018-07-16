using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_ToolWall : MonoBehaviour { // This script lets player obtain flash light.

    public GameObject player; // Assigned in the inspector.

    // Whether the tool wall is open or not.
    public bool isOpen = false;
    bool isLightObtained = false;


    AudioSource myAudioPlayer;
    Player_Animation playerAnimationControl;


    // This timer is used to temporarily
    // lock player control during
    // animation
    public float animFreezeTime;
    float freezeTimer;
    bool freezeTimerStart = false;


	// Use this for initialization
	void Start () {
        myAudioPlayer = GetComponent<AudioSource>();
        playerAnimationControl = player.GetComponent<Player_Animation>();

        freezeTimer = animFreezeTime;
	}
	
	// Update is called once per frame
	void Update () {
		
        if (freezeTimerStart)
        {
            player.GetComponent<Player_Movement>().LockControl();

            freezeTimer -= Time.deltaTime;
            if (freezeTimer <= 0)
            {
                player.GetComponent<Player_Movement>().UnlockControl();
                freezeTimer = animFreezeTime;
                freezeTimerStart = false;
            }
        }
	}


    // Player obtains the flash light when interacting with it
    // while tool wall is open.
	private void OnTriggerStay2D(Collider2D collision)
	{
        if (collision.tag == "Player" && Input.GetKeyDown(KeyCode.Space)){
            if (isOpen && !isLightObtained){
                player.GetComponent<Player_Items>().whatsInHand = General_ItemList.FLASHLIGHT;
                Debug.Log("Flash light obtained!");
                isLightObtained = true;


                myAudioPlayer.Play();
                playerAnimationControl.SetPressButton();
                freezeTimerStart = true;
            }
        }
	}
}
