using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enabler : MonoBehaviour
{
    //Enabled grapplepoint material
    public Material grapEn;
    void OnTriggerEnter(Collider col)
    {
        //when a disabled grapplepoint collides with the trigger
        if (col.gameObject.layer == 12)
        {
            //enable the grapplepoint
            col.gameObject.layer = 9;
            //set the grapplepoint's material to signify it being enabled
            col.gameObject.GetComponent<Renderer>().material = grapEn;
        }
    }
}
