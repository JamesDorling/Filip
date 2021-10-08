using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level5Paths : MonoBehaviour
{
    public GameObject[] grapplePoints; //Grapple points array
    public GameObject[] grappleMap; //Grapple map array

    //Portal trigger position
    public Transform portTrigger;
    //portal particle system
    public Transform portParticle;
    //First portal position
    public Transform portPlace1;
    //Second portal position
    public Transform portPlace2;
    //Third portal position
    public Transform portPlace3;
    //portal portal map transform
    public Transform portMap;

    //disabled grapplepoints material
    public Material disabledMat;
    //enabled grapplepoint materials
    public Material enabledMat;

    //Map arrays, from top left to bottom right. False means it is not enabled, true means it is.
    private bool[] map1 = { false, false, false, true, false, false, false, false, true, true, false, false, false, false, true, false, false, false, true, true, true, true, false, false, true, true, false, true, true, false, true, true, false, false, true, false, true, false, false, false, false, true, false, false, false, false, false, false, true };
    private bool[] map2 = { false, false, false, false, true, true, false, true, true, true, false, false, true, false, true, false, true, true, true, true, false, true, true, false, false, false, false, false, false, true, false, false, false, false, false, false, true, true, false, false, false, false, false, false, true, true, false, false, false };
    private bool[] map3 = { true, true, true, false, false, false, false, true, false, false, false, false, false, false, true, false, false, true, true, true, false, true, true, true, true, false, true, false, false, false, false, false, false, true, false, false, false, false, true, true, true, false, false, false, false, true, false, false, false };
    private bool[] map4 = { false, false, false, true, false, false, false, false, false, false, false, true, true, true, true, true, true, false, false, false, true, true, false, true, false, true, true, true, true, false, true, true, true, false, false, true, false, false, false, false, false, false, true, false, false, false, false, false, false };

    // Start is called before the first frame update
    void Start()
    {
        //Choose the path randomly
        float path = Random.Range(0, 4);

        switch (path)
        {
            /*case 0:
             * The following cases iterate through the grapplemap like this:
             * (Commented here so that I dont have to repeat myself with comments 4 times)
                //for each member of the grapplemap
                for(int i = 0; i < grappleMap.Length; i++)
                {
                    //get the grapplepoint's renderer
                    Renderer rend = grappleMap[i].GetComponent<Renderer>();
                    //Set the portal's position on the map dependant on the map choice
                    portMap.position = new Vector3(-110f, 75f, -92.5f);
                    //if the grapplepoint at this stage of the loop is supposed to be enabled
                    if (map1[i] == true)
                    {
                        //Enable the grapplepoint on the map
                        rend.material = enabledMat;
                        grappleMap[i].layer = 9;
                    }
                    else //If it should be disabled
                    {
                        //Disable the grapplepoint on the map
                        rend.material = disabledMat;
                        grappleMap[i].layer = 0;
                    }

                    //Set the portal's trigger and particle system's positions to be at either portPlace1, 2 or 3's positions.
                    portParticle.position = portTrigger.position = portPlace1.position;
                    portParticle.rotation = portTrigger.rotation = portPlace1.rotation;

                }
                break;
            */
            case 0:
                for(int i = 0; i < grappleMap.Length; i++)
                {
                    Renderer rend = grappleMap[i].GetComponent<Renderer>();
                    portMap.position = new Vector3(-110f, 75f, -92.5f);
                    if (map1[i] == true)
                    {
                        rend.material = enabledMat;
                        grappleMap[i].layer = 9;
                    }
                    else
                    {
                        rend.material = disabledMat;
                        grappleMap[i].layer = 0;
                    }

                    portParticle.position = portTrigger.position = portPlace1.position;
                    portParticle.rotation = portTrigger.rotation = portPlace1.rotation;

                }
                break;
            case 1:
                for (int i = 0; i < grappleMap.Length; i++)
                {
                    Renderer rend = grappleMap[i].GetComponent<Renderer>();
                    portMap.position = new Vector3(-70, 85, -92.5f);
                    if (map2[i] == true)
                    {
                        rend.material = enabledMat;
                        grappleMap[i].layer = 9;
                    }
                    else
                    {
                        rend.material = disabledMat;
                        grappleMap[i].layer = 0;
                    }

                    portParticle.position = portTrigger.position = portPlace2.position;
                    portParticle.rotation = portTrigger.rotation = portPlace2.rotation;

                }
                break;
            case 2:
                for (int i = 0; i < grappleMap.Length; i++)
                {
                    Renderer rend = grappleMap[i].GetComponent<Renderer>();
                    portMap.position = new Vector3(-70, 85, -92.5f);
                    if (map3[i] == true)
                    {
                        rend.material = enabledMat;
                        grappleMap[i].layer = 9;
                    }
                    else
                    {
                        rend.material = disabledMat;
                        grappleMap[i].layer = 0;
                    }

                    portParticle.position = portTrigger.position = portPlace2.position;
                    portParticle.rotation = portTrigger.rotation = portPlace2.rotation;

                }
                break;
            case 3:
                for (int i = 0; i < grappleMap.Length; i++)
                {
                    Renderer rend = grappleMap[i].GetComponent<Renderer>();
                    portMap.position = new Vector3(-30, 75, -92.5f);
                    if (map4[i] == true)
                    {
                        rend.material = enabledMat;
                        grappleMap[i].layer = 9;
                    }
                    else
                    {
                        rend.material = disabledMat;
                        grappleMap[i].layer = 0;
                    }

                    portParticle.position = portTrigger.position = portPlace3.position;
                    portParticle.rotation = portTrigger.rotation = portPlace3.rotation;

                }
                break;
        }
        //Go through each point on the map
        for(int j = 0; j < grappleMap.Length; j++)
        {
            //Set the grapplepoint's layer, but not the material.
            grapplePoints[j].layer = grappleMap[j].layer;
        }
    }
}
