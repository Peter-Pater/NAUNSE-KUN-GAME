using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Animation : MonoBehaviour {

    Animator myAnimator;

	// Use this for initialization
	void Start () {
        myAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void StartWalking(){
        myAnimator.SetBool("IsWalking", true);
        myAnimator.SetBool("IsClimbingCane", false);
        myAnimator.SetBool("IsTyping", false);
    }


    public void StopWalking(){
        myAnimator.SetBool("IsWalking", false);
    }


    public void StartClimbingCane(){
        myAnimator.SetBool("IsWalking", false);
        myAnimator.SetBool("IsClimbingCane", true);
        myAnimator.SetBool("IsTyping", false);
    }


    public void StopClimbingCane(){
        myAnimator.SetBool("IsClimbingCane", false);
    }


    public void StartTyping(){
        myAnimator.SetBool("IsWalking", false);
        myAnimator.SetBool("IsClimbingCane", false);
        myAnimator.SetBool("IsTyping", true);
    }


    public void StopTyping(){
        myAnimator.SetBool("IsTyping", false);
    }


    public void SetPick(){
        myAnimator.SetTrigger("SetPick");
    }


    public void SetPressButton(){
        myAnimator.SetTrigger("SetPressButton");
    }


    public void SetShakeTree(){
        myAnimator.SetTrigger("SetShakeTree");
    }

}
