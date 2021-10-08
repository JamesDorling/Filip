using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactable : interSpawnManager
{
    //This script is used on interactables and is also used on cannonballs.

    //Spawn point of the interactable
    public Transform spawner;
    //transform of the interactable
    private Transform interactTrans;
    //rigidbody of the interactable
    private Rigidbody rb;

    private void Awake()
    {
        //Get the rigidbody of the interactable
        rb = GetComponent<Rigidbody>();
        //Get the transform
        interactTrans = GetComponent<Transform>();
        //if the object is a cannonball
        if(interactTrans.gameObject.layer == 9)
        {
            //Set it to not be able to sleep
            rb.sleepThreshold = 0;
        }
    }

    public override Transform setSpawn()
    { 
        //Send through the spawner
        return spawner;
    }
    public override Transform setInteractableTransform()
    { 
        //Send through the transform
        return interactTrans;
    }
    public override Rigidbody setInteractableRB()
    { 
        //Send through the rigidbody
        return rb;
    }
}
