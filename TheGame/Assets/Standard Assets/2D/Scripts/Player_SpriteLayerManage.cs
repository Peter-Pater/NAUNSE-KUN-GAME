using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_SpriteLayerManage : MonoBehaviour { // This script manages switching between different sprite layers.
    
    Player_Items myItems;


    SpriteRenderer normalLayer;
    SpriteRenderer gearLayer;
    SpriteRenderer pickLayer;
    SpriteRenderer flashLightLayer;
    SpriteRenderer axeLayer;
    SpriteRenderer newCoreLayer;


    float toNormalSpeed = 1f;
    float toGearSpeed = 0.8f;


	// Use this for initialization
	void Start () {

        myItems = GetComponent<Player_Items>();

        normalLayer = transform.GetChild(1).GetComponent<SpriteRenderer>();
        gearLayer = transform.GetChild(2).GetComponent<SpriteRenderer>();
        //pickLayer = transform.GetChild(3).GetComponent<SpriteRenderer>();
        //flashLightLayer = transform.GetChild(4).GetComponent<SpriteRenderer>();
        //axeLayer = transform.GetChild(5).GetComponent<SpriteRenderer>();
        //newCoreLayer = transform.GetChild(6).GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
        if (myItems.whatsInHand == General_ItemList.NONE){
            SwitchToNormal();
        }else if (myItems.whatsInHand == General_ItemList.GEAR){
            SwitchToGear();
        }
	}


    void SwitchToNormal(){
        if (normalLayer.color.a <= 0.99f)
        {
            normalLayer.color += new Color(0, 0, 0, toNormalSpeed * Time.deltaTime);
        }

        if (gearLayer.color.a >= 0.01f)
        {
            gearLayer.color -= new Color(0, 0, 0, toNormalSpeed * Time.deltaTime);
        }

        //if (pickLayer.color.a >= 0.01f)
        //{
        //    pickLayer.color -= new Color(0, 0, 0, crossFadeSpeed);
        //}

        //if (flashLightLayer.color.a >= 0.01f)
        //{
        //    flashLightLayer.color -= new Color(0, 0, 0, crossFadeSpeed);
        //}

        //if (axeLayer.color.a >= 0.01f)
        //{
        //    axeLayer.color -= new Color(0, 0, 0, crossFadeSpeed);
        //}

        //if (newCoreLayer.color.a >= 0.01f)
        //{
        //    newCoreLayer.color -= new Color(0, 0, 0, crossFadeSpeed);
        //}
    }


    void SwitchToGear(){
        if (gearLayer.color.a <= 0.99f)
        {
            gearLayer.color += new Color(0, 0, 0, toGearSpeed * Time.deltaTime);
        }

        if (normalLayer.color.a >= 0.01f)
        {
            normalLayer.color -= new Color(0, 0, 0, toGearSpeed * Time.deltaTime);
        }

        //if (pickLayer.color.a >= 0.01f)
        //{
        //    pickLayer.color -= new Color(0, 0, 0, crossFadeSpeed);
        //}

        //if (flashLightLayer.color.a >= 0.01f)
        //{
        //    flashLightLayer.color -= new Color(0, 0, 0, crossFadeSpeed);
        //}

        //if (axeLayer.color.a >= 0.01f)
        //{
        //    axeLayer.color -= new Color(0, 0, 0, crossFadeSpeed);
        //}

        //if (newCoreLayer.color.a >= 0.01f)
        //{
        //    newCoreLayer.color -= new Color(0, 0, 0, crossFadeSpeed);
        //}
    }
}
