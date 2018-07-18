using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_GiantStone : MonoBehaviour { // This script makes player climb up the giant stone.

    // Keep track of climbing states.
    bool isPlayerClimbing = false;

    // Reference to the top of the stone.
    GameObject stoneTop;


    public GameObject player;
    public float playerClimbingSpeed;


    AudioSource myAudioPlayer;


	// Use this for initialization
	void Start () {
        stoneTop = transform.parent.GetChild(0).gameObject;
        myAudioPlayer = GetComponent<AudioSource>();
	}
	

	// Update is called once per frame
	void Update () {
		
        if (isPlayerClimbing){

            // When climbing, get rid of player gravity scale
            // so that it won't fall for gravity.
            // Disable player control as well.
            player.GetComponent<Rigidbody2D>().gravityScale = 0;
            player.GetComponent<Player_Movement>().LockControl();

            // Smooth move the player with Lerp.
            Vector3 targetPos = Vector3.Lerp(player.transform.position, new Vector3(3.93f, 6.61f, player.transform.position.z), playerClimbingSpeed * Time.deltaTime);
            player.transform.position = targetPos;
        }


        // When player finished climbing,
        // solidify the top of the stone so that player can stand on the stone.
        // Restore player gravity scale and control.
        // Mark the states.
        if (Mathf.Abs(player.transform.position.y - 6.61f) <= 0.5f){
            //isClimbFinished = true;

            stoneTop.GetComponent<Collider2D>().isTrigger = false;

            player.GetComponent<Rigidbody2D>().gravityScale = 3;
            player.GetComponent<Player_Movement>().UnlockControl();

            isPlayerClimbing = false;
        }
	}


	private void OnTriggerStay2D(Collider2D collision)
	{
        if (collision.tag == "Player"){
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (!isPlayerClimbing)
                {
                    myAudioPlayer.Play(); // Play a climbing sound.
                    player.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0); // Stop current motion of player.
                    isPlayerClimbing = true; // Start climbing.
                }
            }
        }
	}
}
