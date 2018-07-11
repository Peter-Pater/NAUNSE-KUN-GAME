using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_Cane : MonoBehaviour { // This script triggers player sliding down the cane.

    public GameObject player;
    public Vector3 pos1;
    public Vector3 pos2;
    Vector3 targetPos;


    bool isSlidingDown = false;


    // Keep track of two phases of sliding.
    int PHASE1 = 0; // Phase 1 is player moving on to the cane from ground.
    int PHASE2 = 1; // Phase 2 is player moving down the cane.
    int currentPhase = 0;


    // Speeds for each phase.
    // Assigned in the inspector.
    public float speed1;
    public float speed2;
    float moveSpeed;


	// Use this for initialization
	void Start () {
		
	}
	

	// Update is called once per frame
	void Update () {
		
        if (isSlidingDown){

            // Disable player control.
            // Disable gravity effect on player.
            player.GetComponent<Player_Movement>().enabled = false;
            player.GetComponent<Rigidbody2D>().gravityScale = 0;


            // Set target pos and move speed based on phase.
            if (currentPhase == PHASE1)
            {
                targetPos = pos1;
                moveSpeed = speed1;
            }else if (currentPhase == PHASE2){
                targetPos = pos2;
                moveSpeed = speed2;
            }


            // Use lerp to smoothly move player.
            player.transform.position = Vector3.Lerp(player.transform.position, targetPos, moveSpeed * Time.deltaTime);


            // Mark the end of phase 1.
            if (Vector3.Distance(player.transform.position, pos1) < 0.1f){
                currentPhase = PHASE2;
            }


            // Mark the end of sliding process.
            if (Vector3.Distance(player.transform.position, pos2) < 0.1f){
                player.GetComponent<Player_Movement>().enabled = true;
                player.GetComponent<Rigidbody2D>().gravityScale = 3;

                isSlidingDown = false;
            }
        }
	}


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Input.GetKeyDown(KeyCode.Space)){

            if (!isSlidingDown){
                isSlidingDown = true;
            }
        }
    }
}
