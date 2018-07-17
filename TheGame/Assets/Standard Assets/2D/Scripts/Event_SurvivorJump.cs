using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_SurvivorJump : MonoBehaviour { // This script manages event of survivor falling.
    
	public GameObject treeBody;
	public GameObject survivor;

    Rigidbody2D survivorRigidbody;


	// Use this for initialization
	void Start () {
        survivorRigidbody = survivor.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "SurvivorTrigger"){
            treeBody.GetComponent<Event_PushTree>().isPushFinished = true;
			SurvivorJump();
		}
	}
	
	void SurvivorJump(){
        survivorRigidbody.AddForce(new Vector2(10, 10), ForceMode2D.Impulse);
	}
}
