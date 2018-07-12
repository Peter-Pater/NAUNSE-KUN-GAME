using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckLock : MonoBehaviour {
    public Puzzle_TL_Rotate scriptR;
	public Puzzle_TL_Rotate scriptG;
	public Puzzle_TL_Rotate scriptB;
	public Event_TriLock scriptE;
	
    public bool unlock = false;
	
	public GameObject preR;
	public GameObject preG;
	public GameObject preB;
	
    int buttonL = 0;
    int buttonD = 1;
    int buttonR = 2;
	
	public GameObject cursor_;
	GameObject cursor;
	int currentButton = 0;
	GameObject currentButtonObj;
	public GameObject[] buttons;
	// Use this for initialization
	void Start () {
		cursor = Instantiate(cursor_) as GameObject;
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
	
	 bool checkLock(){
	 	scriptR = preR.GetComponent<Puzzle_TL_Rotate>();
	 	int upper = scriptR.values[1];
	 	print(upper);
	 	scriptG = preG.GetComponent<Puzzle_TL_Rotate>();
	 	int left = scriptG.values[2];
	 	print(left);
	 	scriptB = preB.GetComponent<Puzzle_TL_Rotate>();
		int right = scriptB.values[0];
		print(right);
		scriptE = GameObject.Find("AirwallPZ").GetComponent<Event_TriLock>();
		if (upper == 1 && left == 1 && right == 1){
			print("all 1");
			scriptE.isPuzzleSolved = true;
			return true;
	 	}
		else{
			print("not all 1");
		}
		return false;
	}
}
