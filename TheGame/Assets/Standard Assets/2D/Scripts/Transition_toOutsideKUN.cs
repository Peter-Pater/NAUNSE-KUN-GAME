using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition_toOutsideKUN : MonoBehaviour {

    public GameObject cameraObj;
    public GameObject player;

    public Vector3 playerTargetPos;
    public Vector3 cameraTargetPos;


    bool isTransiting = false;
    bool isTransComplete = false;

    float curtainOpacity = 0;
    SpriteRenderer curtainRenderer;

	// Use this for initialization
	void Start () {
        curtainRenderer = cameraObj.transform.GetChild(0).GetComponent<SpriteRenderer>();
	}
	

	// Update is called once per frame
	void Update () {
		
        if (isTransiting){
            if (!isTransComplete){
                player.GetComponent<Player_Movement>().enabled = false;
                cameraObj.GetComponent<Camera_Movement>().LockCamera();

                if (curtainOpacity < 0.99f){
                    curtainOpacity += 0.01f;
                    curtainRenderer.color = new Color(curtainRenderer.color.r, curtainRenderer.color.g, curtainRenderer.color.b, curtainOpacity);
                }else{
                    player.transform.position = playerTargetPos;
                    cameraObj.transform.position = cameraTargetPos;
                    cameraObj.GetComponent<Camera_Movement>().currentScene = 1;
                    cameraObj.GetComponent<Camera_Movement>().UnlockCamera();
                    isTransComplete = true;
                }

            }else{
                if (curtainOpacity > 0.01f){
                    curtainOpacity -= 0.01f;
                    curtainRenderer.color = new Color(curtainRenderer.color.r, curtainRenderer.color.g, curtainRenderer.color.b, curtainOpacity);
                }else{
                    player.GetComponent<Player_Movement>().enabled = true;
                    isTransiting = false;
                    isTransComplete = false;
                }
            }
        }
	}


	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.tag == "Player"){
            isTransiting = true;
        }
	}
}
