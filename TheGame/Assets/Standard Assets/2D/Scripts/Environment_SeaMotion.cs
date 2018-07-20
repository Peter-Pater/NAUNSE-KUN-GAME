using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment_SeaMotion : MonoBehaviour {

    public Vector3 pos1;
    public Vector3 pos2;
    public float speedTo1;
    public float speedTo2;

    int GOINGTO2 = 0;
    int GOINGTO1 = 1;
    int state = 0;

    float counter = 0;


	// Use this for initialization
	void Start () {
		
	}
	

	// Update is called once per frame
	void Update () {

        Vector3 newPos = Vector3.Lerp(pos1, pos2, counter);
        transform.position = newPos;

        if (state == GOINGTO2){
            counter += speedTo2 * Time.deltaTime;
        }else{
            counter -= speedTo1 * Time.deltaTime;
        }

        if (counter > 1){
            counter = 1;
            state = GOINGTO1;
        }else if (counter < 0){
            counter = 0;
            state = GOINGTO2;
        }

	}
}
