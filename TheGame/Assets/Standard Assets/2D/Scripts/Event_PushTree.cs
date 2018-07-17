using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_PushTree : MonoBehaviour { // This script manages pushing tree.

    public bool isCutDown = false;

    Rigidbody2D myRigidbody;


	// Use this for initialization
	void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        UpdateRigidbodyState();
	}


    void UpdateRigidbodyState(){
        if (isCutDown)
        {
            myRigidbody.gravityScale = 1;
        }else{
            myRigidbody.gravityScale = 0;
        }
    }
}
