using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_PeakWindow : MonoBehaviour { // This script triggers views from peak window.

    public GameObject player;
    public Transform camTrans;
    public GameObject viewPrefab;

    public Tutorial_Generic instruction;


    bool isViewTriggered = false;
    GameObject viewObj;
    Player_Movement playerMove;

	// Use this for initialization
	void Start () {
        playerMove = player.GetComponent<Player_Movement>();
	}
	

	// Update is called once per frame
	void Update () {
		
        if (viewObj != null){
            viewObj.transform.position = new Vector2(camTrans.position.x, camTrans.position.y);
        }
	}


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player"){

            if (!instruction.isAlreadyTriggered){
                instruction.ifDisplay = true;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                
                instruction.isAlreadyTriggered = true;
                instruction.ifDisplay = false;

                if (!isViewTriggered)
                {
                    playerMove.LockControl();
                    playerMove.Standstill();

                    viewObj = Instantiate(viewPrefab) as GameObject;
                    viewObj.transform.position = new Vector2(camTrans.position.x, camTrans.position.y);

                    isViewTriggered = true;
                }
                else
                {
                    Destroy(viewObj);
                    playerMove.UnlockControl();
                    isViewTriggered = false;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (instruction.ifDisplay)
            {
                instruction.ifDisplay = false;
            }
        }
    }
}
