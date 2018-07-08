using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_KUNCore : MonoBehaviour { // This script controls events regarding KUN's core.

    // Keep track of what state core is currently in.
    int ONTHEGROUND = 0;
    int PUTBACK = 1;
    int REPLACED = 2;
    int coreState = 0;


    public GameObject toolWall;
    public GameObject player;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	private void OnTriggerStay2D(Collider2D collision)
	{
        if (collision.tag == "Player" && Input.GetKeyDown(KeyCode.Space)){

            // Put back the broken core on the ground
            // and the tool wall will open.
            if (coreState == ONTHEGROUND){
                coreState = PUTBACK;
                toolWall.GetComponent<Event_ToolWall>().isOpen = true;
            }else if (coreState == PUTBACK){
                player.GetComponent<Player_Items>().whatsInHand = General_ItemList.NONE;
                coreState = REPLACED;
            }
        }
	}
}
