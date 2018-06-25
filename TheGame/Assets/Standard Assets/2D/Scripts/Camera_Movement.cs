using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour {

	// scene state
	int INSIDEKUN = 0;
	int OUTSIDEKUN = 1;
	public int currentScene = 0;


	// scene object
	public GameObject insideKUN;
	public GameObject outsideKUN;
	GameObject currentSceneObj;


	// boarders that the camera will not move beyond
	// will change depending on the current scene
	float leftBoarder;
	float rightBoarder;
	float upBoarder;
	float downBoarder;
	float cameraWidth;
	float cameraHeight;

	// Use this for initialization
	void Start () {
		
	}
	

	// Update is called once per frame
	void Update () {
		
		UpdateSceneObj();
		UpdateSceneInfo();
	}


	void UpdateSceneObj(){
		if (currentScene == INSIDEKUN){
			currentSceneObj = insideKUN;
		}else if (currentScene == OUTSIDEKUN){
			currentSceneObj = outsideKUN;
		}
	}


	void UpdateSceneInfo(){
		Scene_Info targetInfo = currentSceneObj.GetComponent<Scene_Info>().

		leftBoarder = targetInfo.leftBoarder;
		rightBoarder = targetInfo.rightBoarder;
		upBoarder = targetInfo.upBoarder;
		downBoarder = targetInfo.downBoarder;
		cameraWidth = targetInfo.cameraWidth;
		cameraHeight = targetInfo.cameraHeight;
	}
}
