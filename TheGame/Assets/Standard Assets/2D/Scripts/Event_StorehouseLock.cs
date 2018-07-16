using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_StorehouseLock : MonoBehaviour { // This script triggers the triangle lock puzzle.

    // Keep track of puzzle states.
    // Assign puzzle1prefab through inspector.
    public bool isPuzzleTriggered = false;
    public bool isPuzzleSolved = false;
    public GameObject puzzlePrefab;

    public Transform cameraTrans;
    public GameObject player;
	public GameObject lockeDoor;


	// Use this for initialization
	void Start () {
		
	}


	// Update is called once per frame
	void Update () {

        if (isPuzzleSolved){
            lockeDoor.GetComponent<Collider2D>().isTrigger = true;
        }else{
            lockeDoor.GetComponent<Collider2D>().isTrigger = false;
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
                    player.GetComponent<Player_Movement>().LockControl();
                    GameObject puzzleObj = Instantiate(puzzlePrefab) as GameObject;
                    puzzleObj.transform.position = new Vector2(cameraTrans.position.x, cameraTrans.position.y);
                    isPuzzleTriggered = true;

                }
            }
        }
	}


    public void UnlockPlayer(){
        player.GetComponent<Player_Movement>().UnlockControl();
    }
}
