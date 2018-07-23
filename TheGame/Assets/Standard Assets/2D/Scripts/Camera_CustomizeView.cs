using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_CustomizeView : MonoBehaviour { // This script triggers customized camera movement;

    float moveSpeed;
    float targetSize;
    float originalSize;
    Vector3 targetPos;


    SpriteRenderer cameraFrame;


    bool isCustomizing = false;
    Camera_Movement myMovement;
    Camera cam;


	// Use this for initialization
	void Start () {
        cameraFrame = transform.GetChild(1).GetComponent<SpriteRenderer>();

        myMovement = GetComponent<Camera_Movement>();
        cam = GetComponent<Camera>();
	}
	

	// Update is called once per frame
	void Update () {
        
        moveSpeed = myMovement.smoothSpeed;
        originalSize = myMovement.viewSize;

        if (isCustomizing){
            myMovement.LockCamera();

            // Frame disapears.
            cameraFrame.color = new Color(cameraFrame.color.r, cameraFrame.color.g, cameraFrame.color.b, 0f);


            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetSize, moveSpeed * Time.deltaTime);
            transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);
        }else {
            myMovement.UnlockCamera();

            // Frame fades back in.
            if (cameraFrame.color.a <= 0.99f)
            {
                cameraFrame.color += new Color(0, 0, 0, 0.1f * Time.deltaTime);
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
    }
}
