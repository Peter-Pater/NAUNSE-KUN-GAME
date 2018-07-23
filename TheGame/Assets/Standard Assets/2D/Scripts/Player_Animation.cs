using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Animation : MonoBehaviour
{ // This script controls animation.

    Animator myAnimator;


    // Use this for initialization
    void Start()
    {
        myAnimator = transform.GetChild(1).GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void StartWalking()
    {
        myAnimator.SetBool("IsWalking", true);
        myAnimator.SetBool("IsClimbing", false);
        myAnimator.SetBool("IsClimbingCane", false);
        myAnimator.SetBool("IsTyping", false);
    }


    public void StopWalking()
    {
        myAnimator.SetBool("IsWalking", false);
    }


    public void StartClimbing()
    {
        myAnimator.SetBool("IsWalking", false);
        myAnimator.SetBool("IsClimbing", true);
        myAnimator.SetBool("IsClimbingCane", false);
        myAnimator.SetBool("IsTyping", false);
    }


    public void StopClimbing()
    {
        myAnimator.SetBool("IsClimbing", false);
    }


    public void StartPushingTree()
    {
        myAnimator.SetBool("IsPushingTree", true);
    }


    public void StopPushingTree()
    {
        myAnimator.SetBool("IsPushingTree", false);
        myAnimator.SetBool("IsWalking", true);

    }


    public void StartClimbingCane()
    {
        myAnimator.SetBool("IsWalking", false);
        myAnimator.SetBool("IsClimbing", false);
        myAnimator.SetBool("IsClimbingCane", true);
        myAnimator.SetBool("IsTyping", false);
    }


    public void StopClimbingCane()
    {
        myAnimator.SetBool("IsClimbingCane", false);
    }


    public void StartTyping()
    {
        myAnimator.SetBool("IsWalking", false);
        myAnimator.SetBool("IsClimbing", false);
        myAnimator.SetBool("IsClimbingCane", false);
        myAnimator.SetBool("IsTyping", true);
    }


    public void StopTyping()
    {
        myAnimator.SetBool("IsTyping", false);
    }


    public void StartLookingAtKUN(){
        myAnimator.SetBool("IsWalking", false);
        myAnimator.SetBool("IsClimbing", false);
        myAnimator.SetBool("IsClimbingCane", false);
        myAnimator.SetBool("IsTyping", false);
        myAnimator.SetBool("IsLookingAtKUN", true);
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


    public void SetPickGear(){
        myAnimator.SetTrigger("SetPickGear");
    }


    public void SetReleaseGear(){
        myAnimator.SetTrigger("SetReleaseGear");
    }


    public void SetPickPick(){
        myAnimator.SetTrigger("SetPickPick");
    }


    public void SetClimbHighWall(){
        myAnimator.SetTrigger("SetClimbHighWall");
    }


    public void SetPickFlashLight(){
        myAnimator.SetTrigger("SetPickFlashLight");
    }


    public void SetReleaseFlashLight(){
        myAnimator.SetTrigger("SetReleaseFlashLight");
    }


    public void SetPickAxe(){
        myAnimator.SetTrigger("SetPickAxe");
    }


    public void SetCutTree(){
        myAnimator.SetTrigger("SetCutTree");
    }


    public void SetPickCore()
    {
        myAnimator.SetTrigger("SetPickCore");
    }


    public void SetReleaseCore()
    {
        myAnimator.SetTrigger("SetReleaseCore");
    }


    public void SetSitDown(){
        myAnimator.SetTrigger("SetSitDown");
    }

}
