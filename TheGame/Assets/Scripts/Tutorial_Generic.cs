using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_Generic : MonoBehaviour { // This script manages appearing & disappearing of generic instructions.
    
    SpriteRenderer mySpriteRenderer;
    TextMesh noteMesh;


    public bool isAlreadyTriggered = false;
    public bool ifDisplay = false;
    public float displayDelay;

	// Use this for initialization
	void Start () {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        noteMesh = transform.GetChild(2).GetComponent<TextMesh>();

	}
	
	// Update is called once per frame
	void Update () {
        DisplayTutorial();
	}


    void DisplayTutorial()
    {
        if (ifDisplay)
        {

            displayDelay -= Time.deltaTime;
            if (displayDelay <= 0)
            {
                if (mySpriteRenderer.color.a <= 0.99f)
                {
                    mySpriteRenderer.color += new Color(0, 0, 0, 0.8f * Time.deltaTime);
                    noteMesh.color += new Color(0, 0, 0, 0.8f * Time.deltaTime);

                }
                else
                {
                    mySpriteRenderer.color = new Color(1, 1, 1, 1);
                    noteMesh.color = new Color(noteMesh.color.r, noteMesh.color.g, noteMesh.color.b, 1);

                }
            }

        }
        else
        {
            if (mySpriteRenderer.color.a >= 0.01f)
            {
                mySpriteRenderer.color -= new Color(0, 0, 0, 0.8f * Time.deltaTime);
                noteMesh.color -= new Color(0, 0, 0, 0.8f * Time.deltaTime);
            }
            else
            {
                mySpriteRenderer.color = new Color(1, 1, 1, 0);
                noteMesh.color = new Color(noteMesh.color.r, noteMesh.color.g, noteMesh.color.b, 0);
            }
        }

    }
}
