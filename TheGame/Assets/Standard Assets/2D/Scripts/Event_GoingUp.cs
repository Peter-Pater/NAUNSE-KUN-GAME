using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_GoingUp : MonoBehaviour { // This script makes player go to the next level.

    public GameObject currentLevelGround; // Ground on the current level to disable.
    public GameObject upperLevelGround; // Ground on the next level to solidify.
    public GameObject airwallToDestroy; // Airwall on the current level to destroy. The airway is to prevent player from falling down on the lower level.
    public GameObject airwallToBuild; // Airwall on the next level to build. Sometimes used to prevent player from falling down from the level.

    public Vector3 playerTargetPos; // Where player is supposed to move to.


    public float goingUpSpeed;
    public GameObject player;

    bool isGoingUp = false;


    int DOWN = 0;
    int UP = 1;
    int state = 0;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if (isGoingUp){
            
            // When going up, get rid of player gravity scale
            // so that it won't fall for gravity.
            // Disable player control as well.
            player.GetComponent<Rigidbody2D>().gravityScale = 0;
            player.GetComponent<Player_Movement>().enabled = false;

            // Smooth move the player with Lerp.
            Vector3 targetPos = Vector3.Lerp(player.transform.position, playerTargetPos, goingUpSpeed * Time.deltaTime);
            player.transform.position = targetPos;

        }


        // When player has moved to the target pos
        if (Vector3.Distance(player.transform.position, playerTargetPos) <= 0.1f)
        {

            // Disable the airwall if there's any.
            if (airwallToDestroy != null){
                airwallToDestroy.GetComponent<Collider2D>().isTrigger = true;
            }

            // Enable the new airwall if there's any.
            if (airwallToBuild != null){
                airwallToBuild.GetComponent<Collider2D>().isTrigger = false;
            }

            // Disable ground on previous level if there's any.
            if (currentLevelGround != null)
            {
                currentLevelGround.GetComponent<Collider2D>().isTrigger = true;
            }

            // Solidify ground on this upper level if there's any.
            if (upperLevelGround != null)
            {
                upperLevelGround.GetComponent<Collider2D>().isTrigger = false;
            }

            // Mark the states.
            state = UP;
            isGoingUp = false;

            // "Free" the player.
            player.GetComponent<Rigidbody2D>().gravityScale = 3;
            player.GetComponent<Player_Movement>().enabled = true;
        }
            

	}


	private void OnTriggerStay2D(Collider2D collision)
	{
        if (collision.tag == "Player" && Input.GetKeyDown(KeyCode.UpArrow)){
            if (state != UP)
            {
                isGoingUp = true;
            }
        }
	}
}
