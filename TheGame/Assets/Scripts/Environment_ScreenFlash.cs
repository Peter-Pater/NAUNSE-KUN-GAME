using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment_ScreenFlash : MonoBehaviour {

    public float lightedAlpha;
    float flashDuration;
    float flashDelay;
    int blinkRate;

    bool isFlashing = false;
    SpriteRenderer mySpriteRenderer;


	// Use this for initialization
	void Start () {
        flashDuration = Random.Range(0.25f, 0.38f);
        flashDelay = Random.Range(1.5f, 3.8f);
        blinkRate = Random.Range(2, 5);
        mySpriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!isFlashing)
        {
            flashDelay -= Time.deltaTime;

            if (flashDelay <= 0)
            {
                flashDuration = Random.Range(0.25f, 0.38f);
                isFlashing = true;
            }
        }else {
            Flash();
            flashDuration -= Time.deltaTime;

            if (flashDuration <= 0){
                flashDelay = Random.Range(1.5f, 3.8f);
                isFlashing = false;
            }
        }

	}


    void Flash(){
        if (Time.frameCount % (2 * blinkRate) == 0)
        {
            mySpriteRenderer.color = new Color(mySpriteRenderer.color.r, mySpriteRenderer.color.g, mySpriteRenderer.color.b, lightedAlpha);
        }
        else if (Time.frameCount % blinkRate == 0)
        {
            mySpriteRenderer.color = new Color(mySpriteRenderer.color.r, mySpriteRenderer.color.g, mySpriteRenderer.color.b, 0);
        }
    }
}
