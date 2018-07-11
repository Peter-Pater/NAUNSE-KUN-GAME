using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle_CoreContainer_2 : MonoBehaviour { // This script is about the second puzzle at core container.

    GameObject[] staticObj = new GameObject[8];
    GameObject[] spinningObj = new GameObject[8];

    GameObject[] triggers = new GameObject[8];

    GameObject cursor;

    Event_CoreContainer ccEvent;

    Vector3[] triggerPos = new Vector3[8];

    // current square to match
    int current;

    // tracking puzzle progress;
    int counter;

    // order
    int[] order = { 0, 2, 1, 4, 3, 7, 6, 5 };

    int[] destroyed = new int[8];

    int spinSpeed;

    bool mergeTriggered = false;

    // The allowed residue of positioning
    float d1;

    // The count of failure, reset all if reaches three
    int failureCount = 0;

	// Use this for initialization
	void Start () {
        
        current = 0;
        counter = order[0];
        spinSpeed = 0;

        for (int i = 0; i < 24; i++){
            if (i < 8){
                destroyed[i] = 0;
                staticObj[i] = transform.GetChild(i).gameObject;
                //Debug.Log(transform.GetChild(i).gameObject.name);
            }else if (i < 16){
                spinningObj[i - 8] = transform.GetChild(i).gameObject;
                //Debug.Log(spinningObj[i - 8].name);
            }else{
                triggers[i - 16] = transform.GetChild(i).gameObject;
                triggerPos[i - 16] = triggers[i - 16].transform.position;
                transform.GetChild(i).gameObject.GetComponent<Renderer>().enabled = false;
            }
        }

        d1 = (triggers[1].transform.position.x - (triggers[0].transform.position.x)) / 2;

        cursor = transform.GetChild(24).gameObject;

        ccEvent = GameObject.FindWithTag("Puzzle3&4Trigger").GetComponent<Event_CoreContainer>();

        UpdateCursorPosition(current, 0);

	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < 8; i++){
                spinningObj[i].transform.RotateAround(new Vector2(transform.position.x, transform.position.y), Vector3.forward, spinSpeed * Time.deltaTime);   
        }
        Match();
	}

    void UpdateCursorPosition(int i, int j){
        //cursor.transform.position = staticObj[i].transform.position;
        if (counter > 0){
            staticObj[j].transform.localScale -= new Vector3((float)0.015, (float)0.015, 1);   
        }
        staticObj[i].transform.localScale += new Vector3((float) 0.015, (float) 0.015, 1);
    }

    void Match(){

        if (spinSpeed == 0){
            spinSpeed = 80;
        }else if (Input.GetKeyDown(KeyCode.Space) && !mergeTriggered){

            float x0 = spinningObj[current].transform.position.x;
            float y0 = spinningObj[current].transform.position.y;

            float x1 = (float)triggers[current].transform.position.x;
            float y1 = (float)triggers[current].transform.position.y;

            if (Mathf.Abs(x0 - x1) < d1 && Mathf.Abs(y0 - y1) < d1){
                destroyed[current] = 1;
                mergeTriggered = true;
                //Destroy(spinningObj[current]);
                spinningObj[current].GetComponent<Renderer>().enabled = false;
                //spinningObj[current].GetComponent<Renderer>().material.color = new Color(1, 1, 1);
                triggers[current].GetComponent<Renderer>().enabled = true;
                failureCount = 0;
            }else{
                if (counter > 0){
                    failureCount++;
                    if (failureCount == 3)
                    {
                        failureCount = 0;
                        Reset();
                    }   
                }
            }

        }

        if (mergeTriggered){

            if (Mathf.Abs(staticObj[current].transform.position.x - triggers[current].transform.position.x) > 0.05 || Mathf.Abs(staticObj[current].transform.position.y - triggers[current].transform.position.y) > 0.05){
                triggers[current].transform.Translate(new Vector2(staticObj[current].transform.position.x - triggers[current].transform.position.x, staticObj[current].transform.position.y - triggers[current].transform.position.y) * Time.deltaTime * 5);
            }else{
                //Destroy(triggers[current]);
                triggers[current].GetComponent<Renderer>().enabled = false;
                counter++;
                if (counter >= 8){
                    ccEvent.isPuzzleTriggered = false;
                    ccEvent.isContainerOpen = true;
                    mergeTriggered = false;
                    //Debug.Log("Activated!");
                    Destroy(this.gameObject);
                }else{
                    if (counter == 2){
                        spinSpeed = 120;
                    }else if (counter == 4){
                        spinSpeed = -160;
                    }else if (counter == 7){
                        spinSpeed = 200;
                    }
                    current = order[counter];
                    //Debug.Log(current);
                    UpdateCursorPosition(current, order[counter - 1]);
                    mergeTriggered = false;   
                }
            }
        }

    }

	private void Reset()
	{
        for (int i = 0; i < 8; i++){
            if (destroyed[i] == 1){
                spinningObj[i].GetComponent<Renderer>().enabled = true;
                triggers[i].transform.position = triggerPos[i];
                destroyed[i] = 0;
            }
        }
        UpdateCursorPosition(0, current);
        counter = 0;
        current = 0;
        spinSpeed = 80;
	}
}
