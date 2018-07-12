using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_GiantStoneRetrigger : MonoBehaviour { // This script makes gaint stone can be re-triggered. 

    public GameObject stoneTop;


	// Use this for initialization
	void Start () {
		
	}
	

	// Update is called once per frame
	void Update () {
		
	}


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player"){
            stoneTop.GetComponent<Collider2D>().isTrigger = true;
        }
    }
}
