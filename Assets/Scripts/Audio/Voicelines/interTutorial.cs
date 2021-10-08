using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interTutorial : MonoBehaviour
{
    public lvl8Audio sound; //Sound clip list

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player") //Only trigger on collision with the player
        {
            sound.Play("Tut"); //Play the allocated sound
            Destroy(gameObject); //Delete the trigger
        }
    }
}
