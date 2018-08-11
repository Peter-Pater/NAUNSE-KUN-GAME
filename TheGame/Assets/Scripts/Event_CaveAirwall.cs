using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_CaveAirwall : MonoBehaviour { // This script determines whether player can go through cave or not.

    public GameObject player;

    Collider2D myCollider2D;


	// Use this for initialization
	void Start () {
        myCollider2D = GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update () {

        // Let player go through if player holds flash light. Light up flash light too.
        // Otherwise block player.
        if (player.GetComponent<Player_Items>().whatsInHand == General_ItemList.FLASHLIGHT)
        {
            myCollider2D.isTrigger = true;
            player.transform.GetChild(0).GetComponent<Light>().intensity = 50;
        }else{
            myCollider2D.isTrigger = false;
            player.transform.GetChild(0).GetComponent<Light>().intensity = 0;
        }
	}
}
