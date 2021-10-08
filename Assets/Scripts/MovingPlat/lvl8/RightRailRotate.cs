using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightRailRotate : MonoBehaviour
{
    //Pressure plate's script
    public pressurePlate press1;

    //Speed to rotate at
    private float speed = 100;
    //Transform of the rotatable
    private Transform pos;

    void Start()
    {
        //Get the rotatable platform's transform
        pos = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //If the pressure pad is pressed and the block is not at the bounds yet
        if (press1.pressed > 0 && pos.rotation.eulerAngles.x > 15)
        {
            //Rotate the block clockwise
            pos.Rotate(new Vector3(-speed * Time.deltaTime, 0, 0));
            //Debug.Log("Pressed");
        }
        else if (press1.pressed == 0) //If it is not pressed
        {
            //if the block is not at the higher bounds
            if (pos.rotation.eulerAngles.x < 89)
            {
                //Rotate the block counter-clockwise
                pos.Rotate(new Vector3(speed * Time.deltaTime, 0, 0));
                //Debug.Log("Not Pressed");
            }
        }
    }
}
