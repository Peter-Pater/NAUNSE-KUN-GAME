using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_PowerStation : MonoBehaviour { // This script triggers events after repairing the power station

    // Repair state
    bool isRepairing = false;
    bool isRepaired = false;
    bool isStoneDropped = false;

    // Speed that each event happens at
    public float platformMovingSpeed;
    public float kunMovingSpeed;
    public float treeFallingSpeed;


    public Transform platformRotPoint;
    public Transform kunHead;
    public Transform treeRotPoint;
    public Transform giantStone;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        // Rotate the platform and move KUN head
        // when the power station is repaired.
        if (isRepairing){
            RotatePlatform();
            RotateAndMoveKUNHead();

            // Stone drops and tree falls
            // after platform and KUN head finish moving.
            if (kunHead.rotation.z <= 0.01f)
            {
                DropStone();
            }


            // Finish repairing process
            // after stone dropped.
            if (isStoneDropped){
                isRepairing = false;
                isRepaired = true;
            }
        }



	}


	private void OnTriggerStay2D(Collider2D collision)
	{

        // When player interacts with power station with GEAR in hand,
        // remove GEAR from hand and mark repaired.
        if (collision.tag == "Player" && collision.gameObject.GetComponent<Player_Items>().whatsInHand == General_ItemList.GEAR){
            if (Input.GetKeyDown(KeyCode.Space) && !isRepaired){
                collision.gameObject.GetComponent<Player_Items>().whatsInHand = General_ItemList.NONE;
                isRepairing = true;
            }
        }
	}


    // Smooth rotation for platform
    void RotatePlatform(){
        platformRotPoint.rotation = Quaternion.Slerp(platformRotPoint.rotation, Quaternion.Euler(0, 0, 16), platformMovingSpeed * Time.deltaTime);
    }


    // Smooth movement for KUN
    void RotateAndMoveKUNHead(){
        kunHead.rotation = Quaternion.Slerp(kunHead.rotation, Quaternion.Euler(0, 0, 0), kunMovingSpeed * Time.deltaTime);
        kunHead.position = Vector3.Lerp(kunHead.position, new Vector3(98, 1f, kunHead.position.z), kunMovingSpeed * Time.deltaTime);
    }


    // Relocate giant stone so that it drops.
    void DropStone(){
        if (!isStoneDropped){
            giantStone.position = new Vector3(32.89f, 9.4f, giantStone.position.z);
            isStoneDropped = true;
        }
    }


    // Smooth falling for tree
    void TreeFalls(){
        treeRotPoint.rotation = Quaternion.Slerp(treeRotPoint.rotation, Quaternion.Euler(0, 0, -130), treeFallingSpeed * Time.deltaTime);
    }
}
