using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_Cane : MonoBehaviour { // This script triggers player sliding down the cane.

    public GameObject player;

    public Vector3 startPos;
    public Vector3 targetPos;
    public float moveSpeed;

    bool isSlidingDown = false;


	// Use this for initialization
	void Start () {
		
	}
	

	// Update is called once per frame
	void Update () {

        UpdatePlayerAnimation();

        if (isSlidingDown){

            // Disable player control.
            // Disable gravity effect on player.
            player.GetComponent<Player_Movement>().LockControl();
            player.GetComponent<Rigidbody2D>().gravityScale = 0;


            // Use lerp to smoothly move player.
            player.transform.position = Vector3.Lerp(player.transform.position, targetPos, moveSpeed * Time.deltaTime);


            // Mark the end of sliding process.
            if (Vector3.Distance(player.transform.position, targetPos) < 0.5f){
                player.GetComponent<Player_Movement>().UnlockControl();
                player.GetComponent<Rigidbody2D>().gravityScale = 3;

                isSlidingDown = false;
            }
        }
	}


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Input.GetKeyDown(KeyCode.Space)){

            if (!isSlidingDown){
                player.transform.position = startPos;
                player.GetComponent<Player_Movement>().FlipLeft();
                isSlidingDown = true;
            }
        }
    }


    void UpdatePlayerAnimation(){
        if (isSlidingDown){
            player.GetComponent<Player_Animation>().StartClimbingCane();
        }else{
            player.GetComponent<Player_Animation>().StopClimbingCane();
        }
    }
}
