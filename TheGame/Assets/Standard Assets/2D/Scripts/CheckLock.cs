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
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		// unlock = checkLock();
		// // print("Unlocked: ");
		// // print(unlock);
		// if (unlock){
		// 	print("Unlocked: ");
		// 	print(unlock);
		// 	scriptE.isPuzzleSolved = true;
		// }
		
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
		scriptE = GameObject.Find("Airwall").GetComponent<Event_TriLock>();
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
