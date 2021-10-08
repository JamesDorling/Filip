using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallRotate : MonoBehaviour
{
    //Pressure plate script
    public pressurePlate press1;

    //Speed to rotate the platform
    private float speed = 100;
    //position of the platform
    private Transform pos;

    void Start()
    {
        //get the blocks's position
        pos = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //if the plate is pressed and the position has not hit the bounds
        if (press1.pressed > 0 && pos.rotation.eulerAngles.x > 3)
        {
            //rotate the platform clockwise
            pos.Rotate(new Vector3(-speed * Time.deltaTime, 0, 0));
            //Debug.Log("Pressed");
        }
        else if (press1.pressed == 0) //if the plate is not pressed
        {
            //if the block has not hit the higher bounds
            if (pos.rotation.eulerAngles.x < 30)
            {
                //rotate counter clockwise
                pos.Rotate(new Vector3(speed * Time.deltaTime, 0, 0));
                //Debug.Log("Not Pressed");
            }
        }
    }
}
