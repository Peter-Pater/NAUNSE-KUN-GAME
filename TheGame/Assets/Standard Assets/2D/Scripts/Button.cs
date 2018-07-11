using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//The script for clicking the button
public class Button : MonoBehaviour {
	
	// public Button buttonL, buttonR, buttonD;
	public GameObject preR;
	public GameObject preG;
	public GameObject preB;
	public GameObject prePuzzle;
	// Use this for initialization
	void Start () {
		// Button bL = buttonL.GetComponent<Button>();
		// Button bR = buttonR.GetComponent<Button>();
		// Button bD = buttonD.GetComponent<Button>();
		//
		// bL.onClick.AddListener(moveL);
		// bR.onClick.AddListener(moveR);
		// bD.onClick.AddListener(moveD);
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	void OnMouseDown() {
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
		prePuzzle.SendMessage("checkLock");
	}
	
	void moveL(){
		// GameObject.Find("red").SendMessage("RotatePiece");
		// GameObject.Find("red").SendMessage("RotateValues");
		// GameObject.Find("green").SendMessage("RotatePiece");
		// GameObject.Find("green").SendMessage("RotateValues");
		preR.SendMessage("RotatePiece");
		preR.SendMessage("RotateValues");
		preG.SendMessage("RotatePiece");
		preG.SendMessage("RotateValues");
	}
	
	void moveR(){
		// GameObject.Find("red").SendMessage("RotatePiece");
		// GameObject.Find("red").SendMessage("RotateValues");
		// GameObject.Find("blue").SendMessage("RotatePiece");
		// GameObject.Find("blue").SendMessage("RotateValues");
		preR.SendMessage("RotatePiece");
		preR.SendMessage("RotateValues");
		preB.SendMessage("RotatePiece");
		preB.SendMessage("RotateValues");
		
		
	}
	
	void moveD(){
		// GameObject.Find("green").SendMessage("RotatePiece");
		// GameObject.Find("green").SendMessage("RotateValues");
		// GameObject.Find("blue").SendMessage("RotatePiece");
		// GameObject.Find("blue").SendMessage("RotateValues");
		preG.SendMessage("RotatePiece");
		preG.SendMessage("RotateValues");
		preB.SendMessage("RotatePiece");
		preB.SendMessage("RotateValues");
		
	}
	
}
