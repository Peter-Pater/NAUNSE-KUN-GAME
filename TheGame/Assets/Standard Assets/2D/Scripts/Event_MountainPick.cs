using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_MountainPick : MonoBehaviour { // This script manages player obtaining mountain pick.

    public GameObject player;

    bool isPickObtained = false;
    SpriteRenderer mySpriteRenderer;
    AudioSource myAudioPlayer;


    // This timer is used to temporarily
    // lock player control during
    // animation
    public float animFreezeTime;
    float freezeTimer;
    bool freezeTimerStart = false;


	// Use this for initialization
	void Start () {
        mySpriteRenderer = transform.parent.GetComponent<SpriteRenderer>();
        myAudioPlayer = GetComponent<AudioSource>();

        freezeTimer = animFreezeTime;
	}
	

	// Update is called once per frame
	void Update () {
		
        if (isPickObtained){
            if (mySpriteRenderer.color.a >= 0.01f){
                mySpriteRenderer.color -= new Color(0, 0, 0, 0.01f);
            }
        }


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


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Input.GetKeyDown(KeyCode.Space)){
            if (!isPickObtained){
                player.GetComponent<Player_Items>().whatsInHand = General_ItemList.MOUNTAINEERINGPICK;
                player.GetComponent<Player_Animation>().SetPickPick();
                isPickObtained = true;

                myAudioPlayer.Play();
                freezeTimerStart = true;
            }
        }
    }
}
