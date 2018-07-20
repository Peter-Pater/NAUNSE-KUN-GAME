using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Items : MonoBehaviour { // This script keep track of player's current item in hand.

    // Keep track of the item.
    public int whatsInHand;


	// Use this for initialization
	void Start () {
        whatsInHand = General_ItemList.FLASHLIGHT; // Initialize the item with nothing.
	}
	

	// Update is called once per frame
	void Update () {

        // Update player sprite based on what's in hand.
        UpdateSprite();
	}


    void UpdateSprite(){
        
    }
}
