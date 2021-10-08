using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterRail : MonoBehaviour
{
    //ball's rigidbody
    private Rigidbody rb;
    //ball's transform
    private Transform ballTrans;
    //desired position
    private Transform desiredPos;

    void Start()
    {
        //get the desired position
        desiredPos = GetComponent<Transform>();
    }

    void OnTriggerEnter(Collider col)
    {
        //if the collided object has a rigidbody
        if(col.gameObject.GetComponent<Rigidbody>() != null)
        {
            //get the rigidbody
            rb = col.gameObject.GetComponent<Rigidbody>();
            //set the constraints of the ball to the X axis
            rb.constraints = rb.constraints | RigidbodyConstraints.FreezePositionX;// | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
            //get the transform of the ball
            ballTrans = col.gameObject.GetComponent<Transform>();
            //set the ball's position to the desired position
            ballTrans.position = desiredPos.position;
        }
    }
}
