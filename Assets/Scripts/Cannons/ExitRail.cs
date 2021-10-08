using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitRail : MonoBehaviour
{
    //Ball rigidbody
    private Rigidbody rb;
    //Ball transform
    private Transform ballTrans;
    //desired ball position
    private Transform desiredPos;

    void Start()
    {
        //get the desired position
        desiredPos = GetComponent<Transform>();
    }

    void OnTriggerEnter(Collider col)
    {
        //If the collided object has a rigidbody
        if (col.gameObject.GetComponent<Rigidbody>() != null)
        {
            //get the ball's rigidbody
            rb = col.gameObject.GetComponent<Rigidbody>();
            //Set the ball's constraints
            rb.constraints = RigidbodyConstraints.None;
            //get the ball's transform
            ballTrans = col.gameObject.GetComponent<Transform>();
            //set the ball's position
            ballTrans.position = desiredPos.position;
        }
    }
}
