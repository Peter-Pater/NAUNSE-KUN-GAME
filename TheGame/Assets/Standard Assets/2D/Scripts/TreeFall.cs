using UnityEngine;
using System.Collections;

public class TreeFall : MonoBehaviour
{
    // public Texture2D tex;

    private Rigidbody2D rb2D;
	public GameObject B;
   
    void Start()
    {
		
		rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
			// Debug.Log("Tree Move");
            TreeMove ();
        }
    }
	
	void TreeMove(){
		transform.RotateAround(B.transform.position, Vector3.forward, 300*Time.deltaTime);
    }
}
