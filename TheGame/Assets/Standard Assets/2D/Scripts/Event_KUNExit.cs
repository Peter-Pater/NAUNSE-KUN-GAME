using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_KUNExit : MonoBehaviour { // This script moves up the exit door inside KUN.
    
    private float posY;
    private int CLOSED = 0;
    private int OPENED = 1;
    private int status;

    public bool upDownComplete;
    public float moveSpeed; //Assigned in the inspector


    // Use this for initialization
	void Start () {
        posY = transform.position.y;
        status = CLOSED;
        upDownComplete = false;
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void moveUp(){
        if (status == CLOSED){
            upDownComplete = false;
            float translation = Time.deltaTime;
            if ((transform.position.y - posY) <= GetComponent<SpriteRenderer>().bounds.size.y)
            {
                transform.Translate(moveSpeed * Vector2.up * translation);
            }else{
                status = OPENED;
                posY = transform.position.y;
            }    
        }

    }

    //public void moveDown(){
    //    if (status == OPENED){
    //        if (posY - transform.position.y <= GetComponent<SpriteRenderer>().bounds.size.y){
    //            float translation = Time.deltaTime;
    //            transform.Translate(Vector2.down * translation);        
    //        }else{
    //            status = CLOSED;
    //            posY = transform.position.y;
    //            upDownComplete = true;
    //        }

    //    }
    //}
}
