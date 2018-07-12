using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_ScreenShake : MonoBehaviour { // This script triggers screen shake.
    
    bool setShake = false;
    float shakeTimer;
    float shakeAmountX;
    float shakeAmountY;


	// Use this for initialization
	void Start () {
		
	}
	

	// Update is called once per frame
	void Update () {
		
        if (setShake){
            ShakeCamera();
        }
	}


    //Shake the camera when player releases rage to add effect
    void ShakeCamera()
    {
        if (shakeTimer >= 0)
        {
            // Find a random point in the circle,
            // shake the camera,
            // and decrease shake timer.
            Vector2 shakePosX = Random.insideUnitCircle * shakeAmountX;
            Vector2 shakePosY = Random.insideUnitCircle * shakeAmountY;
            transform.position = new Vector3(transform.position.x + shakePosX.x, transform.position.y + shakePosY.y, transform.position.z);
            shakeTimer -= Time.deltaTime;
        }else
        {
            setShake = false;
        }
    }


    public void StartShake(float time, float amountX, float amountY){
        shakeTimer = time;
        shakeAmountX = amountX;
        shakeAmountY = amountY;
        setShake = true;
    }
}
