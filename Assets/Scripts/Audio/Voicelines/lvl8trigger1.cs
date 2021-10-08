using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvl8trigger1 : MonoBehaviour
{
    //Sound manager
    public lvl8Audio sound;

    void OnTriggerEnter(Collider col)
    {
        //if the player enters the trigger
        if (col.gameObject.tag == "Player")
        {
            //Play the first end soundclip
            sound.Play("End1");
            //destroy the trigger
            Destroy(gameObject);
        }
    }
}
