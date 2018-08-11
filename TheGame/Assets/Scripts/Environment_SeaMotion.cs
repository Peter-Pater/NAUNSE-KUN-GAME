using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment_SeaMotion : MonoBehaviour { // This script manages motions of tidal waves.

    public float startPosX;
    public float endPosX;
    public float moveSpeed;


	// Use this for initialization
	void Start () {
		
	}
	

	// Update is called once per frame
	void Update () {
        
        if (transform.position.x >= endPosX){
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }else{
            transform.position = new Vector3(startPosX, transform.position.y, transform.position.z);
        }

	}
}
