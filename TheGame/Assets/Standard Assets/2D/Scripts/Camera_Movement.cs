using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour {

    // the boarders of the current scene
    // initially assigned in the inspector
    // will change by code when switching scenes
    public float leftBoarder;
    public float rightBoarder;
    public float upBoarder;
    public float downBoarder;

    // keep track of the width and height of the camera view
    //initially assigned in the inspector
    // will change by code when camera zoom in/zoom out
    public float cameraWidth;
    public float cameraHeight;

    // keep track of whether the camera is locked
    // the camera is locked when switching scenes
    // so that it doesn't move according to player's position
    // (the camera will instead be relocated with code)
    public bool isLocked;

    public GameObject player;

    bool isRelocatingX = false;
    bool isRelocatingY = false;
    float relocateTimeX = 0f;
    float relocateTimeY = 0f;

    float targetPosX;
    float targetPosY;

    float distX;
    float distY;



	// Use this for initialization
	void Start () {
        transform.position = new Vector3(147, 0, -10);

        isLocked = false;
        targetPosX = 147;
        targetPosY = 0;
	}
	
	// Update is called once per frame
	void Update () {

        UpdateDist();


        if (!isLocked){
            if (!isRelocatingX)
            {
                if (distX >= (cameraWidth / 2) * (0.6f))
                {
                    targetPosX = transform.position.x + (1.2f) * (cameraWidth / 2);

                    if (targetPosX >= (rightBoarder - (cameraWidth / 2)))
                    {
                        targetPosX = rightBoarder - (cameraWidth / 2);
                    }
                }
                else if (distX <= (cameraWidth / 2) * (-0.6f))
                {
                    targetPosX = transform.position.x - (1.2f) * (cameraWidth / 2);

                    if (targetPosX <= (leftBoarder + (cameraWidth / 2)))
                    {
                        targetPosX = leftBoarder + (cameraWidth / 2);
                    }
                }

                if (targetPosX != transform.position.x){
                    isRelocatingX = true;
                }
            }


            RelocateCameraPosX();  
            
                       
            if (!isRelocatingY)
            {

                if (distY >= (cameraHeight / 4))
                {
                    targetPosY = transform.position.y + (cameraHeight / 2);

                    if (targetPosY >= (upBoarder - (cameraHeight / 2)))
                    {
                        targetPosY = upBoarder - (cameraHeight / 2);
                    }
                }
                else if (distY <= -(cameraHeight / 4))
                {
                    targetPosY = transform.position.y - (cameraHeight / 2);

                    if (targetPosY <= (downBoarder + (cameraHeight / 2)))
                    {
                        targetPosY = downBoarder + (cameraHeight / 2);
                    }
                }

                if (targetPosY != transform.position.y)
                {
                    isRelocatingY = true;
                }
            }

            RelocateCameraPosY();
        }
	}


    void UpdateDist(){
        distX = player.transform.position.x - transform.position.x;
        distY = player.transform.position.y - transform.position.y;
    }

    void RelocateCameraPosX(){

        if(isRelocatingX){
            float newPosX = Mathf.Lerp(transform.position.x, targetPosX, relocateTimeX);
            transform.position = new Vector3(newPosX, transform.position.y, transform.position.z);
            relocateTimeX += 0.008f;

            if (relocateTimeX > 1f)
            {
                relocateTimeX = 0f;
                isRelocatingX = false;
            }
        }


    }

    void RelocateCameraPosY()
    {

        if (isRelocatingY)
        {
            float newPosY = Mathf.Lerp(transform.position.y, targetPosY, relocateTimeY);
            transform.position = new Vector3(transform.position.x, newPosY, transform.position.z);
            relocateTimeY += 0.008f;

            if (relocateTimeY > 1f)
            {
                relocateTimeY = 0f;
                isRelocatingY = false;
            }
        }


    }



    float GetTargetPos(int xory){
        if (xory == 0){
            if (Mathf.Abs(transform.position.x - player.transform.position.x) <= 0.3f){
                return transform.position.x;
            }else{
                return player.transform.position.x;
            }
        }else{
            if (Mathf.Abs(transform.position.y - player.transform.position.y) <= 0.3f)
            {
                return transform.position.y;
            }
            else
            {
                return player.transform.position.y;
            }
        }
    }
}
