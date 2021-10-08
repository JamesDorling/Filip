using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grappleLight : MonoBehaviour
{
    //Light lights;
    //Material for the grapple light
    private Material mat;
    //Grapple script
    public grapplehook grapple;

    // Start is called before the first frame update
    void Start()
    {
        //lights = GetComponent<Light>();
        mat = GetComponent<Renderer>().material;

    }

    // Update is called once per frame
    void Update()
    {
        //If the player is grappling onto a grapple point
        if(grapple.getLayer() == 1)
        {

            //lights.color = Color.yellow;
            mat.color = Color.yellow; //Make the material yellow
        }
        else if(grapple.getLayer() == 2) //If the player is grappling an interactable object
        {
            //lights.color = Color.blue;
            mat.color = Color.blue; //Make the material blue
        }
        else //If the player is not grappling
        {
            //lights.color = Color.red;
            mat.color = Color.red; //Make the material red
        }
        mat.EnableKeyword("_EMISSION"); //Turn on emission
        mat.SetColor("_EmissionColor", mat.color); //Make the emission colour the same as the material colour
    }
}
