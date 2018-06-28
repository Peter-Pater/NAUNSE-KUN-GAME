using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_BrokenMachine : MonoBehaviour {

    public bool isPuzzleTriggered = false;
    public bool isPuzzleSolved = false;
    public GameObject puzzle1Prefab;

    public Transform cameraTrans;
    public GameObject player;


	// Use this for initialization
	void Start () {
		
	}
	

	// Update is called once per frame
	void Update () {
        UpdatePlayerControlState();
	}


	private void OnTriggerStay2D(Collider2D collision)
	{
        if (collision.tag == "Player"){
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (!isPuzzleTriggered && !isPuzzleSolved)
                {
                    GameObject puzzleObj = Instantiate(puzzle1Prefab) as GameObject;
                    puzzleObj.transform.position = new Vector2(cameraTrans.position.x, cameraTrans.position.y);
                    isPuzzleTriggered = true;

                }
                else if (!isPuzzleTriggered && isPuzzleSolved)
                {
                    player.GetComponent<Player_Items>().whatsInHand = General_ItemList.GEAR;
                    Debug.Log("Gear Obtained");

                }
            }
        }
	}


    void UpdatePlayerControlState(){
        if (isPuzzleTriggered){
            player.GetComponent<Player_Movement>().enabled = false;
        }else{
            player.GetComponent<Player_Movement>().enabled = true;
        }
    }
}
