using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment_CoreHalo : MonoBehaviour {

    Color brokenCoreColor;
    SpriteRenderer mySpriteRenderer;


	// Use this for initialization
	void Start () {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {

        brokenCoreColor = transform.parent.GetComponent<SpriteRenderer>().color;

        mySpriteRenderer.color = new Color(mySpriteRenderer.color.r, mySpriteRenderer.color.g, mySpriteRenderer.color.b, brokenCoreColor.a);
	}
}
