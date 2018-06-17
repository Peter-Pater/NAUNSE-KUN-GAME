using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour {

    private bool triggered = false;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp("space"))
        {
            triggered = true;
        }

        if (triggered == true){
            // change color of object
            GetComponent<SpriteRenderer>().material.color = Color.green;
            // refer to the door script, and call move up
            GameObject.FindGameObjectWithTag("LeftDoor").GetComponent<LeftDoorController>().moveUp();

            // refer to the door script, and call move down
            GameObject.FindGameObjectWithTag("LeftDoor").GetComponent<LeftDoorController>().moveDown();
            if (GameObject.FindGameObjectWithTag("LeftDoor").GetComponent<LeftDoorController>().upDownComplete == true){
                GetComponent<SpriteRenderer>().material.color = Color.white;
                triggered = false;    
            }
        }
	}

	//private void OnTriggerEnter2D(Collider2D other){
 //       if (other.gameObject.CompareTag("Player")){
 //           if (Input.GetKeyUp("space")){
 //               triggered = true;
 //           }
 //       }
	//}
}
