using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_CoreContainer : MonoBehaviour { // This script triggers the two puzzles at the core container.

    // Assign prefabs of the two puzzle in inspector
    public GameObject puzzle1Prefab;
    public GameObject puzzle2Prefab;


    public bool isPuzzleTriggered = false;
    public bool isContainerOpen = false;
    public bool isCoreInContainer = true;
    public bool puzzle2Restart = false;


    public Transform cameraTrans;
    public GameObject player;

    AudioSource myAudioPlayer;
    Player_Animation playerAnimationControl;


    SpriteRenderer coreSprite;
    SpriteRenderer closedLayer;
    SpriteRenderer openLayer;


    GameObject puzzle1Obj;
    GameObject puzzle2Obj;


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

        coreSprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
        closedLayer = transform.GetChild(1).GetComponent<SpriteRenderer>();
        openLayer = transform.GetChild(2).GetComponent<SpriteRenderer>();


        freezeTimer = animFreezeTime;
	}
	

	// Update is called once per frame
	void Update () {

        RelocatePuzzles();

        if (isContainerOpen)
        {

            // Crossfade to open sprite
            // when container is open.
            if (closedLayer.color.a >= 0.01f)
            {
                closedLayer.color -= new Color(0, 0, 0, 0.7f * Time.deltaTime);
            }

            if (openLayer.color.a <= 0.99f)
            {
                openLayer.color += new Color(0, 0, 0, 0.7f * Time.deltaTime);
            }
        }


        if (!isCoreInContainer){

            if (coreSprite.color.a >= 0.01f){
                coreSprite.color -= new Color(0, 0, 0, 0.7f * Time.deltaTime);
            }
        }


        if (puzzle2Restart){
            puzzle2Restart = false;
            TriggerPuzzle2();
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

            // If player interacts with container for the first time
            // (i.e. the container is not open and puzzle is not triggered),
            // instantiate the puzzle.
            if (!isContainerOpen && !isPuzzleTriggered && isCoreInContainer){
                myAudioPlayer.Play();
                player.GetComponent<Player_Movement>().LockControl();

                puzzle1Obj = Instantiate(puzzle1Prefab) as GameObject;
                puzzle1Obj.transform.position = new Vector2(cameraTrans.position.x, cameraTrans.position.y);
                isPuzzleTriggered = true;
            }


            // If player interactis with containers after puzzle solved,
            // player obtains the new core.
            if (isContainerOpen && !isPuzzleTriggered && isCoreInContainer){
                player.GetComponent<Player_Items>().whatsInHand = General_ItemList.CORE;
                isCoreInContainer = false;

                myAudioPlayer.Play();
                playerAnimationControl.SetPickCore();
                freezeTimerStart = true;
            }
        }
    }


    public void UnlockPlayer()
    {
        player.GetComponent<Player_Movement>().UnlockControl();

    }


    public void TriggerPuzzle2(){
        puzzle2Obj = Instantiate(puzzle2Prefab) as GameObject;
        puzzle2Obj.transform.position = new Vector2(cameraTrans.position.x, cameraTrans.position.y);
    }


    void RelocatePuzzles(){
        if (puzzle1Obj != null)
        {
            puzzle1Obj.transform.position = new Vector2(cameraTrans.position.x, cameraTrans.position.y);
        }

        if (puzzle2Obj != null)
        {
            puzzle2Obj.transform.position = new Vector2(cameraTrans.position.x, cameraTrans.position.y);
        }
    }
}
