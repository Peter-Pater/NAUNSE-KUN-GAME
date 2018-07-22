using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_SurvivorJump : MonoBehaviour { // This script manages event of survivor falling.

    public GameObject player;
	public GameObject treeBody;
	public GameObject survivor;

    bool isCutsceneOn = false;
    bool isSurvivorJumped = false;


    // This timer is used to temporarily
    // lock player control during
    // cutscene.
    public float freezeTime;
    float freezeTimer;


	// Use this for initialization
	void Start () {
        freezeTimer = freezeTime;
	}
	
	// Update is called once per frame
	void Update () {
		
        if (isCutsceneOn){
            freezeTimer -= Time.deltaTime;

            if (freezeTimer <= 1.2f){
                SurvivorJump();
                isSurvivorJumped = true;
            }

            if (freezeTimer <= 0){
                player.GetComponent<Player_Movement>().UnlockControl();
                isCutsceneOn = false;
            }
        }
	}
	
	void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "SurvivorTrigger" && !isSurvivorJumped){
            treeBody.GetComponent<Event_PushTree>().isPushFinished = true;
            player.GetComponent<Player_Movement>().Standstill();
            player.GetComponent<Player_Movement>().LockControl();
            isCutsceneOn = true;
		}
	}
	
	void SurvivorJump(){
        survivor.GetComponent<Animator>().SetTrigger("SetJump");
	}
}
