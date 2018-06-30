using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_GiantStone : MonoBehaviour {

    bool isClimbFinished = false;
    bool isPlayerClimbing = false;
    GameObject stoneTop;

    public GameObject player;
    public float playerClimbingSpeed;


	// Use this for initialization
	void Start () {
        stoneTop = transform.parent.GetChild(0).gameObject;
	}
	

	// Update is called once per frame
	void Update () {
		
        if (isPlayerClimbing){
            player.GetComponent<Rigidbody2D>().gravityScale = 0;
            Vector3 targetPos = Vector3.Lerp(player.transform.position, new Vector3(8, 2, player.transform.position.z), playerClimbingSpeed * Time.deltaTime);
            player.transform.position = targetPos;
        }

        if (Mathf.Abs(player.transform.position.y - 2f) <= 0.1f){
            isClimbFinished = true;

            stoneTop.GetComponent<Collider2D>().isTrigger = false;
            player.GetComponent<Rigidbody2D>().gravityScale = 1;

            isPlayerClimbing = false;
        }
	}


	private void OnTriggerStay2D(Collider2D collision)
	{
        if (collision.tag == "Player"){
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (!isClimbFinished)
                {
                    isPlayerClimbing = true;
                }
            }
        }
	}
}
