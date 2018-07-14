using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This script is for triangle's rotation 
public class Puzzle_SH_Rotate : MonoBehaviour {
	public int[] values;
	public float speed;
	float realRotation;
  
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //      if (Mathf.Abs(transform.rotation.eulerAngles.z - realRotation) < 0.01f) {
        //	transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.Euler (0, 0, realRotation), speed);
        //}
        transform.eulerAngles = new Vector3(0, 0, realRotation);
	}
	
	
	public void RotatePiece()
	{
		realRotation += 120f;

        if (realRotation >= 360f)
        {
            realRotation -= 360f;
        }
		RotateValues ();
	}
	
	public void RotateValues()
	{

        //int temp = values[2];
        //for (int i = 0; i < values.Length - 2; i++) {
        //	int mid = values[i+1];
        //	values [i+1] = values [i];
        //	values[i+2] = mid;
        //}
        //values[0] = temp;
        int temp0 = values[0];
        int temp1 = values[1];
        int temp2 = values[2];

        values[0] = temp2;
        values[1] = temp0;
        values[2] = temp1;
	}
}
