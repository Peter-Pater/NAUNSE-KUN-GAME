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
    public Vector3 targetPos;
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
            transform.position = Vector3.Lerp(transform.position, targetPos, liftingSpeed * Time.deltaTime);

            // Mark states when finished lifting.
            if (Mathf.Abs(transform.position.y - targetPos.y) < 0.5f){
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
