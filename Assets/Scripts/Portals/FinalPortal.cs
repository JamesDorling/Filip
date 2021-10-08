using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class FinalPortal : MonoBehaviour
{
    //Post process volume for the final platform
    private PostProcessVolume PPVol;
    //Depth of field
    private DepthOfField depth;
    //Player movement script
    private movement move;

    //Portal position
    public Transform portal;
    //Player position
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        //Get the post process volume
        PPVol = GetComponent<PostProcessVolume>();
        //Get the depth settings for the volume
        PPVol.profile.TryGetSettings(out depth);
        //Disable the volume
        PPVol.enabled = false;
        //Set the depth of field to be basically non existant
        depth.aperture.value = 100f;
    }

    void OnTriggerEnter(Collider col)
    {
        //Enable the volume
        PPVol.enabled = true;
        //Set the depth value to basically be non existant
        depth.aperture.value = 100f;
        //If the object has a movement component
        if(col.gameObject.GetComponent<movement>() != null)
        {
            //get the movement script
            move = col.gameObject.GetComponent<movement>();
            //Limit the player's speed while in the trigger
            move.setMaxSpeed(5f, false);
        }
    }

    void OnTriggerStay(Collider col)
    {
        //Get the distance from the portal
        float dist = Vector3.Distance(portal.position, player.position);
        //exponentially increase the depth of field based on closeness to the portal
        depth.aperture.value = Mathf.Exp(Mathf.Pow((dist * 0.035f), 2.5f));
    }

    void OnTriggerExit(Collider col)
    {
        //If its the player and has a movement script
        if (col.gameObject.GetComponent<movement>() != null)
        {
            //Get the movement script
            move = col.gameObject.GetComponent<movement>();
            //Set the max speed back to the original
            move.setMaxSpeed(15f, true);
        }
    }
}
