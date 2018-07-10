using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_ElevatorTrigger : MonoBehaviour { // This script triggers elevator lifting.

    Event_Elevator elevatorEvent;


	// Use this for initialization
	void Start () {
        elevatorEvent = transform.parent.GetComponent<Event_Elevator>();
	}
	

	// Update is called once per frame
	void Update () {
		
	}


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Input.GetKeyDown(KeyCode.Space)){
            elevatorEvent.isLifting = true;
        }
    }
}
