using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_TreeWithBody : MonoBehaviour { // This script makes player shake mountain pick off the tree.
    
    public GameObject player;
    public GameObject mountainPick;

    bool isPickDropped = false;

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
            if (!isPickDropped)
            {
                mountainPick.GetComponent<Rigidbody2D>().gravityScale = 1;
                isPickDropped = true;


                myAudioPlayer.Play();
                player.GetComponent<Player_Animation>().SetShakeTree();
                freezeTimerStart = true;
            }
        }
	}
}
