using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressureset : MonoBehaviour
{
    public interactable inter; //interactable script on the item to be reset
    public GameObject ball; //The ball gameobject
    public Rigidbody interb; //Ball rigidbody
    public Material grapEnabled; //The enabled grapple material
    private AudioSource sound; //The pad sound

    void Start()
    {
        //Sound for the pressure pad
        sound = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider col)
    {   //if the player or an interactable stands on the plate
        if (col.gameObject.tag == "Player" && col.gameObject.layer != 2 || col.gameObject.layer == 10)
        {
            //Reset the cannonball
            inter.resetButton();
            //unconstrain the ball
            interb.constraints = RigidbodyConstraints.None;
            //get the ball's renderer and set it's material
            ball.GetComponent<Renderer>().material = grapEnabled;
            //set the ball's layer
            ball.layer = 9;
            //play the pressure pad sound
            sound.Play();
        }
    }
}
