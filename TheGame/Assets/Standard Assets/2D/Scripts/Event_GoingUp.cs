using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_GoingUp : MonoBehaviour { // This script makes player go to the next level.

    public GameObject currentLevelGround; // Ground on the current level to disable.
    public GameObject upperLevelGround; // Ground on the next level to solidify.
    public GameObject airwallToDestroy; // Airwall on the current level to destroy. The airway is to prevent player from falling down on the lower level.
    public GameObject airwallToBuild; // Airwall on the next level to build. Sometimes used to prevent player from falling down from the level.

    public Vector3 playerTargetPos; // Where player is supposed to move up to.
    public Vector3 playerOriginalPos; // Where player is supposed to move down to.

    public float goingUpSpeed;
    public GameObject player;

    bool isGoingUp = false;
    bool isGoingDown = false;


    int DOWN = 0;
    int UP = 1;
    int state = 0;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (isGoingUp)
        {
            GoUp();
        }
        else if (isGoingDown)
        {
            GoDown();
        }
	}


	private void OnTriggerStay2D(Collider2D collision)
	{
        if (collision.tag == "Player"){
            if (Input.GetKeyDown(KeyCode.UpArrow) && state != UP)
            {
                player.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
                isGoingUp = true;
            }else if (Input.GetKeyDown(KeyCode.DownArrow) && state != DOWN){
                player.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
                isGoingDown = true;
            }
        }
	}


    void GoUp(){
        
        // When going up, get rid of player gravity scale
        // so that it won't fall for gravity.
        // Disable player control as well.
        player.GetComponent<Rigidbody2D>().gravityScale = 0;
        player.GetComponent<Player_Movement>().enabled = false;

        // Smooth move the player with Lerp.
        Vector3 targetPos = Vector3.Lerp(player.transform.position, playerTargetPos, goingUpSpeed * Time.deltaTime);
        player.transform.position = targetPos;

        // When player has moved to the target pos
        if (Vector3.Distance(player.transform.position, playerTargetPos) <= 0.5f)
        {

            // Disable the airwall if there's any.
            if (airwallToDestroy != null)
            {
                airwallToDestroy.GetComponent<Collider2D>().isTrigger = true;
            }

            // Enable the new airwall if there's any.
            if (airwallToBuild != null)
            {
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


    void GoDown(){
        
        // When going down, get rid of player gravity scale
        // so that it won't fall for gravity.
        // Disable player control as well.
        player.GetComponent<Rigidbody2D>().gravityScale = 0;
        player.GetComponent<Player_Movement>().enabled = false;


        // ------------ This step is the exact opposite of going up!!! ---------
        // ------------ It has to be done before moving down!!! ----------------
        // Disable the airwall if there's any.
        if (airwallToBuild != null)
        {
            airwallToBuild.GetComponent<Collider2D>().isTrigger = true;
        }

        // Enable the new airwall if there's any.
        if (airwallToDestroy != null)
        {
            airwallToDestroy.GetComponent<Collider2D>().isTrigger = false;
        }

        // Disable ground on previous level if there's any.
        if (upperLevelGround != null)
        {
            upperLevelGround.GetComponent<Collider2D>().isTrigger = true;
        }

        // Solidify ground on this upper level if there's any.
        if (currentLevelGround != null)
        {
            currentLevelGround.GetComponent<Collider2D>().isTrigger = false;
        }


        // Smooth move the player with Lerp.
        Vector3 targetPos = Vector3.Lerp(player.transform.position, playerOriginalPos, goingUpSpeed * Time.deltaTime);
        player.transform.position = targetPos;

        // When player has moved to the target pos
        if (Vector3.Distance(player.transform.position, playerOriginalPos) <= 0.5f)
        {
            
            // Mark the states.
            state = DOWN;
            isGoingDown = false;

            // "Free" the player.
            player.GetComponent<Rigidbody2D>().gravityScale = 3;
            player.GetComponent<Player_Movement>().enabled = true;
        }
    }
}
