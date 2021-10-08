using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvl7checkpoint : MonoBehaviour
{
    //Pressure plate script
    public pressurePlate press;

    //Spawn point location
    public Transform spawn;
    //Second spawn point location
    private Vector3 sLocation2;

    void Start()
    {
        //Get the second spawnpoint location
        sLocation2 = GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        //If the pressure plate gets pressed
        if (press.pressed > 0)
        {
            //Update the spawnpoint location
            spawn.position = sLocation2;
        }
    }
}
