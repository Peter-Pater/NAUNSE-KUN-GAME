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
        //var x = Input.GetAxis("Vertical") * Time.deltaTime * 150.0f;
        //var z = Input.GetAxis("Horizontal") * Time.deltaTime * 10.0f;
        
        //transform.Rotate(0, x, 0);
        //transform.Translate(0, 0, z);

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


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("DoorSwitch"))
        {
            //if (Input.GetKeyUp("space")){
                GameObject.FindGameObjectWithTag("DoorSwitch").GetComponent<SwitchController>().triggered = true;
            //}
        }
    }
}
