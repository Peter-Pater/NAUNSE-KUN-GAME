using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_KUNAlert : MonoBehaviour { // This script triggers KUN alert event.

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.tag == "Player" ){
            
        }
	}
}
