using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_TriLock : MonoBehaviour { // This script triggers the triangle lock puzzle.

    // Keep track of puzzle states.
    // Assign puzzle1prefab through inspector.
    public bool isPuzzleTriggered = false;
    public bool isPuzzleSolved = false;
    public GameObject puzzlePrefab;

    public Transform cameraTrans;
    public GameObject player;
	// public GameObject preTL;

	// Use this for initialization
	void Start () {
		
	}
	// Update is called once per frame
	void Update () {
        UpdatePlayerControlState();
		// isPuzzleSolved = puzzlePrefab.GetComponent<CheckLock>().unlock;
		// Debug.Log("isPuzzleSolved: ");
		// Debug.Log(isPuzzleSolved);
		// temp = preTL.GetComponent<CheckLock>().unlock;
		// Debug.Log(temp);
	}


	private void OnTriggerStay2D(Collider2D collision)
	{
        if (collision.tag == "Player"){
			//Debug.Log("Player");
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (!isPuzzleTriggered && !isPuzzleSolved)
                {

                    // If player interacts for the first time,
                    // instantiate the puzzle at the center of the camera.
                    // Mark the state.
                    GameObject puzzleObj = Instantiate(puzzlePrefab) as GameObject;
                    puzzleObj.transform.position = new Vector2(cameraTrans.position.x, cameraTrans.position.y - 5);
                    isPuzzleTriggered = true;

                }
                else if (isPuzzleTriggered && isPuzzleSolved)
                {
                    Debug.Log("Lock already opened!");
                }
            }
        }
	}


    // Disable player control when puzzle is triggered
    // and reenable it otherwise.
    void UpdatePlayerControlState(){
        if (isPuzzleTriggered && !isPuzzleSolved){
            player.GetComponent<Player_Movement>().enabled = false;
        }else{
            player.GetComponent<Player_Movement>().enabled = true;
        }
    }
}
