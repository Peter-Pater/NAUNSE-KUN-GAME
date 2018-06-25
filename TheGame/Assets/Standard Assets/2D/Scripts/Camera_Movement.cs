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


	public Transform playerTrans;
	public Vector3 offset;
	public float smoothSpeed;

	// Use this for initialization
	void Start () {
        transform.position = new Vector3(144.1f, 1.6f, -10);
	}
	

	// Update is called once per frame
	void Update () {
		
		UpdateSceneObj();
		UpdateSceneInfo();

		Vector3 desiredPos = GetDesiredPos();
        Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed);
        transform.position = smoothedPos;
	}


	void UpdateSceneObj(){
		if (currentScene == INSIDEKUN){
			currentSceneObj = insideKUN;
		}else if (currentScene == OUTSIDEKUN){
			currentSceneObj = outsideKUN;
		}
	}


	void UpdateSceneInfo(){
        Scene_Info targetInfo = currentSceneObj.GetComponent<Scene_Info>();

		leftBoarder = targetInfo.leftBoarder;
		rightBoarder = targetInfo.rightBoarder;
		upBoarder = targetInfo.upBoarder;
		downBoarder = targetInfo.downBoarder;
		cameraWidth = targetInfo.cameraWidth;
		cameraHeight = targetInfo.cameraHeight;
	}


	Vector3 GetDesiredPos(){
		Vector3 targetPos = new Vector3(playerTrans.position.x, playerTrans.position.y, -10) + offset;

		if (targetPos.x > (rightBoarder - (cameraWidth / 2))){
			targetPos = new Vector3(rightBoarder - (cameraWidth / 2), targetPos.y, targetPos.z);
		}else if (targetPos.x < (leftBoarder + (cameraWidth / 2))){
			targetPos = new Vector3(leftBoarder + (cameraWidth / 2), targetPos.y, targetPos.z);
		}

		if (targetPos.y > (upBoarder - (cameraHeight / 2))){
			targetPos = new Vector3(targetPos.x, upBoarder - (cameraHeight / 2), targetPos.z);
		}else if (targetPos.y < (downBoarder + (cameraHeight / 2))){
			targetPos = new Vector3(targetPos.x, downBoarder + (cameraHeight / 2), targetPos.z);
		}

		return targetPos;
	}
}
