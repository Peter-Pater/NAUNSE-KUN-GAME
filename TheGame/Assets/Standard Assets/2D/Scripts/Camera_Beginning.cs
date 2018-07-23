using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Camera_Beginning : MonoBehaviour { // This script manages beginning event.

    public Text title;
    public Text instructions;
    SpriteRenderer blackCurtain;

    public GameObject player;

    public float titleStayingTime;
    public float instructionStayingTime;


    int TITLE = 0;
    int INSTRUC = 1;
    int display = 0;


    bool isRevealingScreen = false;
    bool isPlayerAwake = false;
    bool isGameStart = false;


	// Use this for initialization
	void Start () {
        blackCurtain = transform.GetChild(0).GetComponent<SpriteRenderer>();

        player.GetComponent<Rigidbody2D>().gravityScale = 0;
        player.GetComponent<Player_Movement>().LockControl();
	}
	
	// Update is called once per frame
	void Update () {

        if (display == TITLE)
        {
            if (titleStayingTime > 0)
            {

                if (title.color.a <= 0.99f)
                {
                    title.color += new Color(0, 0, 0, 0.4f * Time.deltaTime);
                }
                else
                {
                    titleStayingTime -= Time.deltaTime;
                }
            }
            else
            {
                if (title.color.a >= 0.01f)
                {
                    title.color -= new Color(0, 0, 0, 0.4f * Time.deltaTime);
                }
                else
                {
                    display = INSTRUC;
                }
            }
        }
        else if (display == INSTRUC)
        {

            if (instructionStayingTime > 0)
            {
                if (instructions.color.a <= 0.99f)
                {
                    instructions.color += new Color(0, 0, 0, 0.4f * Time.deltaTime);
                }
                else
                {
                    instructionStayingTime -= Time.deltaTime;
                }
            }
            else
            {
                if (instructions.color.a >= 0.01f)
                {
                    instructions.color -= new Color(0, 0, 0, 0.4f * Time.deltaTime);
                }else{
                    isRevealingScreen = true;
                }
            }
        }


        if (isRevealingScreen){
            RevealScreen();
        }

	}


    void RevealScreen(){

        if (blackCurtain.color.a >= 0.01f){
            blackCurtain.color -= new Color(0, 0, 0, 0.4f * Time.deltaTime);
        }else{
            if (!isPlayerAwake)
            {
                player.GetComponent<Player_Animation>().SetWakeUp();
                isPlayerAwake = true;
            }
        }

        if (isPlayerAwake && Input.GetKeyDown(KeyCode.Space)){
            if (!isGameStart)
            {
                player.GetComponent<Player_Animation>().SetStandUp();
                player.GetComponent<Rigidbody2D>().gravityScale = 3;
                player.GetComponent<Player_Movement>().UnlockControl();

                isGameStart = true;
            }
        }
    }
}
