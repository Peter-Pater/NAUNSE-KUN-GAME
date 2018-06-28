using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_PowerStation : MonoBehaviour {

    bool isRepaired = false;

    public float platformMovingSpeed;
    public float kunMovingSpeed;

    public Transform platformRotPoint;
    public Transform kunHead;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if (isRepaired){
            RotatePlatform();
            RotateAndMoveKUNHead();
        }
	}


	private void OnTriggerStay2D(Collider2D collision)
	{
        if (collision.tag == "Player" && collision.gameObject.GetComponent<Player_Items>().whatsInHand == General_ItemList.GEAR){
            if (Input.GetKeyDown(KeyCode.Space)){
                isRepaired = true;
            }
        }
	}


    void RotatePlatform(){
        platformRotPoint.rotation = Quaternion.Slerp(platformRotPoint.rotation, Quaternion.Euler(0, 0, 16), platformMovingSpeed * Time.deltaTime);
    }


    void RotateAndMoveKUNHead(){
        kunHead.rotation = Quaternion.Slerp(kunHead.rotation, Quaternion.Euler(0, 0, 0), kunMovingSpeed * Time.deltaTime);
        kunHead.position = Vector3.Lerp(kunHead.position, new Vector3(98, 1.3f, kunHead.position.z), kunMovingSpeed * Time.deltaTime);
    }
}
