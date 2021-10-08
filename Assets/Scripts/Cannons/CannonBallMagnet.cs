using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallMagnet : MonoBehaviour
{
    //This script is to move the cannonball to the center of the cannon when it collides with it. It was experimented with, but I eventually removed it.
    //Ball's transform
    private Transform transform;
    //Ball's rigidbody
    private Rigidbody rb;
    //Desired position of the ball
    public Transform desiredPos;

    //Boolean to track if there is a ball in the magnet.
    bool magnetising = false;

    void OnTriggerEnter(Collider col)
    {
        //if the object hitting the trigger is a cannonball
        if(col.gameObject.tag == "Grappleable")
        {
            //get the ball's transform
            transform = col.gameObject.GetComponent<Transform>();
            //get the ball's rigidbody
            rb = col.gameObject.GetComponent<Rigidbody>();
            //set the magnet to be magnetising
            magnetising = true;
        }
    }

    void Update()
    {
        //if the magnet has a ball
        if(magnetising == true)
        {
            //if the ball is not in the right position
            if(transform.position != desiredPos.position)
            {
                //move it to the right position with a lerp
                transform.position = new Vector3(Mathf.Lerp(transform.position.x, desiredPos.position.x, 0.5f * Time.deltaTime), Mathf.Lerp(transform.position.y, desiredPos.position.y, 1f * Time.deltaTime), Mathf.Lerp(transform.position.z, desiredPos.position.z, 1f * Time.deltaTime));
            }
            else
            {
                //else turn magnetising off
                magnetising = false;
            }
        }
    }
}
