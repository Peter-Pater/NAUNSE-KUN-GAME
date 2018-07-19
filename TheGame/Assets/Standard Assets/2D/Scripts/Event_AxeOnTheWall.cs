using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_AxeOnTheWall : MonoBehaviour { // This script makes player obtain axe.

    public GameObject player;
    Player_Animation playerAnimationControl;

    bool isAxeObtained = false;

	// Use this for initialization
	void Start () {
        playerAnimationControl = player.GetComponent<Player_Animation>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Input.GetKeyDown(KeyCode.Space)){
            if (!isAxeObtained)
            {
                playerAnimationControl.SetPickAxe();
                player.GetComponent<Player_Items>().whatsInHand = General_ItemList.AXE;
                Debug.Log("Axe obtained!");
                isAxeObtained = true;
            }
        }
    }
}
