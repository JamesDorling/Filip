using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disabler : MonoBehaviour
{
    //disabled material
    public Material grapDis;
    //grappling script
    public grapplehook grap;

    void OnTriggerEnter(Collider col)
    {   //if an enabled grapplepoint collides with the trigger
        if(col.gameObject.layer == 9)
        {
            //Disable the grapplepoint
            col.gameObject.layer = 12;
            //Set the grapplepoint's material to signify it being disabled
            col.gameObject.GetComponent<Renderer>().material = grapDis;
            //if the player is grappled onto the grapplepoint then stop them from grappling
            if(col.gameObject == grap.attach)
                grap.StopGrapple();
        }
    }
}
