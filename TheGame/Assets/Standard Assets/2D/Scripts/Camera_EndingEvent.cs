using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Camera_EndingEvent : MonoBehaviour {

    public Image credits;
    public Text endingLine;


    public float creditsStaytingTime;
    public float endingStayingTime;


    int CREDITS = 0;
    int ENDING = 1;
    int display = 0;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if (display == CREDITS)
        {
            if (creditsStaytingTime > 0)
            {

                if (credits.color.a <= 0.99f)
                {
                    credits.color += new Color(0, 0, 0, 0.4f * Time.deltaTime);
                }
                else
                {
                    creditsStaytingTime -= Time.deltaTime;
                }
            }
            else
            {
                if (credits.color.a >= 0.01f)
                {
                    credits.color -= new Color(0, 0, 0, 0.4f * Time.deltaTime);
                }
                else
                {
                    display = ENDING;
                }
            }
        }
        else if (display == ENDING)
        {

            if (endingStayingTime > 0)
            {
                if (endingLine.color.a <= 0.99f)
                {
                    endingLine.color += new Color(0, 0, 0, 0.4f * Time.deltaTime);
                }
                else
                {
                    endingStayingTime -= Time.deltaTime;
                }
            }
            else
            {
                if (endingLine.color.a >= 0.01f)
                {
                    endingLine.color -= new Color(0, 0, 0, 0.4f * Time.deltaTime);
                }
                else
                {
                    SceneManager.LoadScene("MainScene");

                }
            }
        }
	}
}
