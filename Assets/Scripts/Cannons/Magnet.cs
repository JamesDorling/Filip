using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    //Rigidbody of the cannonball
    private Rigidbody rb;
    //ball's transform
    private Transform ballTrans;
    //ball's constraints
    private RigidbodyConstraints constraints;
    //velocity of the ball
    private Vector3 velocitySave;

    //desired position for the ball
    private Transform desiredPos;
    //pressure plate to release the ball
    public pressurePlate press;
    //Has the magnet grabbed anything?
    private bool grabbed;

    void Start()
    {
        //Get the desired position
        desiredPos = GetComponent<Transform>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.GetComponent<Rigidbody>() != null)
        {
            //get the ball's rigidbody
            rb = col.gameObject.GetComponent<Rigidbody>();
            //get the ball's velocity
            velocitySave = rb.velocity;
            //get the ball's constraints
            constraints = rb.constraints;
            //Set the rigidbodies constraints to all axis
            rb.constraints = rb.constraints | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
            //get the ball's position
            ballTrans = col.gameObject.GetComponent<Transform>();
            //set the ball's position (Can look janky but looks better than without it)
            ballTrans.position = desiredPos.position;
            //set grabbed to true
            grabbed = true;
        }
    }

    void Update()
    {
        //if the pressure pad is pressed and something is grabbed
        if(press.pressed > 0 && grabbed == true)
        {
            //Give the rigidbody it's constraints back
            rb.constraints = constraints;
            //give the ball its velocity back
            rb.velocity = velocitySave;
            //set grabbed to false
            grabbed = false;
            //dont need to worry about the ball being grabbed again as the function uses trigger enter
        }
    }
}
