using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Items : MonoBehaviour {

    // keep track of what's in hand
    public int whatsInHand;

	// Use this for initialization
	void Start () {
        whatsInHand = General_ItemList.NONE;
	}
	
	// Update is called once per frame
	void Update () {

        // update player sprite based on what's in hand
        UpdateSprite();
	}


    void UpdateSprite(){
        
    }
}
