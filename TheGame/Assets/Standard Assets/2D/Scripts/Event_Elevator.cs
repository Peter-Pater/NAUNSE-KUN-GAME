using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_Elevator : MonoBehaviour { // This script lifts the elevator.

    // Keep track of current state
    int DOWN = 0;
    int UP = 1;
    int currentState = 0;


    public bool isLifting = false;
    public float liftingSpeed;


    public GameObject player;
    public float targetHeight;
    GameObject rightWall;


	// Use this for initialization
	void Start () {
        rightWall = transform.GetChild(2).gameObject;
	}


    // Update is called once per frame
    void Update()
    {
        UpdateRightWall();

        if (isLifting && currentState == DOWN){
            if (transform.position.y < targetHeight){
                transform.position += liftingSpeed * Time.deltaTime * Vector3.up;
            }

            // Mark states when finished lifting.
            else{
                isLifting = false;
                currentState = UP;
            }
        }
    }


    // Solidate the right wall
    // so that player can't walk out of elevator
    // when lifting.
    void UpdateRightWall(){
        if (isLifting){
            rightWall.GetComponent<Collider2D>().isTrigger = false;
        }else{
            rightWall.GetComponent<Collider2D>().isTrigger = true;
        }
    }
}
