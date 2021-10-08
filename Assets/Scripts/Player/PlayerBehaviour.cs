using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public int grounded = 1; //Ground counter

    public BoxCollider col; //Player's capsule collider

    public ParticleSystem parSys;

    public Rigidbody rb;

    private AudioSource audio;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Floor")
        {
            grounded += 1; //Add one to the ground int upon entering a collision with the floor
            //If the velocity is high enough
            if (rb.velocity.y > -0.3)
            {
                parSys.Play(); //Play the particle system
            }
            audio.Play(); //Play the landing audio
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Floor")
        {
            grounded -= 1; //Minus one to the ground int upon leaving a collision with the floor

            parSys.Play(); //Play the particle system

        }
    }

    private void Update()
    {
        //If grounded goes below 0
        if(grounded < 0)
        { 
            //set grounded to 0, to avoid errors
            grounded = 0;
        }
    }

    //void Update()
    //{
    //    GetComponent<Rigidbody>().angularVelocity = new Vector3(0f, 0f, 0f); //Get the rigidbody's angular velocity and set it to 0, just in case.
    //}
}
