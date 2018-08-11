using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle_CoreContainer_1 : MonoBehaviour
{ // This script is about the first puzzle at the core container.

    // Keep track of which square (in row and column #) the cursor is currently on.
    int currentRow = 0;
    int currentColumn = 0;


    GameObject[][] squareMatrix = new GameObject[4][]; // An array of all 16 squares
    GameObject[] squaresToBlink = new GameObject[6]; // An array of squares to blink at the beginning.
    GameObject currentSquareObj; // Keep track of the current gameObj.

    GameObject cursor;


    Event_CoreContainer ccEvent;
    float destroyDelay = 0.6f;


    public bool isPuzzleStarted = false;
    public float blinkDelay;
    public float blinkDuration;


    // Use this for initialization
    void Start()
    {

        // Initialize square array
        for (int i = 0; i < 4; i++){
            squareMatrix[i] = new GameObject[4];
        }

        for (int i = 0; i < 16; i++)
        {
            GameObject sqToAdd = transform.GetChild(i).gameObject;
            int rowNum = (int)i / (int)4;
            int columnNum = i % 4;
            squareMatrix[rowNum][columnNum] = sqToAdd;
        }


        // Initialize cursor
        cursor = transform.GetChild(16).gameObject;


        ccEvent = GameObject.FindWithTag("Puzzle3&4Trigger").GetComponent<Event_CoreContainer>();
    }


    // Update is called once per frame
    void Update()
    {
        if (!isPuzzleStarted)
        {
            blinkDelay -= Time.deltaTime;

            if (blinkDelay <= 0){
                SquareBlink();
            }
        }
        else
        {
            // Check if the puzzle is solved.
            bool isSolved = CheckWinningCondition();


            // If this puzzle is solved,
            // trigger the second puzzle.
            // Destory this puzzle.
            if (isSolved)
            {
                destroyDelay -= Time.deltaTime;

                if (destroyDelay <= 0)
                {
                    ccEvent.TriggerPuzzle2();
                    Destroy(this.gameObject);
                }

            }
            else
            {
                MoveCursor();
                ChangeColor();
            }
        }
    }


    // Use left, right, up, and down arrows to move cursor.
    void MoveCursor()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currentColumn > 0)
            {
                currentColumn -= 1;
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (currentColumn < 3)
            {
                currentColumn += 1;
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (currentRow > 0)
            {
                currentRow -= 1;
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (currentRow < 3)
            {
                currentRow += 1;
            }
        }

        UpdateCursorAndSqObj();
    }


    // Update cursor pos and the current square obj.
    void UpdateCursorAndSqObj(){
        currentSquareObj = squareMatrix[currentRow][currentColumn];
        cursor.transform.position = currentSquareObj.transform.position;
    }


    // Change color of squares when player presses space.
    void ChangeColor(){

        if (Input.GetKeyDown(KeyCode.Space)){

            // Change the color of current sq.
            currentSquareObj.GetComponent<Puzzle_CC1_Square>().currentColor += 1;

            // Change the color of the adjacent sq above.
            if (currentRow != 0){
                squareMatrix[currentRow - 1][currentColumn].GetComponent<Puzzle_CC1_Square>().currentColor += 1;
            }

            // Change the color of the adjacent sq below.
            if (currentRow != 3)
            {
                squareMatrix[currentRow + 1][currentColumn].GetComponent<Puzzle_CC1_Square>().currentColor += 1;
            }

            // Change the color of the adjacent sq on the left.
            if (currentColumn != 0)
            {
                squareMatrix[currentRow][currentColumn - 1].GetComponent<Puzzle_CC1_Square>().currentColor += 1;
            }

            // Change the color of the adjacent sq on the right.
            if (currentColumn != 3)
            {
                squareMatrix[currentRow][currentColumn + 1].GetComponent<Puzzle_CC1_Square>().currentColor += 1;
            }
        }
    }


    // Returns true only if all 16 squares are white (i.e. their currentColor % 2 == 0)
    bool CheckWinningCondition(){
        
        for (int i = 0; i < 4; i++){
            for (int j = 0; j < 4; j++){

                if ((squareMatrix[i][j].GetComponent<Puzzle_CC1_Square>().currentColor % 2) != 0){
                    return false;
                }
            }
        }

        return true;
    }


    void SquareBlink()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                squareMatrix[i][j].GetComponent<Puzzle_CC1_Square>().Blink();
            }
        }

        blinkDuration -= Time.deltaTime;
        if (blinkDuration <= 0){
            
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    squareMatrix[i][j].GetComponent<Puzzle_CC1_Square>().InitiateColor();
                }
            }
            isPuzzleStarted = true;
        }
    }
}
