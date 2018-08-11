using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_SurvivorViewTrigger : MonoBehaviour { // This script changes camera view upon seeing survivor.

    public float targetSize;
    public Vector3 targetPos;

    public GameObject cameraObj;

	// Use this for initialization
	void Start () {
		
	}
	

	// Update is called once per frame
	void Update () {
		
	}


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player"){
            cameraObj.GetComponent<Camera_CustomizeView>().CustomizeView(targetSize, targetPos);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player"){
            cameraObj.GetComponent<Camera_CustomizeView>().BackToNormal();
        }
    }
}
