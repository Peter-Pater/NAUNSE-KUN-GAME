using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_BrokenMachine : MonoBehaviour { // This script triggers the first puzzle and gets player the GEAR.

    // Keep track of puzzle states.
    // Assign puzzle1prefab through inspector.
    public bool isPuzzleTriggered = false;
    public bool isPuzzleSolved = false;
    public GameObject puzzlePrefab;

    public Transform cameraTrans;
    public GameObject player;
    Player_Animation playerAnimationControl;


    GameObject puzzleObj;


    bool isGearObtained = false;
    AudioSource myAudioPlayer;


    public float crossfadeSpeed;

    SpriteRenderer lockedLayer;
    SpriteRenderer unlockedLayer;
    SpriteRenderer noGearLayer;


    // This timer is used to temporarily
    // lock player control during
    // animation
    public float animFreezeTime;
    float freezeTimer;
    bool freezeTimerStart = false;


	// Use this for initialization
	void Start () {
        myAudioPlayer = GetComponent<AudioSource>();
        playerAnimationControl = player.GetComponent<Player_Animation>();

        lockedLayer = transform.GetChild(0).GetComponent<SpriteRenderer>();
        unlockedLayer = transform.GetChild(1).GetComponent<SpriteRenderer>();
        noGearLayer = transform.GetChild(2).GetComponent<SpriteRenderer>();

        freezeTimer = animFreezeTime;
	}
	

	// Update is called once per frame
	void Update () {

        if (puzzleObj != null){
            puzzleObj.transform.position = new Vector2(cameraTrans.position.x, cameraTrans.position.y);
        }


        if (isGearObtained){

            // Crossfade to without gear sprite
            // when gear is obtained by player.
            if (unlockedLayer.color.a >= 0.01f){
                unlockedLayer.color -= new Color(0, 0, 0, crossfadeSpeed * Time.deltaTime);
            }
            if (noGearLayer.color.a <= 0.99f){
                noGearLayer.color += new Color(0, 0, 0, crossfadeSpeed * Time.deltaTime);
            }
        }else if(isPuzzleSolved){

            // Crossfade to unlocked sprite
            // when puzzle is solved.
            if (lockedLayer.color.a >= 0.01f)
            {
                lockedLayer.color -= new Color(0, 0, 0, crossfadeSpeed * Time.deltaTime);
            }
            if (unlockedLayer.color.a <= 0.99f)
            {
                unlockedLayer.color += new Color(0, 0, 0, crossfadeSpeed * Time.deltaTime);
            }
        }
       

        if (freezeTimerStart){
            player.GetComponent<Player_Movement>().LockControl();

            freezeTimer -= Time.deltaTime;
            if (freezeTimer <= 0){
                player.GetComponent<Player_Movement>().UnlockControl();
                freezeTimer = animFreezeTime;
                freezeTimerStart = false;
            }
        }
	}


	private void OnTriggerStay2D(Collider2D collision)
	{
        if (collision.tag == "Player"){
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (!isPuzzleTriggered && !isPuzzleSolved)
                {

                    // If player interacts for the first time,
                    // instantiate the puzzle at the center of the camera.
                    // Mark the state.
                    myAudioPlayer.Play();
                    player.GetComponent<Player_Movement>().LockControl();
                    player.GetComponent<Player_Movement>().Standstill();


                    puzzleObj = Instantiate(puzzlePrefab) as GameObject;
                    puzzleObj.transform.position = new Vector2(cameraTrans.position.x, cameraTrans.position.y);
                    isPuzzleTriggered = true;

                }
                else if (!isPuzzleTriggered && isPuzzleSolved && !isGearObtained)
                {
                    if (unlockedLayer.color.a >= 0.99f)
                    {
                        // When player interacts after solving the puzzle,
                        // obtain gear.
                        player.GetComponent<Player_Items>().whatsInHand = General_ItemList.GEAR;
                        Debug.Log("Gear obtained!");
                        isGearObtained = true;


                        myAudioPlayer.Play(); // Play sound effect.
                        playerAnimationControl.SetPickGear(); // Trigger animation.
                        freezeTimerStart = true; // Start short animation freeze.
                    }

                }
            }
        }
	}


    public void UnlockPlayer(){
        player.GetComponent<Player_Movement>().UnlockControl();
    }
}
