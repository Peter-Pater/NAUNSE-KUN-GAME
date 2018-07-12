using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{ // This script is player control

    public float xSpeed = 0f; // How fast player moves. Assigned in the inspector.

    Rigidbody2D myRigidbody;
    Player_Flip myFlip;


	private void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myFlip = GetComponent<Player_Flip>();
	}


	void Update()
    {

        // Using left and right arrow to move player.
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                WalkRight();   
            }else{
                WalkLeft();
            }
        }else{
            Standstill();
        }
    }


    public void WalkLeft(){
        myRigidbody.velocity = new Vector2(-xSpeed * Time.deltaTime, myRigidbody.velocity.y);
        myFlip.FlipLeft();
    }


    public void WalkRight(){
        myRigidbody.velocity = new Vector2(xSpeed * Time.deltaTime, myRigidbody.velocity.y);
        myFlip.FlipRight();
    }


    public void Standstill(){
        myRigidbody.velocity = new Vector2(0, myRigidbody.velocity.y);
    }

}
