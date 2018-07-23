using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour { // The script transit player and camera between scenes.

    public GameObject cameraObj;
    public GameObject player;


    // Scene and positions that Camera and player are supposed to be moved to.
    // Assigned in the inspector.
    public GameObject targetPosObj;
    public Vector3 cameraTargetPos;
    public int targetScene;


    // Keep track of transition state
    public bool isTransiting = false;
    public bool isRelocateComplete = false;


    float curtainOpacity = 0; // Used to change opacity of the black curtain in front of camera.
    SpriteRenderer curtainRenderer;


    // Get reference of two scene objs
    // in order to switch bgm.
    public GameObject currentSceneObj;
    public GameObject targetSceneObj;


	// Use this for initialization
	void Start () {
        curtainRenderer = cameraObj.transform.GetChild(0).GetComponent<SpriteRenderer>();
	}
	

	// Update is called once per frame
	void Update () {
		
        if (isTransiting){
            if (!isRelocateComplete){

                // Start transiting.
                // Disable player movement.
                // Lock camera.
                player.GetComponent<Player_Movement>().LockControl();
                cameraObj.GetComponent<Camera_Movement>().LockCamera();


                // Fade in the black curtain
                // so that camera view fades to black.
                if (curtainOpacity < 0.99f){
                    curtainOpacity += 0.01f;
                    curtainRenderer.color = new Color(curtainRenderer.color.r, curtainRenderer.color.g, curtainRenderer.color.b, curtainOpacity);
                }else{

                    // After camera view faded to black,
                    // relocate player and camera to the new position.
                    player.transform.position = targetPosObj.transform.position;
                    cameraObj.transform.position = cameraTargetPos;


                    // Change the current scene.
                    // Unlock camera so that it follows player again.
                    cameraObj.GetComponent<Camera_Movement>().currentScene = targetScene;
                    cameraObj.GetComponent<Camera_Movement>().UnlockCamera();

                    targetSceneObj.GetComponent<Scene_BGMManage>().PlayeBGM();

                    isRelocateComplete = true;
                }

            }else{

                // After completing relocating player and camera,
                // black curtain fades out so that camera view comes back.
                if (curtainOpacity > 0.01f){
                    curtainOpacity -= 0.01f;
                    curtainRenderer.color = new Color(curtainRenderer.color.r, curtainRenderer.color.g, curtainRenderer.color.b, curtainOpacity);
                }else{

                    // After camera view is back,
                    // reenable player movement.
                    // Transition complete.
                    player.GetComponent<Player_Movement>().UnlockControl();
                    isTransiting = false;
                    isRelocateComplete = false;
                }
            }
        }
	}


	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.tag == "Player"){
            player.GetComponent<Player_Movement>().LockControl();
            player.GetComponent<Player_Movement>().Standstill();
            currentSceneObj.GetComponent<Scene_BGMManage>().StopBGM();
            isTransiting = true;
        }
	}
}
