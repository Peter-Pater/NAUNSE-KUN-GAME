using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_HighWall : MonoBehaviour { // This script makes player climb up the high wall.

    // Keep track of climbing state
    bool isClimbing = false;
    bool isClimbingComplete = false;


    public float playerClimbingSpeed; // Assigned in the inspector


    // Get a reference to player.
    public GameObject player;
    Player_Items playerItem;


	// Use this for initialization
	void Start () {
        playerItem = player.GetComponent<Player_Items>();
	}
	

	// Update is called once per frame
	void Update () {
		
        if (isClimbing){

            // When climbing, get rid of player gravity scale
            // so that it won't fall for gravity.
            // Disable player control as well.
            player.GetComponent<Rigidbody2D>().gravityScale = 0;
            player.GetComponent<Player_Movement>().enabled = false;

            // Smooth climbing
            Vector3 targetPos = Vector3.Lerp(player.transform.position, new Vector3(60.99f, 20.76f, player.transform.position.z), playerClimbingSpeed * Time.deltaTime);
            player.transform.position = targetPos;
        }


        // When finishing climbing,
        // restore player gravity scale and reenable player control.
        // Mark the climbing states as well.
        if (Mathf.Abs(player.transform.position.x - 60.99f) <= 0.1f && Mathf.Abs(player.transform.position.y - 20.76f) <= 0.1f)
        {
            isClimbingComplete = true;
            player.GetComponent<Rigidbody2D>().gravityScale = 3;
            player.GetComponent<Player_Movement>().enabled = true;

            isClimbing = false;
        }

	}


    private void OnTriggerStay2D(Collider2D collision)	{
        if (collision.tag == "Player" && Input.GetKeyDown(KeyCode.Space)){
            if (playerItem.whatsInHand == General_ItemList.MOUNTAINEERINGPICK)
            {

                // When player interacts with high wall with mountaineering pick in hand,
                // remove mountaineering pick in hand and start climbing.
                if (!isClimbingComplete)
                {
                    playerItem.whatsInHand = General_ItemList.NONE;
                    isClimbing = true;
                }
            }
        }
	}
}
