using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_Beginning : MonoBehaviour { // This script manages tutorial display at the beginning of the game.

    public SpriteRenderer spaceTutorial;
    public Transform leftrightTutorial;

    public bool displaySpace = false;
    public bool displayLeftRight = false;


    public float spaceDisplayDelay;
    public float leftrightDisplayDelay;


	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {

        DisplaySpaceTutorial();
        DisplayLeftrightTutorial();

    }


    void DisplaySpaceTutorial(){
        if (displaySpace){

            spaceDisplayDelay -= Time.deltaTime;
            if (spaceDisplayDelay <= 0){
                if (spaceTutorial.color.a <= 0.99f)
                {
                    spaceTutorial.color += new Color(0, 0, 0, 0.8f * Time.deltaTime);
                }else{
                    spaceTutorial.color = new Color(1, 1, 1, 1);
                }
            }

            if (Input.GetKeyDown(KeyCode.Space)){
                displaySpace = false;
                displayLeftRight = true;
            }
        }else{
            if (spaceTutorial.color.a >= 0.01f)
            {
                spaceTutorial.color -= new Color(0, 0, 0, 1f * Time.deltaTime);
            }else{
                spaceTutorial.color = new Color(1, 1, 1, 0);
            }
        }

    }


    void DisplayLeftrightTutorial(){
        if (displayLeftRight)
        {
            leftrightDisplayDelay -= Time.deltaTime;
            if (leftrightDisplayDelay <= 0)
            {
                if (leftrightTutorial.GetChild(0).GetComponent<SpriteRenderer>().color.a <= 0.99f)
                {
                    leftrightTutorial.GetChild(0).GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, 0.8f * Time.deltaTime);
                    leftrightTutorial.GetChild(1).GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, 0.8f * Time.deltaTime);
                    leftrightTutorial.GetChild(2).GetComponent<TextMesh>().color += new Color(0, 0, 0, 0.8f * Time.deltaTime);
                }else{
                    leftrightTutorial.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                    leftrightTutorial.GetChild(1).GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                    leftrightTutorial.GetChild(2).GetComponent<TextMesh>().color = new Color(leftrightTutorial.GetChild(2).GetComponent<TextMesh>().color.r,leftrightTutorial.GetChild(2).GetComponent<TextMesh>().color.g, leftrightTutorial.GetChild(2).GetComponent<TextMesh>().color.b, 1);
                }
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                displayLeftRight = false;
            }

        }
        else
        {
            if (leftrightTutorial.GetChild(0).GetComponent<SpriteRenderer>().color.a >= 0.01f)
            {
                leftrightTutorial.GetChild(0).GetComponent<SpriteRenderer>().color -= new Color(0, 0, 0, 0.8f * Time.deltaTime);
                leftrightTutorial.GetChild(1).GetComponent<SpriteRenderer>().color -= new Color(0, 0, 0, 0.8f * Time.deltaTime);
                leftrightTutorial.GetChild(2).GetComponent<TextMesh>().color -= new Color(0, 0, 0, 0.8f * Time.deltaTime);
            }
            else
            {
                leftrightTutorial.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                leftrightTutorial.GetChild(1).GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                leftrightTutorial.GetChild(2).GetComponent<TextMesh>().color = new Color(leftrightTutorial.GetChild(2).GetComponent<TextMesh>().color.r, leftrightTutorial.GetChild(2).GetComponent<TextMesh>().color.g, leftrightTutorial.GetChild(2).GetComponent<TextMesh>().color.b, 0);
            }
        }
    }
}
