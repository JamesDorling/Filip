using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvl8trigger2 : MonoBehaviour
{
    //Soundmanager
    public lvl8Audio sound;

    void OnTriggerEnter(Collider col)
    {
        //If the player collides with the trigger
        if (col.gameObject.tag == "Player")
        {
            //play the relevant soundclip
            sound.Play("End2");
            //Destroy the trigger
            Destroy(gameObject);
        }
    }
}
