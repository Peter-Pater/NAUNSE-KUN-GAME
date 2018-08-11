using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment_CoreFloating : MonoBehaviour {

    float heightUp;
    float heightDown;
    float floatingSpd = 0.2f;

    int GOINGUP = 0;
    int GOINGDOWN = 1;
    int state = 0;


	// Use this for initialization
	void Start () {
        heightUp = transform.position.y + 0.1f;
        heightDown = transform.position.y - 0.1f;
	}
	
	// Update is called once per frame
	void Update () {
		
        if (state == GOINGUP){

            if (transform.position.y < heightUp){
                transform.position += Vector3.up * floatingSpd * Time.deltaTime;
            }else{
                state = GOINGDOWN;
            }
        }else if (state == GOINGDOWN){

            if (transform.position.y > heightDown){
                transform.position += Vector3.down * floatingSpd * Time.deltaTime;
            }else{
                state = GOINGUP;
            }
        }
	}
}
