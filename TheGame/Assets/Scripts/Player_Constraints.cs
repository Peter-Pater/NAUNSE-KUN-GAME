using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Constraints : MonoBehaviour { // This script prevents player from sliding on slopes.

    Rigidbody2D myRigidbody;
    Player_Movement myMovement;

	// Use this for initialization
	void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();
        myMovement = GetComponent<Player_Movement>();
	}
	
	// Update is called once per frame
	void Update () {

        if (myMovement.GetControlLockState() && (!myMovement.isCutScene))
        {
            myRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
        }else if (myMovement.GetControlLockState() && myMovement.isCutScene){
            myRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        }else{
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
}
