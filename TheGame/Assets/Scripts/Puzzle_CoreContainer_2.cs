using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle_CoreContainer_2 : MonoBehaviour { // This script is about the second puzzle at core container.

    GameObject[] staticObj = new GameObject[8];
    GameObject[] spinningObj = new GameObject[8];

    GameObject[] triggers = new GameObject[8];

    GameObject core;

    Event_CoreContainer ccEvent;

    // current square to match
    int current;

    // tracking puzzle progress;
    int counter;

    // order
    int[] order = { 0, 2, 1, 4, 3, 7, 6, 5 };

    int[] destroyed = new int[8];

    int spinSpeed;

    bool mergeTriggered = false;

    bool reseting = false;

    // The allowed residue of positioning
    float d1;

    // The count of failure, reset all if reaches three
    int failureCount = 0;

    int blinkCount = 0;

	// Use this for initialization
	void Start () {
        
        current = 0;
        counter = order[0];
        spinSpeed = 0;
        core = GameObject.FindWithTag("puzzle_core");

        for (int i = 0; i < 16; i++){
            if (i < 8){
                spinningObj[i] = transform.GetChild(i).gameObject;
            }else if (i < 16){
                triggers[i - 8] = transform.GetChild(i).gameObject;
                transform.GetChild(i).gameObject.GetComponent<Renderer>().enabled = false;
            }
        }

        for (int i = 0; i < 8; i++){
            staticObj[i] = core.transform.GetChild(i).gameObject;
        }


        d1 = (triggers[1].transform.position.x - (triggers[0].transform.position.x));

        //cursor = transform.GetChild(24).gameObject;

        ccEvent = GameObject.FindWithTag("Puzzle3&4Trigger").GetComponent<Event_CoreContainer>();

        UpdateCursorPosition(current, 0);

	}
	
	// Update is called once per frame
	void Update () {
        if (reseting){
            Blink();
            //Reset();
        }else{
            for (int i = 0; i < 8; i++)
            {
                spinningObj[i].transform.RotateAround(new Vector2(transform.position.x, transform.position.y), Vector3.forward, spinSpeed * Time.deltaTime);
                //staticObj[i].transform.RotateAround(new Vector2(transform.position.x, transform.position.y), Vector3.forward, -spinSpeed * Time.deltaTime * (float)0.8);
                if (destroyed[i] != 1)
                {
                    triggers[i].transform.RotateAround(new Vector2(transform.position.x, transform.position.y), Vector3.forward, -spinSpeed * Time.deltaTime * (float)0.8);
                }
            }
            core.transform.RotateAround(new Vector2(transform.position.x, transform.position.y), Vector3.forward, -spinSpeed * Time.deltaTime * (float)0.8);
            Match(); 
        }

        // Cheating code.
        //if (Input.GetKeyDown(KeyCode.C)){
        //    ccEvent.isPuzzleTriggered = false;
        //    ccEvent.isContainerOpen = true;
        //    ccEvent.puzzle2Restart = false;
        //    ccEvent.UnlockPlayer();
        //    mergeTriggered = false;
        //    //Debug.Log("Activated!");
        //    Destroy(this.gameObject);
        //}
	}


    void UpdateCursorPosition(int i, int j){
        if (counter > 0){
            spinningObj[j].transform.localScale -= new Vector3((float)0.05, (float)0.05, 1);   
        }
        spinningObj[i].transform.localScale += new Vector3((float) 0.05, (float) 0.05, 1);
    }


    void Match(){
        
        if (spinSpeed == 0){
            spinSpeed = 60;
        }else if (Input.GetKeyDown(KeyCode.Space) && !mergeTriggered){

            float x0 = spinningObj[current].transform.position.x;
            float y0 = spinningObj[current].transform.position.y;

            float x1 = (float)triggers[current].transform.position.x;
            float y1 = (float)triggers[current].transform.position.y;

            if (Mathf.Abs(x0 - x1) < d1 && Mathf.Abs(y0 - y1) < d1){
                destroyed[current] = 1;
                mergeTriggered = true;
                spinningObj[current].GetComponent<Renderer>().enabled = false;
                triggers[current].GetComponent<Renderer>().enabled = true;
                failureCount = 0;
            }else{
                if (counter > 0){
                    failureCount++;
                    if (failureCount == 3)
                    {
                        failureCount = 0;
                        //reseting = true;
                    }   
                }
            }

        }

        if (mergeTriggered){
            
            if (Mathf.Abs(staticObj[current].transform.position.x - triggers[current].transform.position.x) > 0.2f || Mathf.Abs(staticObj[current].transform.position.y - triggers[current].transform.position.y) > 0.2f){
                triggers[current].transform.position = Vector3.MoveTowards(triggers[current].transform.position, staticObj[current].transform.position, (Mathf.Abs(spinSpeed) / 4) * Time.deltaTime);
            }else{
                triggers[current].GetComponent<Renderer>().enabled = false;
                counter++;
                if (counter >= 8){
                    ccEvent.isPuzzleTriggered = false;
                    ccEvent.isContainerOpen = true;
                    ccEvent.puzzle2Restart = false;
                    ccEvent.UnlockPlayer();
                    mergeTriggered = false;
                    //Debug.Log("Activated!");
                    Destroy(this.gameObject);
                }else{
                    if (counter == 2){
                        spinSpeed = 80;
                    }else if (counter == 4){
                        spinSpeed = -100;
                    }else if (counter == 7){
                        spinSpeed = 150;
                    }
                    current = order[counter];
                    UpdateCursorPosition(current, order[counter - 1]);
                    mergeTriggered = false;   
                }
            }
        }

    }
   
    private void Blink(){
        if (blinkCount >= 3){
            ccEvent.puzzle2Restart = true;
            ccEvent.UnlockPlayer();
            Destroy(this.gameObject);
        }else{
            if (Time.frameCount % 15 == 0 && Time.frameCount % 30 == 0)
            {
                for (int i = 0; i < 8; i++)
                {
                    if (destroyed[i] == 0)
                    {
                        spinningObj[i].GetComponent<Renderer>().enabled = false;
                    }
                    staticObj[i].GetComponent<Renderer>().enabled = false;
                }
            }
            else if (Time.frameCount % 30 == 0)
            {
                for (int i = 0; i < 8; i++)
                {
                    if (destroyed[i] == 0)
                    {
                        spinningObj[i].GetComponent<Renderer>().enabled = true;
                    }
                    staticObj[i].GetComponent<Renderer>().enabled = true;
                }
                blinkCount++;
            }
        }
    }
}
