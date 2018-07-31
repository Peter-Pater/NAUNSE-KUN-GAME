using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_Elevator : MonoBehaviour { // This script lifts the elevator.

    // Keep track of current state
    int DOWN = 0;
    int UP = 1;
    int currentState = 0;


    public bool isLifting = false;
    public float liftingSpeed;


    public GameObject player;
    public float targetHeight;
    GameObject rightWall;


    public AudioClip startSound;
    public AudioClip stopSound;
    AudioSource goingUpSoundPlayer;
    AudioSource elevatorTriggerPlayer;


	// Use this for initialization
	void Start () {
        rightWall = transform.GetChild(2).gameObject;
        goingUpSoundPlayer = transform.GetChild(0).GetComponent<AudioSource>();
        elevatorTriggerPlayer = GetComponent<AudioSource>();
	}


    // Update is called once per frame
    void Update()
    {
        UpdateRightWall();
        UpdateSound();

        if (isLifting && currentState == DOWN){
            if (transform.position.y < targetHeight){
                transform.position += liftingSpeed * Time.deltaTime * Vector3.up;
            }

            // Mark states when finished lifting.
            else{
                isLifting = false;
                PlayElevatorStopSound();
                currentState = UP;
            }
        }
    }


    // Solidate the right wall
    // so that player can't walk out of elevator
    // when lifting.
    void UpdateRightWall(){
        if (isLifting){
            rightWall.GetComponent<Collider2D>().isTrigger = false;
        }else{
            rightWall.GetComponent<Collider2D>().isTrigger = true;
        }
    }


    void UpdateSound(){
        if (isLifting){
            if (!goingUpSoundPlayer.isPlaying)
            {
                goingUpSoundPlayer.Play();
            }
        }else{
            goingUpSoundPlayer.Stop();
        }
    }


    public void PlayerElevatorStartSound(){
        if (elevatorTriggerPlayer.isPlaying){
            elevatorTriggerPlayer.Stop();
        }
        elevatorTriggerPlayer.clip = startSound;
        elevatorTriggerPlayer.Play();
    }


    void PlayElevatorStopSound()
    {
        if (elevatorTriggerPlayer.isPlaying)
        {
            elevatorTriggerPlayer.Stop();
        }
        elevatorTriggerPlayer.clip = stopSound;
        elevatorTriggerPlayer.Play();
    }
}
