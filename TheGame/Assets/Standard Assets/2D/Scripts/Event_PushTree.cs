using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_PushTree : MonoBehaviour { // This script manages pushing tree.

    public GameObject player;
    public GameObject treeRotatePoint;
    public bool isCutDown = false; // Keep track of whether the tree is cut down.

    bool isPlayerPushing = false;

    Rigidbody2D myRigidbody;
    Collider2D myCollider;


	// Use this for initialization
	void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update () {

        UpdateRigidbodyState();

        if (isPlayerPushing){
            myCollider.isTrigger = false;
            if (Input.GetKeyDown(KeyCode.RightArrow)){
                isPlayerPushing = false;
            }
        }else{
            myCollider.isTrigger = true;
        }
	}


    void UpdateRigidbodyState(){
        if (isCutDown)
        {
            myRigidbody.gravityScale = 1;
        }else{
            myRigidbody.gravityScale = 0;
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Input.GetKeyDown(KeyCode.Space)){
            if (isCutDown && !isPlayerPushing){
                player.transform.position = new Vector3(transform.position.x + 4, player.transform.position.y, player.transform.position.z);
                isPlayerPushing = true;
            }
        }
    }
}
