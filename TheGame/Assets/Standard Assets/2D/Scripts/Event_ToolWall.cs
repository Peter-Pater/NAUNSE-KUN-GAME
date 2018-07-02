using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_ToolWall : MonoBehaviour { // This script lets player obtain flash light.

    public GameObject player; // Assigned in the inspector.

    // Whether the tool wall is open or not.
    public bool isOpen = false;

    bool isLightObtained = false;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
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
            }
        }
	}
}
