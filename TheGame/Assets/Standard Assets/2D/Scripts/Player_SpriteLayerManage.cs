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
    float toPickSpeed = 1f;
    float toLightSpeed = 1f;
    float toAxeSpeed = 1f;
    float toCoreSpeed = 1f;


	// Use this for initialization
	void Start () {

        myItems = GetComponent<Player_Items>();

        normalLayer = transform.GetChild(1).GetComponent<SpriteRenderer>();
        gearLayer = transform.GetChild(2).GetComponent<SpriteRenderer>();
        pickLayer = transform.GetChild(3).GetComponent<SpriteRenderer>();
        flashLightLayer = transform.GetChild(4).GetComponent<SpriteRenderer>();
        axeLayer = transform.GetChild(5).GetComponent<SpriteRenderer>();
        newCoreLayer = transform.GetChild(6).GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
        if (myItems.whatsInHand == General_ItemList.NONE){
            SwitchToNormal();
        }else if (myItems.whatsInHand == General_ItemList.GEAR){
            SwitchToGear();
        }else if (myItems.whatsInHand == General_ItemList.MOUNTAINEERINGPICK){
            SwitchToPick();
        }else if (myItems.whatsInHand == General_ItemList.FLASHLIGHT){
            SwitchToLight();
        }else if (myItems.whatsInHand == General_ItemList.AXE){
            SwitchToAxe();
        }else if (myItems.whatsInHand == General_ItemList.CORE){
            SwitchToCore();
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

        if (pickLayer.color.a >= 0.01f)
        {
            pickLayer.color -= new Color(0, 0, 0, toNormalSpeed * Time.deltaTime);
        }

        if (flashLightLayer.color.a >= 0.01f)
        {
            flashLightLayer.color -= new Color(0, 0, 0, toNormalSpeed * Time.deltaTime);
        }

        if (axeLayer.color.a >= 0.01f)
        {
            axeLayer.color -= new Color(0, 0, 0, toNormalSpeed * Time.deltaTime);
        }

        if (newCoreLayer.color.a >= 0.01f)
        {
            newCoreLayer.color -= new Color(0, 0, 0, toNormalSpeed * Time.deltaTime);
        }
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

        if (pickLayer.color.a >= 0.01f)
        {
            pickLayer.color -= new Color(0, 0, 0, toGearSpeed * Time.deltaTime);
        }

        if (flashLightLayer.color.a >= 0.01f)
        {
            flashLightLayer.color -= new Color(0, 0, 0, toGearSpeed * Time.deltaTime);
        }

        if (axeLayer.color.a >= 0.01f)
        {
            axeLayer.color -= new Color(0, 0, 0, toGearSpeed * Time.deltaTime);
        }

        if (newCoreLayer.color.a >= 0.01f)
        {
            newCoreLayer.color -= new Color(0, 0, 0, toGearSpeed * Time.deltaTime);
        }
    }


    void SwitchToPick(){
        if (pickLayer.color.a <= 0.99f)
        {
            pickLayer.color += new Color(0, 0, 0, toPickSpeed * Time.deltaTime);
        }

        if (normalLayer.color.a >= 0.01f)
        {
            normalLayer.color -= new Color(0, 0, 0, toPickSpeed * Time.deltaTime);
        }

        if (gearLayer.color.a >= 0.01f)
        {
            gearLayer.color -= new Color(0, 0, 0, toPickSpeed * Time.deltaTime);
        }

        if (flashLightLayer.color.a >= 0.01f)
        {
            flashLightLayer.color -= new Color(0, 0, 0, toPickSpeed * Time.deltaTime);
        }

        if (axeLayer.color.a >= 0.01f)
        {
            axeLayer.color -= new Color(0, 0, 0, toPickSpeed * Time.deltaTime);
        }

        if (newCoreLayer.color.a >= 0.01f)
        {
            newCoreLayer.color -= new Color(0, 0, 0, toPickSpeed * Time.deltaTime);
        }
    }


    void SwitchToLight(){
        if (flashLightLayer.color.a <= 0.99f)
        {
            flashLightLayer.color += new Color(0, 0, 0, toLightSpeed * Time.deltaTime);
        }

        if (normalLayer.color.a >= 0.01f)
        {
            normalLayer.color -= new Color(0, 0, 0, toLightSpeed * Time.deltaTime);
        }

        if (pickLayer.color.a >= 0.01f)
        {
            pickLayer.color -= new Color(0, 0, 0, toLightSpeed * Time.deltaTime);
        }

        if (gearLayer.color.a >= 0.01f)
        {
            gearLayer.color -= new Color(0, 0, 0, toLightSpeed * Time.deltaTime);
        }

        if (axeLayer.color.a >= 0.01f)
        {
            axeLayer.color -= new Color(0, 0, 0, toLightSpeed * Time.deltaTime);
        }

        if (newCoreLayer.color.a >= 0.01f)
        {
            newCoreLayer.color -= new Color(0, 0, 0, toLightSpeed * Time.deltaTime);
        }
    }


    void SwitchToAxe(){
        if (axeLayer.color.a <= 0.99f)
        {
            axeLayer.color += new Color(0, 0, 0, toAxeSpeed * Time.deltaTime);
        }

        if (normalLayer.color.a >= 0.01f)
        {
            normalLayer.color -= new Color(0, 0, 0, toAxeSpeed * Time.deltaTime);
        }

        if (pickLayer.color.a >= 0.01f)
        {
            pickLayer.color -= new Color(0, 0, 0, toAxeSpeed * Time.deltaTime);
        }

        if (flashLightLayer.color.a >= 0.01f)
        {
            flashLightLayer.color -= new Color(0, 0, 0, toAxeSpeed * Time.deltaTime);
        }

        if (gearLayer.color.a >= 0.01f)
        {
            gearLayer.color -= new Color(0, 0, 0, toAxeSpeed * Time.deltaTime);
        }

        if (newCoreLayer.color.a >= 0.01f)
        {
            newCoreLayer.color -= new Color(0, 0, 0, toAxeSpeed * Time.deltaTime);
        }
    }


    void SwitchToCore(){
        if (newCoreLayer.color.a <= 0.99f)
        {
            newCoreLayer.color += new Color(0, 0, 0, toCoreSpeed * Time.deltaTime);
        }

        if (normalLayer.color.a >= 0.01f)
        {
            normalLayer.color -= new Color(0, 0, 0, toCoreSpeed * Time.deltaTime);
        }

        if (pickLayer.color.a >= 0.01f)
        {
            pickLayer.color -= new Color(0, 0, 0, toCoreSpeed * Time.deltaTime);
        }

        if (flashLightLayer.color.a >= 0.01f)
        {
            flashLightLayer.color -= new Color(0, 0, 0, toCoreSpeed * Time.deltaTime);
        }

        if (axeLayer.color.a >= 0.01f)
        {
            axeLayer.color -= new Color(0, 0, 0, toCoreSpeed * Time.deltaTime);
        }

        if (gearLayer.color.a >= 0.01f)
        {
            gearLayer.color -= new Color(0, 0, 0, toCoreSpeed * Time.deltaTime);
        }
    }
}
