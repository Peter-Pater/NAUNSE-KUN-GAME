using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//The script for clicking the button
public class Puzzle_SH_Button : MonoBehaviour {
	
	// public Button buttonL, buttonR, buttonD;
	public GameObject preR;
	public GameObject preG;
	public GameObject preB;
	public GameObject prePuzzle;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	void ButtonMove() {
		string objectName = gameObject.name;
		if (objectName == "buttonL"){
			moveL();
		}
		else if (objectName == "buttonR"){
			moveR();
		}
		else if (objectName == "buttonD"){
			moveD();
		}
		// GameObject.Find("big").SendMessage("RotatePiece");
		prePuzzle.SendMessage("CheckLock");
		//GameObject.Find("big").SendMessage("checkLock");
	}
	
	void moveL(){
		// GameObject.Find("red").SendMessage("RotatePiece");
		// GameObject.Find("red").SendMessage("RotateValues");
		// GameObject.Find("green").SendMessage("RotatePiece");
		// GameObject.Find("green").SendMessage("RotateValues");
		preR.SendMessage("RotatePiece");
		preG.SendMessage("RotatePiece");
	}
	
	void moveR(){
		// GameObject.Find("red").SendMessage("RotatePiece");
		// GameObject.Find("red").SendMessage("RotateValues");
		// GameObject.Find("blue").SendMessage("RotatePiece");
		// GameObject.Find("blue").SendMessage("RotateValues");
		preR.SendMessage("RotatePiece");
		preB.SendMessage("RotatePiece");
		
		
	}
	
	void moveD(){
		// GameObject.Find("green").SendMessage("RotatePiece");
		// GameObject.Find("green").SendMessage("RotateValues");
		// GameObject.Find("blue").SendMessage("RotatePiece");
		// GameObject.Find("blue").SendMessage("RotateValues");
		preG.SendMessage("RotatePiece");
		preB.SendMessage("RotatePiece");

	}
	
}
