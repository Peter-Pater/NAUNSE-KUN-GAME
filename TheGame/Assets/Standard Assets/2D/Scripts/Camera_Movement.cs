using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour { // This scripts moves the camera

	// Scene state -- which scene the camera is currently in
    public int currentScene = General_SceneList.INSIDEKUN;

	// Scene object -- so that we can get scene info from these objects
	public GameObject insideKUN;
	public GameObject outsideKUN;
    public GameObject kunCoreRoom;
    public GameObject cave;
    public GameObject storeHouse;
	GameObject currentSceneObj;


	// Boarders that the camera will not move beyond.
	// They are contained in scene info.
    // They will change depending on the current scene
	float leftBoarder;
	float rightBoarder;
	float upBoarder;
	float downBoarder;
	float cameraWidth;
	float cameraHeight;


	public Transform playerTrans;
	public Vector3 offset; // the offset between player and the camera center
	public float smoothSpeed; // how fast the camera moves


    // When switching scenes, camera will be locked
    // so that it won't follow player.
    // It will instead be relocated by code. 
    bool isLocked = false;


	// Use this for initialization
	void Start () {

        // Put camera at the starting position.
        transform.position = new Vector3(198.3f, 1.6f, -10);
	}
	

	// Update is called once per frame
	void Update () {
		
        // Update the current scene and corresponding boarder info
		UpdateSceneObj();
		UpdateSceneInfo();


        if (!isLocked)
        {
            Vector3 desiredPos = GetDesiredPos(); // get the desired position that camera should move to

            // This Lerp function is used to smoothen camera move movement. 
            Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed * Time.deltaTime);
            transform.position = smoothedPos;
        }
	}


	void UpdateSceneObj(){
        if (currentScene == General_SceneList.INSIDEKUN){
			currentSceneObj = insideKUN;
        }else if (currentScene == General_SceneList.OUTSIDEKUN){
			currentSceneObj = outsideKUN;
        }else if (currentScene == General_SceneList.COREROOM){
            currentSceneObj = kunCoreRoom;
        }else if (currentScene == General_SceneList.CAVE){
            currentSceneObj = cave;
        }else if (currentScene == General_SceneList.STOREHOUSE){
            currentSceneObj = storeHouse;
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

        // The target position that camera is supposed to move to
		Vector3 targetPos = new Vector3(playerTrans.position.x, playerTrans.position.y, -10) + offset;


        // Check target position with boarders.
        // Trim the target position down if it exceeds the boarder.
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


    public void LockCamera(){
        isLocked = true;
    }


    public void UnlockCamera(){
        isLocked = false;
    }
}
