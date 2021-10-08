using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interSpawnManager : MonoBehaviour
{
    //Spawn point location
    private Transform spawnpoint;
    //Interactable location
    private Transform intransform;
    //Interactable rigidbody
    private Rigidbody interb;
    //Player's grapple script
    public grapplehook grapple;

    void Start()
    {
        //Get the spawnpoint
        spawnpoint = setSpawn();
        //Get the transform of the interactable
        intransform = setInteractableTransform();
        //Get the interactable's rigidbody
        interb = setInteractableRB();
    }

    public void ResetObject()
    {
        //Start the reset coroutine
        StartCoroutine(reset());
        //If the player is grappling
        if (grapple.attach != null)
        {
            //If the player is grappling to the interactable being reset
            if (grapple.layer == 2 && grapple.attach.transform.position == intransform.position)
            {
                //Stop the player's grappling
                grapple.StopGrapple();
            }//If the player is grappling to the cannonball being reset
            else if (grapple.attach.tag == "Cannonball" && grapple.attach.transform.position == intransform.position)
            {
                //Stop the player's grappling
                grapple.StopGrapple();
            }
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        //if the object hits a hazard
        if (col.gameObject.tag == "Hazard")
        {
            //reset the object
            ResetObject();
        }
    }

    //Virtual functions to get the spawnpoint, interactable transform and rigidbody from subclasses
    public virtual Transform setSpawn() { return null; }
    public virtual Transform setInteractableTransform() { return null; }
    public virtual Rigidbody setInteractableRB() { return null; }

    //Reset coroutine
    private IEnumerator reset()
    {
        //wait for 1 second
        yield return new WaitForSeconds(1);
        //set the interactable's position to the spawnpoint's position
        intransform.position = spawnpoint.position;
        //Reset the object's velocity
        interb.velocity = new Vector3(0f, 0f, 0f);
    }

    public void resetButton()
    {
        //set the object's position to the spawnpoint
        intransform.position = spawnpoint.position;
        //reset the object's velocity
        interb.velocity = new Vector3(0f, 0f, 0f);
    }
}
