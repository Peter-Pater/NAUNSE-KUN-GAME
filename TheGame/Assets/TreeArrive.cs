using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeArrive : MonoBehaviour {
	GameObject TreeCut;
	GameObject Sur;
	Rigidbody2D rb;
	Rigidbody2D rbS;
	// Use this for initialization
	void Start () {
		TreeCut = GameObject.Find("TreeUpper");
		Sur = GameObject.Find("Survivor");
		rbS = Sur.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.name == "Player"){
			rb = TreeCut.GetComponent<Rigidbody2D>();
			rb.constraints = RigidbodyConstraints2D.FreezePosition;
			SurJump();
		}
	}
	
	void SurJump(){
		rbS.AddForce(new Vector2(10, 10), ForceMode2D.Impulse);
	}
}
