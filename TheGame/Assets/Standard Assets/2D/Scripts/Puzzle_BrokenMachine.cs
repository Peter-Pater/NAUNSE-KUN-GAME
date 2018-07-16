using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle_BrokenMachine : MonoBehaviour { // This script is about the puzzle at the broken machine. 

    // Keep track of which square the cursor is currently on
    int SQUARE0 = 0;
    int SQUARE1 = 1;
    int SQUARE2 = 2;
    int currentSquare = 0;


    // Keep track of the currentSquareObj
    GameObject square0;
    GameObject square1;
    GameObject square2;
    GameObject currentSquareObj;

    GameObject cursor;


    int YELLOW = 0;
    int BLUE = 1;
    int[] correctAnswers;

    bool isCorrect = false;


    GameObject brokenMachine;
    Event_BrokenMachine bmEvent;


	// Use this for initialization
	void Start () {

        // Get reference to three squares and the cursor.
        square0 = gameObject.transform.GetChild(1).gameObject;
        square1 = gameObject.transform.GetChild(2).gameObject;
        square2 = gameObject.transform.GetChild(3).gameObject;
        cursor = gameObject.transform.GetChild(4).gameObject;


        //Load the correct answer.
        correctAnswers = new int[3];
        correctAnswers[0] = YELLOW;
        correctAnswers[1] = BLUE;
        correctAnswers[2] = YELLOW;


        // Initialize cursor to pointing at the first square.
        currentSquare = SQUARE0;


        // Get reference to the broken machine object and its event script
        brokenMachine = GameObject.FindWithTag("Puzzle1Trigger");
        bmEvent = brokenMachine.GetComponent<Event_BrokenMachine>();
	}
	

	// Update is called once per frame
	void Update () {

        MoveCursor();
        ChangeColor();

        isCorrect = CheckingAnswers();


        // If player gets the correct answer,
        // change puzzle states in broken machine
        // and destroy the puzzle obj.
        if(isCorrect){
            bmEvent.isPuzzleSolved = true;
            bmEvent.isPuzzleTriggered = false;
            bmEvent.UnlockPlayer();

            Destroy(this.gameObject);
        }

	}


    // Use left and right arrow to move the cursor.
    void MoveCursor(){
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currentSquare > 0)
            {
                currentSquare -= 1;
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (currentSquare < 2)
            {
                currentSquare += 1;
            }
        }

        UpdateCursorAndSqObj();
    }


    // Update the current square obj based on what square the cursor is pointing at.
    void UpdateCursorAndSqObj(){
        if (currentSquare == SQUARE0){
            cursor.transform.position = square0.transform.position;
            currentSquareObj = square0;
        }else if (currentSquare == SQUARE1){
            cursor.transform.position = square1.transform.position;
            currentSquareObj = square1;
        }else if (currentSquare == SQUARE2){
            cursor.transform.position = square2.transform.position;
            currentSquareObj = square2;
        }
    }


    // When pressing space, change the color of the current square.
    void ChangeColor(){
        if (Input.GetKeyDown(KeyCode.Space) && bmEvent.isPuzzleTriggered){
            currentSquareObj.GetComponent<Puzzle_BM_Square>().currentColor += 1;
        }
    }


    bool CheckingAnswers(){

        // Get the current answer from the three squares.
        int answer0 = (square0.GetComponent<Puzzle_BM_Square>().currentColor) % 2;
        int answer1 = (square1.GetComponent<Puzzle_BM_Square>().currentColor) % 2;
        int answer2 = (square2.GetComponent<Puzzle_BM_Square>().currentColor) % 2;

        // Check if the current answer is the same as the correct answer.
        if (answer0 != correctAnswers[0]){
            return false;
        }
        if (answer1 != correctAnswers[1]){
            return false;
        }
        if (answer2 != correctAnswers[2]){
            return false;
        }

        return true;
    }
}
