using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPortalOn : MonoBehaviour
{
    //Final portal particle system
    private ParticleSystem sys;
    //Portal position
    private Transform pos;
    //Player's position
    public Transform ply;

    // Start is called before the first frame update
    void Start()
    {
        //Get the particle system
        sys = GetComponent<ParticleSystem>();
        //get the portal transform component
        pos = GetComponent<Transform>();
        //Pause the particle system
        sys.Pause();
    }

    // Update is called once per frame
    void Update()
    {
        //If the distance between the player and the portal is low enough
        if (Vector3.Distance(ply.position, pos.position) < 300f)
        {
            //Play the particle system
            sys.Play();
        }
        else //If not
        {
            //Stop the particle system's emittion
            sys.Stop(false, ParticleSystemStopBehavior.StopEmitting);
        }
    }
}
