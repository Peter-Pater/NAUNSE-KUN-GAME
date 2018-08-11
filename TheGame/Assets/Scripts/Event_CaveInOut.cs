using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_CaveInOut : MonoBehaviour { // This script sends player into cave.

    Transform cavePortal; // "Portal" that sends player to cave. 
    public float portalStayTime; // How long will portal stay there until it goes back up.


    public Vector3 portalPrevPos; // Portal's original position.
    bool timerStart = false;
    float portalTimer;


	// Use this for initialization
	void Start () {
        cavePortal = transform.GetChild(0);
        portalTimer = portalStayTime;
	}
	

	// Update is called once per frame
	void Update () {

        // Start counting down when timer is on.
        // Send portal back up again when time's up
        // so that player will be able to access it again next time.
        if (timerStart)
        {
            portalTimer -= Time.deltaTime;

            if (portalTimer <= 0)
            {
                cavePortal.position = portalPrevPos;
                portalTimer = portalStayTime;
                timerStart = false;
            }
        }

	}


	private void OnTriggerStay2D(Collider2D collision)
	{
        if (collision.tag == "Player" && Input.GetKeyDown(KeyCode.Space)){

            // When player interacts with cave,
            // move down the portal (which triggers transition when touching player)
            // so that player touches it.
            // Start the timer.
            cavePortal.position = transform.position;
            timerStart = true;
        }
	}
}
