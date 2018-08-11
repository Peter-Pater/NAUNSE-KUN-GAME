using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Constraints : MonoBehaviour { // This script prevents player from sliding on slopes.

    Rigidbody2D myRigidbody;

	// Use this for initialization
	void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            myRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        else
        {
            myRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
        }
	}
}
