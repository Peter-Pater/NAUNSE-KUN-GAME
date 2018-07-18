using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Animation : MonoBehaviour { // This script controls animation of all layers of player sprites.

    // All animation layers are simultaneously triggered. 
    Animator normalAnimator;
    Animator gearAnimator;
    Animator pickAnimator;
    Animator flashLightAnimator;
    Animator axeAnimator;
    Animator newCoreAnimator;


	// Use this for initialization
	void Start () {
        normalAnimator = transform.GetChild(1).GetComponent<Animator>();
        gearAnimator = transform.GetChild(2).GetComponent<Animator>();
        pickAnimator = transform.GetChild(3).GetComponent<Animator>();
        flashLightAnimator = transform.GetChild(4).GetComponent<Animator>();
        axeAnimator = transform.GetChild(5).GetComponent<Animator>();
        newCoreAnimator = transform.GetChild(6).GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void StartWalking(){
        normalAnimator.SetBool("IsWalking", true);
        normalAnimator.SetBool("IsClimbingCane", false);
        normalAnimator.SetBool("IsTyping", false);

        gearAnimator.SetBool("IsWalking", true);
        gearAnimator.SetBool("IsClimbingCane", false);
        gearAnimator.SetBool("IsTyping", false);
    }


    public void StopWalking(){
        normalAnimator.SetBool("IsWalking", false);

        gearAnimator.SetBool("IsWalking", false);
    }


    public void StartClimbingCane(){
        normalAnimator.SetBool("IsWalking", false);
        normalAnimator.SetBool("IsClimbingCane", true);
        normalAnimator.SetBool("IsTyping", false);

        gearAnimator.SetBool("IsWalking", false);
        gearAnimator.SetBool("IsClimbingCane", true);
        gearAnimator.SetBool("IsTyping", false);
    }


    public void StopClimbingCane(){
        normalAnimator.SetBool("IsClimbingCane", false);

        gearAnimator.SetBool("IsClimbingCane", false);
    }


    public void StartTyping(){
        normalAnimator.SetBool("IsWalking", false);
        normalAnimator.SetBool("IsClimbingCane", false);
        normalAnimator.SetBool("IsTyping", true);

        gearAnimator.SetBool("IsWalking", false);
        gearAnimator.SetBool("IsClimbingCane", false);
        gearAnimator.SetBool("IsTyping", true);
    }


    public void StopTyping(){
        normalAnimator.SetBool("IsTyping", false);

        gearAnimator.SetBool("IsTyping", false);
    }


    public void SetPick(){
        normalAnimator.SetTrigger("SetPick");

        gearAnimator.SetTrigger("SetPick");
    }


    public void SetPressButton(){
        normalAnimator.SetTrigger("SetPressButton");

        gearAnimator.SetTrigger("SetPressButton");
    }


    public void SetShakeTree(){
        normalAnimator.SetTrigger("SetShakeTree");

        gearAnimator.SetTrigger("SetShakeTress");
    }

}
