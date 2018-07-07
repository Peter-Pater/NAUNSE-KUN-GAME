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

    // Colors are assigned in the inspector.
    public Color white;
    public Color black;

    SpriteRenderer mySpriteRenderer;


	// Use this for initialization
	void Start () {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        currentColor = initialColor;
	}
	

	// Update is called once per frame
	void Update () {
        
        // Fill in corresponding colors.
        if ((currentColor % 2) == WHITE)
        {
            mySpriteRenderer.color = white;
        }
        else if ((currentColor % 2) == BLACK)
        {
            mySpriteRenderer.color = black;
        }

	}
}
