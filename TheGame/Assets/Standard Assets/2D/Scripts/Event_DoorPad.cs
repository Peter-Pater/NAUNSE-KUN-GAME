using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_DoorPad : MonoBehaviour {

    bool triggered = false;

    public GameObject kunExit; //Assign KUN exit game object to this variable in the inspector

    SpriteRenderer mySpriteRenderer;
    Event_KUNExit exitEventScript;

	// Use this for initialization
	void Start () {
        
        mySpriteRenderer = GetComponent<SpriteRenderer>();

        // refer to the exit event script
        exitEventScript = kunExit.GetComponent<Event_KUNExit>();
	}

    // Update is called once per frame
    void Update()
    {

        if (triggered == true)
        {
            // change color of object
            mySpriteRenderer.color = Color.green;

            // call move up
            exitEventScript.moveUp();

            // call move down
            //exitEventScript.moveDown();

            if (exitEventScript.upDownComplete == true)
            {
                mySpriteRenderer.color = Color.white;
                triggered = false;
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKey(KeyCode.Space)){
                triggered = true;
            }
        }
    }
}
