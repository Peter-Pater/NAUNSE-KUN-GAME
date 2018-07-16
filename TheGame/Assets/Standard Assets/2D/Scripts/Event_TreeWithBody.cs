using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_TreeWithBody : MonoBehaviour { // This scripts gets player mountaineering pick from the body on the tree.
    
    public GameObject player;

    bool isPickObtained = false;

    AudioSource myAudioPlayer;


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


    // Player obtains the mountaineering pick when interacting with this tree.
	private void OnTriggerStay2D(Collider2D collision)
	{
        if (collision.tag == "Player" && Input.GetKeyDown(KeyCode.Space)){
            if (!isPickObtained)
            {
                player.GetComponent<Player_Items>().whatsInHand = General_ItemList.MOUNTAINEERINGPICK;
                Debug.Log("Mountaineering pick obtained!");
                isPickObtained = true;


                myAudioPlayer.Play();
                player.GetComponent<Player_Animation>().SetShakeTree();
                freezeTimerStart = true;
            }
        }
	}
}
