using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalOn : MonoBehaviour
{
    //Particle system
    private ParticleSystem sys;
    //position of the particle system
    private Transform pos;
    //Player position
    public Transform ply;

    // Start is called before the first frame update
    void Start()
    {
        //Get the particle system
        sys = GetComponent<ParticleSystem>();
        //Get the portal position
        pos = GetComponent<Transform>();
        //Pause the particle system
        sys.Pause();
    }

    // Update is called once per frame
    void Update()
    {
        //If the player is close to the portal
        if(Vector3.Distance(ply.position, pos.position) < 100f)
        {
            sys.Play(); //Play the particle system
        }
        else //If the player is far away
        {
            sys.Stop(false, ParticleSystemStopBehavior.StopEmitting); //Stop the particle system's emission
        }
    }
}
