using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle_Storehouse: MonoBehaviour {
    
    public Puzzle_SH_Rotate scriptR;
    public Puzzle_SH_Rotate scriptG;
	public Puzzle_SH_Rotate scriptB;
    public Event_StorehouseLock scriptE;
	
    public bool unlock = false;
	
	public GameObject preR;
	public GameObject preG;
	public GameObject preB;
	
    int buttonL = 0;
    int buttonD = 1;
    int buttonR = 2;
	
	public GameObject cursorPrefab;
	GameObject cursor;

	int currentButton = 0;
	GameObject currentButtonObj;
	public GameObject[] buttons;


    Event_StorehouseLock shEvent;


	// Use this for initialization
	void Start () {
		cursor = Instantiate(cursorPrefab) as GameObject;
        shEvent = GameObject.FindWithTag("Puzzle2Trigger").GetComponent<Event_StorehouseLock>();
	}
	
	// Update is called once per frame
	void Update () {
		MoveCursor();
		
	}
	
    void MoveCursor(){
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currentButton > 0)
            {
                currentButton -= 1;
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (currentButton < 2)
            {
                currentButton += 1;
            }
        }

        UpdateCursorAndSqObj();
    }
	
    void UpdateCursorAndSqObj(){
        if (currentButton == buttonL){
            cursor.transform.position = buttons[0].transform.position;
            currentButtonObj = buttons[0];
        }else if (currentButton == buttonD){
            cursor.transform.position = buttons[1].transform.position;
            currentButtonObj = buttons[1];
        }else if (currentButton == buttonR){
            cursor.transform.position = buttons[2].transform.position;
            currentButtonObj = buttons[2];
        }
		
		if (Input.GetKeyDown(KeyCode.Space)){
			currentButtonObj.SendMessage("ButtonMove");
		}
    }
	
	 bool CheckLock(){
        scriptR = preR.GetComponent<Puzzle_SH_Rotate>();
	 	int upper = scriptR.values[1];
        scriptG = preG.GetComponent<Puzzle_SH_Rotate>();
	 	int left = scriptG.values[2];
        scriptB = preB.GetComponent<Puzzle_SH_Rotate>();
		int right = scriptB.values[0];

        if (upper == 1 && left == 1 && right == 1)
        {
            shEvent.isPuzzleSolved = true;
            shEvent.isPuzzleTriggered = false;
            shEvent.UnlockPlayer();
            Destroy(this.gameObject);
            Destroy(GameObject.Find("cursor(Clone)"));
            return true;
        }
        else
        {
            return false;
        }
	}
}
