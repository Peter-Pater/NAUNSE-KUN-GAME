using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_DoorPad : MonoBehaviour { // This script opens the exit inside KUN.
    
    public GameObject kunExit; //Assign KUN exit game object to this variable in the inspector.
    public GameObject player;

    public Tutorial_Generic instruction;

    bool triggered = false;

    SpriteRenderer mySpriteRenderer;
    SpriteRenderer exitRenderer;
    //Event_KUNExit exitEventScript;


    // This timer is used to temporarily
    // lock player control during
    // animation
    public float animFreezeTime;
    float freezeTimer;
    bool freezeTimerStart = false;


	// Use this for initialization
	void Start () {
        
        mySpriteRenderer = GetComponent<SpriteRenderer>();

        exitRenderer = kunExit.GetComponent<SpriteRenderer>();

        // Initialize freeze timer
        freezeTimer = animFreezeTime;
	}


    // Update is called once per frame
    void Update()
    {
        
        if (triggered)
        {
            if (exitRenderer.color.a >= 0.01f){
                exitRenderer.color -= new Color(0, 0, 0, 0.7f * Time.deltaTime);
            }

            kunExit.GetComponent<Collider2D>().isTrigger = true;
        }


        if (freezeTimerStart){
            player.GetComponent<Player_Movement>().LockControl();

            freezeTimer -= Time.deltaTime;
            if (freezeTimer <= 0){
                player.GetComponent<Player_Movement>().UnlockControl();
                freezeTimer = animFreezeTime;
                freezeTimerStart = false;
            }
        }
    }


    // Trigger the event when player interacts with the door pad.
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (!instruction.isAlreadyTriggered){
                instruction.ifDisplay = true;
            }

            if (Input.GetKeyDown(KeyCode.Space) && !triggered){
                triggered = true;
                GetComponent<AudioSource>().Play();
                player.GetComponent<Player_Animation>().SetPressButton();
                freezeTimerStart = true;

                instruction.isAlreadyTriggered = true;
                instruction.ifDisplay = false;
            }
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player"){
            if (instruction.ifDisplay){
                instruction.ifDisplay = false;
            }
        }
    }
}
