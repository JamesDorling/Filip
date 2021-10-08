using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHit : MonoBehaviour
{
    //Rigidbody of the cannonball
    private Rigidbody rb;
    //Transform of the cannonball
    private Transform ballTrans;

    //Desired transform of the ball (Also the transform of the trigger)
    private Transform desiredPos;

    void Start()
    {
        //get the trigger's position
        desiredPos = GetComponent<Transform>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.GetComponent<Rigidbody>() != null)
        {
            //get the cannonball's rigidbody
            rb = col.gameObject.GetComponent<Rigidbody>();
            //Constrain the rigidbody on the X axis
            rb.constraints = rb.constraints | RigidbodyConstraints.FreezePositionX;// | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
            //Get the cannonball's transform
            ballTrans = col.gameObject.GetComponent<Transform>();
            //Set the x and z positions of the ball to the trigger's.
            ballTrans.position = new Vector3(desiredPos.position.x, ballTrans.position.y, desiredPos.position.z);
        }
    }
}
