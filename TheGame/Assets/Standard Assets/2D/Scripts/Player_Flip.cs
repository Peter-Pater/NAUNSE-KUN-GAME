using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Flip : MonoBehaviour { // This script flips player.


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void FlipLeft(){
        transform.eulerAngles = new Vector3(transform.rotation.x, 0, transform.rotation.z);
    }


    public void FlipRight(){
        transform.eulerAngles = new Vector3(transform.rotation.x, 180, transform.rotation.z);
    }
}
