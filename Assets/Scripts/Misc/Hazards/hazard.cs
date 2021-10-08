using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hazard : MonoBehaviour
{
    //movement script on the player
    public movement move;
    //Hazard manager script
    public hazardManager haz;

    private void OnTriggerEnter(Collider col)
    {
        //if the player collides with the hazard
        if (col.gameObject.tag == "Player")
        {
            //if it is not already resetting, then reset the player
            if (haz.resetting == false)
                StartCoroutine(haz.reset());
        }
        else
        {
            //else end the function
            return;
        }
    }

    private void OnTriggerStay(Collider col)
    {
        //if the player collides with the hazard (Stay is here too so that it will definitely trigger)
        if (col.gameObject.tag == "Player")
        {
            //if it is not already resetting, then reset the player
            if (haz.resetting == false)
                StartCoroutine(haz.reset());
        }
        else
        {
            //else end the function
            return;
        }
    }
}
