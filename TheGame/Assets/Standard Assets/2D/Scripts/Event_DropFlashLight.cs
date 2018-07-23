using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_DropFlashLight : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player"){
            if (collision.GetComponent<Player_Items>().whatsInHand == General_ItemList.FLASHLIGHT){
                collision.GetComponent<Player_Items>().whatsInHand = General_ItemList.NONE;
                collision.GetComponent<Player_Animation>().SetReleaseFlashLight();
            }
        }
    }
}
