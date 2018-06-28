using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{

    public float xSpeed = 0f; // how fast player moves. Can be adjusted in the inspector.

    Rigidbody2D myRigidbody;


	private void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
	}


	void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            myRigidbody.velocity = new Vector2(-xSpeed, myRigidbody.velocity.y);
        }else if (Input.GetKey(KeyCode.RightArrow))
        {
            myRigidbody.velocity = new Vector2(xSpeed, myRigidbody.velocity.y);      
        }else
        {
            myRigidbody.velocity = new Vector2(0, myRigidbody.velocity.y);
        }
    }

}
