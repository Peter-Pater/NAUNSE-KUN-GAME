using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This script is for triangle's rotation 
public class Puzzle_TL_Rotate : MonoBehaviour {
	public int[] values;
	public float speed;
	float realRotation;
  
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.rotation.eulerAngles.z != realRotation) {
			transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.Euler (0, 0, realRotation), speed);
		}
	}
	
	void OnMouseDown(){
		RotatePiece();
	}
	
	
	public void RotatePiece()
	{
		realRotation += 120;

		if (realRotation == 360)
			realRotation = 0;

		RotateValues ();
	}
	
	public void RotateValues()
	{

		// int aux = values [0];
		//
		// for (int i = 0; i < values.Length-1; i++) {
		// 	values [i] = values [i + 1];
		// }
		// values [2] = aux;
		int temp = values[2];
		for (int i = 0; i < values.Length - 1; i++) {
			values [i+1] = values [i];
		}
		values[0] = temp;
	}
}
