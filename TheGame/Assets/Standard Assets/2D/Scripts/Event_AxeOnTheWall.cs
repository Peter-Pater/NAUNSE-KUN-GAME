using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_AxeOnTheWall : MonoBehaviour { // This script makes player obtain axe.

    public GameObject player;

    bool isAxeObtained = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Input.GetKeyDown(KeyCode.Space)){
            if (!isAxeObtained)
            {
                player.GetComponent<Player_Items>().whatsInHand = General_ItemList.AXE;
                Debug.Log("Axe obtained!");
                isAxeObtained = true;
            }
        }
    }
}
