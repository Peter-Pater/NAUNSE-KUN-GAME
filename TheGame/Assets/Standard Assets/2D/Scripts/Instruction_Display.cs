using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instruction_Display : MonoBehaviour { // This script determines what instruction an instruction obj to display.

    int SPACE = 0;
    int LEFTRIGHT = 1;
    int UP = 2;
    public int whatToDisplay;

    Animator myAnimationControl;


	// Use this for initialization
	void Start () {
        myAnimationControl = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
        if (whatToDisplay == SPACE){
            myAnimationControl.SetBool("IsSpace", true);
            myAnimationControl.SetBool("IsLeftRight", false);
            myAnimationControl.SetBool("IsUp", false);
        }else if (whatToDisplay == LEFTRIGHT){
            myAnimationControl.SetBool("IsSpace", false);
            myAnimationControl.SetBool("IsLeftRight", true);
            myAnimationControl.SetBool("IsUp", false);
        }else if (whatToDisplay == UP){
            myAnimationControl.SetBool("IsSpace", false);
            myAnimationControl.SetBool("IsLeftRight", false);
            myAnimationControl.SetBool("IsUp", true);
        }
	}
}
