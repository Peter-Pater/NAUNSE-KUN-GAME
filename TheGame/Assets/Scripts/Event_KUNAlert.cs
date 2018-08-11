using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_KUNAlert : MonoBehaviour { // This script triggers KUN alert event.

    public GameObject player;
    Player_Movement playerMove;

    public GameObject cameraObj;
    Camera_CustomizeView cameraCustomize;


    public GameObject coreContainer;
    Event_CoreContainer ccEvent;


    public GameObject kunAlarm;
    SpriteRenderer kunAlarmSprite;
    AudioSource kunAlarmPlayer;


    public float targetViewSize;
    public Vector3 targetPos;
    public float waitTimeBeforeCutscene;
    public float cutsceneLastTime;


    bool isEventHappened = false;
    bool isCutsceneOn = false;


	// Use this for initialization
	void Start () {
        playerMove = player.GetComponent<Player_Movement>();
        cameraCustomize = cameraObj.GetComponent<Camera_CustomizeView>();
        ccEvent = coreContainer.GetComponent<Event_CoreContainer>();

        kunAlarmSprite = kunAlarm.GetComponent<SpriteRenderer>();
        kunAlarmPlayer = kunAlarm.GetComponent<AudioSource>();
	}
	

	// Update is called once per frame
	void Update () {

        UpdateAlertVolume();

        // When cutscene is on,
        if (isCutsceneOn){

            // Lock player control.
            playerMove.LockControl();
            waitTimeBeforeCutscene -= Time.deltaTime;

            if (waitTimeBeforeCutscene <= 0)
            {
                if (!kunAlarmPlayer.isPlaying)
                {
                    kunAlarmPlayer.Play(); // Play alarm sound.
                }

                // Move camera view.
                cameraCustomize.CustomizeView(targetViewSize, targetPos);

                // Alarm appears.
                if (kunAlarmSprite.color.a <= 0.99f)
                {
                    kunAlarmSprite.color += new Color(0, 0, 0, 0.7f * Time.deltaTime);
                }

                cutsceneLastTime -= Time.deltaTime;


                if (cutsceneLastTime <= 0)
                {
                    cameraCustomize.BackToNormal();
                    isEventHappened = true;
                    playerMove.UnlockControl();
                    isCutsceneOn = false;
                }
            }
        }
	}


	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.tag == "Player" && !isEventHappened){
            playerMove.Standstill();
            isCutsceneOn = true;
        }
	}


    void UpdateAlertVolume(){
        if (kunAlarmPlayer.isPlaying){
            if (ccEvent.isPuzzleTriggered){
                kunAlarmPlayer.volume = 0.1f;
            }else{
                kunAlarmPlayer.volume = 0.4f;
            }
        }
    }
}
