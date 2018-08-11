using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_AxeOnTheWall : MonoBehaviour { // This script makes player obtain axe.


    public GameObject player;
    Player_Animation playerAnimationControl;

    SpriteRenderer mySpriteRenderer;
    bool isAxeObtained = false;


    // This timer is used to temporarily
    // lock player control during
    // animation
    public float animFreezeTime;
    float freezeTimer;
    bool freezeTimerStart = false;


	// Use this for initialization
	void Start () {
        playerAnimationControl = player.GetComponent<Player_Animation>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();

        freezeTimer = animFreezeTime;
	}
	

	// Update is called once per frame
	void Update () {
		
        if (isAxeObtained){
            if (mySpriteRenderer.color.a >= 0.01f)
            {
                mySpriteRenderer.color -= new Color(0, 0, 0, 0.7f * Time.deltaTime);
            }
        }


        if (freezeTimerStart)
        {
            player.GetComponent<Player_Movement>().LockControl();

            freezeTimer -= Time.deltaTime;
            if (freezeTimer <= 0)
            {
                player.GetComponent<Player_Movement>().UnlockControl();
                freezeTimer = animFreezeTime;
                freezeTimerStart = false;
            }
        }
	}


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Input.GetKeyDown(KeyCode.Space)){
            if (!isAxeObtained)
            {
                freezeTimerStart = true;
                playerAnimationControl.SetPickAxe();
                player.GetComponent<Player_Items>().whatsInHand = General_ItemList.AXE;

                GetComponent<AudioSource>().Play();
                isAxeObtained = true;
            }
        }
    }
}
