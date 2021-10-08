using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invertSet : MonoBehaviour
{
    //Light list
    public GameObject[] lights;
    //status of the lights
    public bool[] status;

    //grapplepoint to enable
    public GameObject grapplepoint;
    //finish block to symbolise the completion of the puzzle
    public GameObject finLight;
    //arrow to show the way after completion
    public GameObject arrow;

    //enabled material for the invertable blocks
    public Material enabled;
    //Disabled material for the invertable blocks
    public Material disabled;

    //Enabled material for the grapple point
    public Material grapEn;
    //Disabled material for the grapple point
    public Material grapDis;

    void Start()
    {
        //List of the object statuses
        status = new bool[7];
        //randomise the enabled ones
        SetEnableds();
    }

    bool RandomEnable()
    {
        //Return a random true or false value
        return (Random.value > 0.5f);
    }

    void SetEnableds()
    {
        //Go through each object
        for (int i = 0; i < 7; i++)
        {
            //Randomise the status
            status[i] = RandomEnable();
            //if there have been more than 2 done already (Greater than 1 because that means from 2 onwards, and it starts at 0)
            if (i > 1)
            {
                //if both of the prior statuses are the same
                if (status[i - 2] == status[i - 1])
                {
                    //set the current object to be different so there wont be three of the same in a row
                    status[i] = !status[i - 1]; //No three in a rows now! so there may actually be some challenge
                }
            }
        }
        UpdateColours(); //Update the colours
    }

    // CHECKING IF DONE //////////////////////////////////////////////////////////////////////////////////
    void Update()
    {
        //Preset the done boolean to true
        bool done = true;
        //Go through the list of statuses
        for(int i = 0; i < status.Length; i++)
        {
            //if the block is false
            if(status[i] == false)
            {
                //puzzle is not complete
                done = false;
            }
        }
        if(done) //if the puzzle is complete
        {
            //enable the grapplepoint
            grapplepoint.layer = 9;
            //Change the grapplepoint's material to symbolise being enabled
            grapplepoint.GetComponent<Renderer>().material = grapEn;
            //Debug.Log("Complete!");
            //set the finished light to be enabled
            finLight.GetComponent<Renderer>().material = enabled;
            //enable the direction arrow
            arrow.SetActive(true);
        }
        else
        {
            //Disable the grapplepoint
            grapplepoint.layer = 12;
            //Set the material of the grapplepoint to symbolise being disabled
            grapplepoint.GetComponent<Renderer>().material = grapDis;
            //set the finish light to be disabled
            finLight.GetComponent<Renderer>().material = disabled;
            //disable the arrow
            arrow.SetActive(false);
        }
    }

    // UPDATING COLOURS ////////////////////////////////////////////////////////////////////////////////////
    public void UpdateColours()
    {
        //go through the block statuses
        for (int i = 0; i < status.Length; i++)
        {
            switch (status[i])
            {
                case true: //If the status is true
                    //enable the light
                    lights[i].GetComponent<Renderer>().material = enabled;
                    break;
                case false: //If the status is false
                    //disable the light
                    lights[i].GetComponent<Renderer>().material = disabled;
                    break;
            }
        }
    }
}
