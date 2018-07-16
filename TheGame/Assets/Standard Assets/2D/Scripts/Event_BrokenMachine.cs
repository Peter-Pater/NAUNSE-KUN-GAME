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



	// Use this for initialization
	void Start () {
        myAudioPlayer = GetComponent<AudioSource>();
        playerAnimationControl = player.GetComponent<Player_Animation>();
	}
	

	// Update is called once per frame
	void Update () {
       
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

                    // If player interacts after solving the puzzle,
                    // player obtains the GEAR.
                    // Mark the state.
                    myAudioPlayer.Play();
                    playerAnimationControl.SetPick();
                    player.GetComponent<Player_Items>().whatsInHand = General_ItemList.GEAR;
                    Debug.Log("Gear obtained!");
                    isGearObtained = true;
                }
            }
        }
	}


    public void UnlockPlayer(){
        
        player.GetComponent<Player_Movement>().UnlockControl();
    }
}
