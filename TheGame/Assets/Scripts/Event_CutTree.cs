﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_CutTree : MonoBehaviour { // This script manages cutting tree event.

    public GameObject player;
    public GameObject treeRotatePoint;


    GameObject tree;
    Player_Animation playerAnimationControl;
    bool isTreeFalling = false;



    // This timer is used to temporarily
    // lock player control during
    // animation
    public float animFreezeTime;
    float freezeTimer;
    bool freezeTimerStart = false;


    void Start()
    {
        tree = treeRotatePoint.transform.GetChild(0).gameObject;
        playerAnimationControl = player.GetComponent<Player_Animation>();

        freezeTimer = animFreezeTime;
    }

    void Update()
    {
        if (isTreeFalling)
        {
            TreeFalls();
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

    void TreeFalls()
    {
        if (treeRotatePoint.transform.rotation.z > 0f){
            treeRotatePoint.transform.eulerAngles -= new Vector3(0, 0, 1.5f);
        }else{
            isTreeFalling = false;
            tree.GetComponent<Event_PushTree>().isCutDown = true;
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Input.GetKeyDown(KeyCode.Space)){
            if (player.GetComponent<Player_Items>().whatsInHand == General_ItemList.AXE){

                // Tree starts falling if player interacts with tree when axe is in hand. 
                player.GetComponent<Player_Items>().whatsInHand = General_ItemList.NONE;
                isTreeFalling = true;


                player.GetComponent<Player_Movement>().Standstill();
                tree.GetComponent<AudioSource>().Play(); // Play sound effect.
                playerAnimationControl.SetCutTree(); // Play cutting tree animation.
                freezeTimerStart = true;


                // Enable a collider so that tree can lie on the ground.
                treeRotatePoint.transform.GetChild(0).GetChild(0).GetComponent<Collider2D>().isTrigger = false;
            }
        }
    }

}
