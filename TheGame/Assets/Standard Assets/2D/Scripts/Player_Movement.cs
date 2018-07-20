using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{ // This script is player control

    bool isControlLocked = false;

    public float xSpeed = 0f; // How fast player moves. Assigned in the inspector.


    public GameObject cameraObj;
    Camera_Movement camMove;


    Rigidbody2D myRigidbody;
    GameObject myLight;
    Player_Animation myAnimationControl;
    Player_AudioManage myAudioManage;



	private void Start()
    {
        camMove = cameraObj.GetComponent<Camera_Movement>();

        myRigidbody = GetComponent<Rigidbody2D>();
        myLight = transform.GetChild(0).gameObject;
        myAnimationControl = GetComponent<Player_Animation>();
        myAudioManage = GetComponent<Player_AudioManage>();
	}


	void Update()
    {

        // Using left and right arrow to move player.
        if (!isControlLocked)
        {
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
            {
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    WalkRight();
                }
                else
                {
                    WalkLeft();
                }
            }
            else
            {
                Standstill();
            }
        }
    }


    public void WalkLeft(){
        myRigidbody.velocity = new Vector2(-xSpeed * Time.deltaTime, myRigidbody.velocity.y);
        FlipLeft(); // Flip character to left.
        myAnimationControl.StartWalking(); // Play walking animation.
        myAudioManage.PlayFootStep(); // Play walking sound.
    }


    public void WalkRight(){
        myRigidbody.velocity = new Vector2(xSpeed * Time.deltaTime, myRigidbody.velocity.y);
        FlipRight();
        myAnimationControl.StartWalking();
        myAudioManage.PlayFootStep();
    }


    public void Standstill(){
        myRigidbody.velocity = new Vector2(0, myRigidbody.velocity.y);
        myAnimationControl.StopWalking(); // Stop walking animation.
        myAudioManage.StopFootStep(); // Stop walking sound.
    }


    void FlipLeft()
    {
        transform.eulerAngles = new Vector3(transform.rotation.x, 0, transform.rotation.z);
        myLight.transform.localPosition = new Vector3(myLight.transform.localPosition.x, myLight.transform.localPosition.y, -1.2f);

        camMove.offset = camMove.offsetLeft;
    }


    void FlipRight()
    {
        transform.eulerAngles = new Vector3(transform.rotation.x, 180, transform.rotation.z);
        myLight.transform.localPosition = new Vector3(myLight.transform.localPosition.x, myLight.transform.localPosition.y, 1.2f);

        camMove.offset = camMove.offsetRight;
    }


    public void LockControl(){
        isControlLocked = true;
    }


    public void UnlockControl(){
        isControlLocked = false;
    }

}
