using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_Cane : MonoBehaviour { // This script triggers player sliding down the cane.

    public GameObject player;
    public GameObject groundToDestroy;
    public Vector3 targetPos;
    public float moveSpeed;

    bool isSlidingDown = false;


	// Use this for initialization
	void Start () {
		
	}
	

	// Update is called once per frame
	void Update () {
		
        if (isSlidingDown){

            // Disable the collider on the ground
            // so that player can slide down.
            groundToDestroy.GetComponent<Collider2D>().isTrigger = true;


            // Disable player control.
            // Disable gravity effect on player.
            player.GetComponent<Player_Movement>().enabled = false;
            player.GetComponent<Rigidbody2D>().gravityScale = 0;


            // Use lerp to smoothly move player.
            player.transform.position = Vector3.Lerp(player.transform.position, targetPos, moveSpeed * Time.deltaTime);


            // Mark the end of sliding process.
            if (Vector3.Distance(player.transform.position, targetPos) < 0.1f){
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
