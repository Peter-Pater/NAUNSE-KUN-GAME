using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDown : MonoBehaviour {
    GameObject treelower;
	BoxCollider2D col;
	float floorHeight = 29.0f;
	// Use this for initialization
	void Start () {
		treelower = GameObject.Find("TreeLower");
	}
	
	// Update is called once per frame
	void Update () {
		checkFall();
	}
	
	void checkFall(){
		if(transform.position.y <= floorHeight){
			// Debug.Log("falldown");
			col = treelower.GetComponent<BoxCollider2D>();
			// Debug.Log(col);
			Destroy(col);
		}
	}
}
