using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_BrokenMachine : MonoBehaviour { // This script triggers the first puzzle and gets player the GEAR.

    // Keep track of puzzle states.
    // Assign puzzle1prefab through inspector.
    public bool isPuzzleTriggered = false;
    public bool isPuzzleSolved = false;
    public GameObject puzzlePrefab;

    public Transform cameraTrans;
    public GameObject player;
    Player_Animation playerAnimationControl;


    bool isGearObtained = false;
    AudioSource myAudioPlayer;


    // This timer is used to temporarily
    // lock player control during
    // animation
    public float animFreezeTime;
    float freezeTimer;
    bool freezeTimerStart = false;


	// Use this for initialization
	void Start () {
        myAudioPlayer = GetComponent<AudioSource>();
        playerAnimationControl = player.GetComponent<Player_Animation>();

        freezeTimer = animFreezeTime;
	}
	

	// Update is called once per frame
	void Update () {
       
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


	private void OnTriggerStay2D(Collider2D collision)
	{
        if (collision.tag == "Player"){
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (!isPuzzleTriggered && !isPuzzleSolved)
                {

                    // If player interacts for the first time,
                    // instantiate the puzzle at the center of the camera.
                    // Mark the state.
                    myAudioPlayer.Play();
                    player.GetComponent<Player_Movement>().LockControl();
                    GameObject puzzleObj = Instantiate(puzzlePrefab) as GameObject;
                    puzzleObj.transform.position = new Vector2(cameraTrans.position.x, cameraTrans.position.y);
                    isPuzzleTriggered = true;

                }
                else if (!isPuzzleTriggered && isPuzzleSolved && !isGearObtained)
                {

                    // When player interacts after solving the puzzle,
                    // obtain gear.
                    player.GetComponent<Player_Items>().whatsInHand = General_ItemList.GEAR;
                    Debug.Log("Gear obtained!");
                    isGearObtained = true;


                    myAudioPlayer.Play(); // Play sound effect.
                    playerAnimationControl.SetPick(); // Trigger animation.
                    freezeTimerStart = true; // Start short animation freeze.

                }
            }
        }
	}


    public void UnlockPlayer(){
        
        player.GetComponent<Player_Movement>().UnlockControl();
    }
}
