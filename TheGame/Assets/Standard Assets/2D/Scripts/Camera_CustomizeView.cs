using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_CustomizeView : MonoBehaviour { // This script triggers customized camera movement;

    float moveSpeed;
    float targetSize;
    float originalSize;
    Vector3 targetPos;

    bool isCustomizing = false;
    bool isUnlocking = false;
    Camera_Movement myMovement;
    Camera cam;


	// Use this for initialization
	void Start () {
        myMovement = GetComponent<Camera_Movement>();
        cam = GetComponent<Camera>();
	}
	

	// Update is called once per frame
	void Update () {
        
        moveSpeed = myMovement.smoothSpeed;
        originalSize = myMovement.viewSize;

        if (isCustomizing){
            myMovement.LockCamera();

            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetSize, moveSpeed * Time.deltaTime);
            transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);
        }else if (isUnlocking){
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, originalSize, moveSpeed * Time.deltaTime);

            if (Mathf.Abs(cam.orthographicSize - originalSize) <= 0.05f){
                myMovement.UnlockCamera();
                isUnlocking = false;
            }
        }
	}


    public void CustomizeView(float size, Vector3 pos){
        targetSize = size;
        targetPos = pos;
        isCustomizing = true;
    }


    public void BackToNormal(){
        isCustomizing = false;
        isUnlocking = true;
    }
}
