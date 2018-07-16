using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_StorehouseLadder : MonoBehaviour { // This script makes player go up ladder in storehouse.

    bool isPlayerClimbing = false;


    public GameObject player;
    public GameObject ladder;
    public Vector3 playerTargetPos;
    public float goingUpSpeed;


	// Use this for initialization
	void Start () {
        
	}
	

	// Update is called once per frame
	void Update () {
		
        if (isPlayerClimbing)
        {
            // When climbing up, get rid of player gravity scale
            // so that it won't fall for gravity.
            // Disable player control as well.
            player.GetComponent<Rigidbody2D>().gravityScale = 0;
            player.GetComponent<Player_Movement>().LockControl();

            // Smooth move the player with Lerp.
            Vector3 targetPos = Vector3.Lerp(player.transform.position, playerTargetPos, goingUpSpeed * Time.deltaTime);
            player.transform.position = targetPos;

            // When player has moved to the target pos
            if (Vector3.Distance(player.transform.position, playerTargetPos) <= 0.5f)
            {

                // Solidify ladder.
                ladder.GetComponent<Collider2D>().isTrigger = false;

                // "Free" the player.
                player.GetComponent<Rigidbody2D>().gravityScale = 3;
                player.GetComponent<Player_Movement>().UnlockControl();

                // Mark state.
                isPlayerClimbing = false;
            }
        }
	}


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (!isPlayerClimbing)
            {
                player.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0); // Stop current motion of player.
                isPlayerClimbing = true; // Start climbing.
            }                
        }
    }
}
