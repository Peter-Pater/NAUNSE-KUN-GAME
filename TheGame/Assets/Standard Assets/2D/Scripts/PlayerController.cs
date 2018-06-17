using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    void Update()
    {
        var x = Input.GetAxis("Vertical") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Horizontal") * Time.deltaTime * 10.0f;
        
        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("DoorSwitch"))
        {
            //if (Input.GetKeyUp("space")){
                GameObject.FindGameObjectWithTag("DoorSwitch").GetComponent<SwitchController>().triggered = true;
            //}
        }
    }
}
