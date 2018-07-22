using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_CutTree : MonoBehaviour { // This script manages cutting tree event.

    public GameObject player;
    public GameObject treeRotatePoint;


    GameObject tree;
    Player_Animation playerAnimationControl;
    bool isTreeFalling = false;



    void Start()
    {
        tree = treeRotatePoint.transform.GetChild(0).gameObject;
        playerAnimationControl = player.GetComponent<Player_Animation>();
    }

    void Update()
    {
        if (isTreeFalling)
        {
            TreeFalls();
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
                tree.GetComponent<AudioSource>().Play(); // Play sound effect.
                playerAnimationControl.SetCutTree();


                // Enable a collider so that tree can lie on the ground.
                treeRotatePoint.transform.GetChild(0).GetChild(0).GetComponent<Collider2D>().isTrigger = false;
            }
        }
    }

}
