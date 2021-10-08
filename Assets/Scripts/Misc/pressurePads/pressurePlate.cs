using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressurePlate : MonoBehaviour
{
    public int pressed = 0; //Counting the items on the pressure pad so that if the player and an interactable are on a pad, and the player steps off it wont turn off
    private AudioSource sound; //Pressed sound

    void Start()
    {
        sound = GetComponent<AudioSource>(); //Get the audio component
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player" && col.gameObject.layer != 2 || col.gameObject.layer == 10 || col.gameObject.layer == 12 || col.gameObject.layer == 9) //If the player, an interactable or a grapplepoint enters the trigger
        {
            pressed += 1; //Then add 1 to the "pressed" int
            sound.Play(); //Play the pressure plate sound
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player" && col.gameObject.layer != 2 || col.gameObject.layer == 10 || col.gameObject.layer == 12 || col.gameObject.layer == 9) //If the player, an interactable or a grapplepoint exits the trigger
        {
            pressed -= 1; //Then remove one from the pressed int
        }
    }
}
