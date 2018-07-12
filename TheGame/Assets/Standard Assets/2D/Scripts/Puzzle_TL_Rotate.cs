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
		print("Rotate Once");
		int temp = values[2];
		for (int i = 0; i < values.Length - 2; i++) {
			int mid = values[i+1];
			values [i+1] = values [i];
			values[i+2] = mid;
		}
		values[0] = temp;
		// for (int i = 0; i < values.Length; ++i ){
		// 	print(values[i]);
		// }
	}
}
