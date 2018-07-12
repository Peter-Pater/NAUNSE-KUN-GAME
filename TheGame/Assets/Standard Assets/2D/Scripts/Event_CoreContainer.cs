using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_CoreContainer : MonoBehaviour { // This script triggers the two puzzles at the core container.

    // Assign prefabs of the two puzzle in inspector
    public GameObject puzzle1Prefab;
    public GameObject puzzle2Prefab;


    public bool isPuzzleTriggered = false;
    public bool isContainerOpen = false;
    public bool isCoreInContainer = true;


    public Transform cameraTrans;
    public GameObject player;

    AudioSource myAudioPlayer;

	// Use this for initialization
	void Start () {
        myAudioPlayer = GetComponent<AudioSource>();	
	}
	

	// Update is called once per frame
	void Update () {
        UpdatePlayerControlState();
	}


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Input.GetKeyDown(KeyCode.Space)){

            // If player interacts with container for the first time
            // (i.e. the container is not open and puzzle is not triggered),
            // instantiate the puzzle.
            if (!isContainerOpen && !isPuzzleTriggered && isCoreInContainer){
                myAudioPlayer.Play();
                GameObject puzzle1Obj = Instantiate(puzzle1Prefab) as GameObject;
                puzzle1Obj.transform.position = new Vector2(cameraTrans.position.x, cameraTrans.position.y);
                isPuzzleTriggered = true;
            }


            // If player interactis with containers after puzzle solved,
            // player obtains the new core.
            if (isContainerOpen && !isPuzzleTriggered && isCoreInContainer){
                myAudioPlayer.Play();
                Debug.Log("New core obtained");
                player.GetComponent<Player_Items>().whatsInHand = General_ItemList.CORE;
                isCoreInContainer = false;
            }
        }
    }


    // Disable player control when puzzle is triggered
    // and reenable it otherwise.
    void UpdatePlayerControlState()
    {
        if (isPuzzleTriggered)
        {
            player.GetComponent<Player_Movement>().enabled = false;
        }
        else
        {
            player.GetComponent<Player_Movement>().enabled = true;
        }
    }


    public void TriggerPuzzle2(){
        GameObject puzzle2Obj = Instantiate(puzzle2Prefab) as GameObject;
        puzzle2Obj.transform.position = new Vector2(cameraTrans.position.x, cameraTrans.position.y);
    }
}
