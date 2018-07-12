using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_TreeWithBody : MonoBehaviour { // This scripts gets player mountaineering pick from the body on the tree.
    
    public GameObject player;

    bool isPickObtained = false;

    AudioSource myAudioPlayer;

	// Use this for initialization
	void Start () {
        myAudioPlayer = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    // Player obtains the mountaineering pick when interacting with this tree.
	private void OnTriggerStay2D(Collider2D collision)
	{
        if (collision.tag == "Player" && Input.GetKeyDown(KeyCode.Space)){
            if (!isPickObtained)
            {
                myAudioPlayer.Play();
                player.GetComponent<Player_Items>().whatsInHand = General_ItemList.MOUNTAINEERINGPICK;
                Debug.Log("Mountaineering pick obtained!");
                isPickObtained = true;
            }
        }
	}
}
