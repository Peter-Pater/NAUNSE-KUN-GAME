using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_CaveNoReturn : MonoBehaviour { // This script prevents player from going back on slop in the cave.

    public Transform playerTrans;
    public GameObject cameraObj;

    Collider2D myCollider2D;


	// Use this for initialization
	void Start () {
        myCollider2D = GetComponent<Collider2D>();
	}
	

	// Update is called once per frame
	void Update () {
		
        // Once player passes this point in the cave,
        // there'll be no way to go back!!
        if (cameraObj.GetComponent<Camera_Movement>().currentScene == General_SceneList.CAVE){
            if ((transform.position.x - playerTrans.position.x) >= 1f){
                myCollider2D.isTrigger = false;
            }
        }

	}
}
