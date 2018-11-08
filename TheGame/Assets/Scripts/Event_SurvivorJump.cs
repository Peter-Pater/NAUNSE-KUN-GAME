using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_SurvivorJump : MonoBehaviour { // This script manages event of survivor falling.

    public GameObject player;
	public GameObject treeBody;
    public Transform survivorTrans;

    bool isCutsceneOn = false;
    bool isSurvivorJumped = false;
    bool isWaterSoundPlayed = false;


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

        if (isCutsceneOn)
        {
            freezeTimer -= Time.deltaTime;

            if (freezeTimer <= 3.5f)
            {
                SurvivorJump();
                isSurvivorJumped = true;
            }

            if (freezeTimer <= 0)
            {
                if (!isWaterSoundPlayed)
                {
                    GetComponent<AudioSource>().Play();
                    isWaterSoundPlayed = true;
                }

                player.GetComponent<Player_Movement>().UnlockControl();
                isCutsceneOn = false;
            }
        }


        //if (survivorTrans.position.y < 10f && !isWaterSoundPlayed){
        //    GetComponent<AudioSource>().Play();
        //    isWaterSoundPlayed = true;
        //}



	}
	
	void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "SurvivorTrigger" && !isSurvivorJumped){
            treeBody.GetComponent<Event_PushTree>().isPushFinished = true;
            player.GetComponent<Player_Animation>().StopPushingTree();
            player.GetComponent<Player_Movement>().LockControl();
            player.GetComponent<Player_Movement>().Standstill();
            isCutsceneOn = true;
		}
	}
	
	void SurvivorJump(){
        survivorTrans.GetComponent<Animator>().SetTrigger("SetJump");
	}
}
