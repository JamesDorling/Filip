using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invertPad : MonoBehaviour
{
    public int[] changeables; //What lights can the pad change?
    public invertSet stats; //The list of pads
    private AudioSource sound; //Pad sound

    public virtual void setChangeables() //Override to decide the pads changeable
    {
        changeables = null; //Default is null
    }

    void Start()
    {
        stats = GetComponent<Transform>().parent.GetComponent<invertSet>(); //Get the stats from the parent
        setChangeables(); //Set the pad's changeables
        sound = GetComponent<AudioSource>(); //Get the pad sound

    }

    void OnTriggerEnter(Collider col)
    {
        //If the player touches the pad
        if (col.gameObject.layer == 2)
        {
            //go through each changeable object
            for (int i = 0; i < changeables.Length; i++)
            {
                //invert the status
                stats.status[changeables[i]] = !stats.status[changeables[i]];
                //Update the light's colours
                stats.UpdateColours();
                //Play the pressure pad sound
                sound.Play();

            }
        }
    }
}
