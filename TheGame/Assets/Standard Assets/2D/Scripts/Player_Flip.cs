using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Flip : MonoBehaviour { // This script flips player and the flash light.

    // When flipping character,
    // change position of flash light
    // so that it's always in front of player.
    Transform myLightTrans;


	// Use this for initialization
	void Start () {
        myLightTrans = transform.GetChild(0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void FlipLeft(){
        transform.eulerAngles = new Vector3(transform.rotation.x, 0, transform.rotation.z);
        myLightTrans.localPosition = new Vector3(myLightTrans.localPosition.x, myLightTrans.localPosition.y, -1.2f); 
    }


    public void FlipRight(){
        transform.eulerAngles = new Vector3(transform.rotation.x, 180, transform.rotation.z);
        myLightTrans.localPosition = new Vector3(myLightTrans.localPosition.x, myLightTrans.localPosition.y, 1.2f); 
    }
}
