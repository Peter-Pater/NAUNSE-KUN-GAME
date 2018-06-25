using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition_toOutsideKUN : MonoBehaviour {

    public GameObject cameraObj;
    public GameObject player;

    public Vector3 playerTargetPos;
    public Vector3 cameraTargetPos;


    bool isTransiting = false;
    bool isTransComplete = false;

	// Use this for initialization
	void Start () {
		
	}
	

	// Update is called once per frame
	void Update () {
		
        if (isTransiting){
            if (!isTransComplete){
                player.GetComponent<Player_Movement>().enabled = false;
            }
        }
	}


	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.tag == "Player"){
            isTransiting = true;
        }
	}
}
