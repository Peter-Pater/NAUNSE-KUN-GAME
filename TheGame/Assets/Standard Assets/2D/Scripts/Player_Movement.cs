using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{ // This script is player control

    public float xSpeed = 0f; // How fast player moves. Assigned in the inspector.

    Rigidbody2D myRigidbody;


	private void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
	}


	void Update()
    {

        // Using left and right arrow to move player.
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            WalkLeft(); 
        }else if (Input.GetKey(KeyCode.RightArrow))
        {
            WalkRight();    
        }else
        {
            Standstill();
        }
    }


    public void WalkLeft(){
        myRigidbody.velocity = new Vector2(-xSpeed * Time.deltaTime, myRigidbody.velocity.y);
    }


    public void WalkRight(){
        myRigidbody.velocity = new Vector2(xSpeed * Time.deltaTime, myRigidbody.velocity.y);     
    }


    public void Standstill(){
        myRigidbody.velocity = new Vector2(0, myRigidbody.velocity.y);
    }

}
