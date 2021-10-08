using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateGun : MonoBehaviour
{
    public grapplehook grapple; //Grapplegun code

    private Quaternion rotation; //Gun rotation
    private float rotationSpeed = 5f; //Speed of the rotation

    // Update is called once per frame
    void Update()
    {
        if (!grapple.isGrappling()) //If the grapple isnt in use
        {
            rotation = transform.parent.rotation; //point the gun forward
        }
        else
        {
            rotation = Quaternion.LookRotation(grapple.GetGrapplePoint() - transform.position); //else point the gun at the grapple point
        }
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed); //rotate the gun to look at wherever has been decided
    }
}
