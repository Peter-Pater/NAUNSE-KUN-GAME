using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle_CC1_Square : MonoBehaviour { // This script defines square properties in the first puzzle at core container.

    // Define colors.
    // Keep track of the first color.
    int WHITE = 0;
    int BLACK = 1;
    public int currentColor = 0;
    public int initialColor; // Assigned in the inspector.

    int blinkRate;
    float blinkDelay;
    float appearDelay;
    float appearSpeed;
    bool isAppeared = false;

    SpriteRenderer mySpriteRenderer;


	// Use this for initialization
	void Start () {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        blinkRate = Random.Range(5, 7);
        blinkDelay = Random.Range(0f, 0.45f);
        appearSpeed = Random.Range(1.2f, 1.5f);
        appearDelay = Random.Range(0f, 0.35f);

	}
	

	// Update is called once per frame
	void Update () {

        // Appear on screen.
        if (!isAppeared)
        {
            appearDelay -= Time.deltaTime;

            if (appearDelay <= 0)
            {
                IncreaseSize();
            }
        }

        if (transform.parent.GetComponent<Puzzle_CoreContainer_1>().isPuzzleStarted){
            // Fill in corresponding colors.
            FillColor();
        }
       

	}


    void IncreaseSize(){
        
        if (transform.localScale.x <= 0.99f){
            transform.localScale += new Vector3(appearSpeed, appearSpeed, 0) * Time.deltaTime;
        }else{
            transform.localScale = new Vector3(1, 1, 1);
            isAppeared = true;
        }
    }


    void FillColor(){
        if ((currentColor % 2) == WHITE)
        {
            mySpriteRenderer.color = Color.white;
        }
        else if ((currentColor % 2) == BLACK)
        {
            mySpriteRenderer.color = Color.black;
        }
    }


    public void Blink(){
        blinkDelay -= Time.deltaTime;

        if (blinkDelay <= 0)
        {
            if (Time.frameCount % (2 * blinkRate) == 0)
            {
                mySpriteRenderer.color = Color.black;
            }
            else if (Time.frameCount % blinkRate == 0)
            {
                mySpriteRenderer.color = Color.white;
            }
        }
    }


    public void InitiateColor(){
        currentColor = initialColor;
    }
}
