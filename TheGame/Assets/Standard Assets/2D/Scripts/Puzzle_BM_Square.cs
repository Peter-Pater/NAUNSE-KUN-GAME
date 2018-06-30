using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle_BM_Square : MonoBehaviour { // This script manges color of a single square in the broken machine puzzle.

    // Define colors.
    // Keep track of the first color.
    int YELLOW = 0;
    int BLUE = 1;
    public int currentColor = 0;
    public int initialColor; // Assigned in the inspector.

    // Colors are assigned in the inspector.
    public Color yellow;
    public Color blue;

    SpriteRenderer mySpriteRenderer;


	// Use this for initialization
	void Start () {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        currentColor = initialColor;
	}
	

	// Update is called once per frame
	void Update () {
		
        // Fill in corresponding colors.
        if ((currentColor % 2) == YELLOW){
            mySpriteRenderer.color = yellow;
        }else if ((currentColor % 2) == BLUE){
            mySpriteRenderer.color = blue;
        }

	}


}
