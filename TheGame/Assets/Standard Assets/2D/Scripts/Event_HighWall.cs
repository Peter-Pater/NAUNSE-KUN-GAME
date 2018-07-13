﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_HighWall : MonoBehaviour { // This script makes player climb up the high wall.

    // Keep track of climbing state
    bool isClimbing = false;
    bool isClimbingComplete = false;


    public float playerClimbingSpeed; // Assigned in the inspector

    public GameObject airwallToBuild;


    // Get a reference to player.
    public GameObject player;
    Player_Items playerItem;


	// Use this for initialization
	void Start () {
        playerItem = player.GetComponent<Player_Items>();
	}
	

	// Update is called once per frame
	void Update () {
		
        if (isClimbing){

            // When climbing, get rid of player gravity scale
            // so that it won't fall for gravity.
            // Disable player control as well.
            player.GetComponent<Rigidbody2D>().gravityScale = 0;
            player.GetComponent<Player_Movement>().enabled = false;

            // Smooth climbing
            Vector3 targetPos = Vector3.Lerp(player.transform.position, new Vector3(61.76f, 20.97f, player.transform.position.z), playerClimbingSpeed * Time.deltaTime);
            player.transform.position = targetPos;
        }


        // When finishing climbing,
        if (Mathf.Abs(player.transform.position.x - 61.76f) <= 0.5f && Mathf.Abs(player.transform.position.y - 20.97f) <= 0.5f)
        {
            
            // Build an airwall so that player can't get down this high wall.
            airwallToBuild.GetComponent<Collider2D>().isTrigger = false;

            // Restore player gravity scale and reenable player control.
            player.GetComponent<Rigidbody2D>().gravityScale = 3;
            player.GetComponent<Player_Movement>().enabled = true;

            // Mark the climbing states as well.
            isClimbingComplete = true;
            isClimbing = false;
        }

	}


    private void OnTriggerStay2D(Collider2D collision)	{
        if (collision.tag == "Player" && Input.GetKeyDown(KeyCode.Space)){
            if (playerItem.whatsInHand == General_ItemList.MOUNTAINEERINGPICK)
            {

                // When player interacts with high wall with mountaineering pick in hand,
                // remove mountaineering pick in hand and start climbing.
                if (!isClimbingComplete)
                {
                    playerItem.whatsInHand = General_ItemList.NONE;
                    player.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
                    isClimbing = true;
                }
            }
        }
	}
}
