using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_PushTree : MonoBehaviour { // This script manages pushing tree.

    public GameObject player;
    public GameObject treeRotatePoint;
    public GameObject airwallInTheWall;
    public bool isCutDown = false; // Keep track of whether the tree is cut down.

    public bool isPlayerPushing = false;
    public bool isPushFinished = false; // Keep track of whether the tree is pushed to destination.

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

        if (isPushFinished){
            isPlayerPushing = false;
            //player.GetComponent<Player_Animation>().StopPushingTree();
            myRigidbody.velocity = new Vector3(0, 0, 0);
        }

        if (isPlayerPushing){
            airwallInTheWall.GetComponent<Collider2D>().isTrigger = true;
            myCollider.isTrigger = false;
            if (Input.GetKeyDown(KeyCode.RightArrow)){
                player.GetComponent<Player_Animation>().StopPushingTree();
                isPlayerPushing = false;
            }
        }else{
            airwallInTheWall.GetComponent<Collider2D>().isTrigger = false;
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
            if (isCutDown && !isPlayerPushing && !isPushFinished){
                player.transform.position = new Vector3(transform.position.x + 5.5f, player.transform.position.y, player.transform.position.z);
                player.GetComponent<Player_Movement>().FlipLeft();
                player.GetComponent<Player_Animation>().StartPushingTree();
                isPlayerPushing = true;
            }
        }
    }
}
