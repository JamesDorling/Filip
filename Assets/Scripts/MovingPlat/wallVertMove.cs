using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallVertMove : MonoBehaviour
{
    //This script is the same as presanim, however instead of moves the blocks the opposite way. These could have been made into one script, but I actually made this script on accident and decided to keep it as it does the job.

    //Pressure plate script
    public pressurePlate press;

    //Position of the platform
    private Transform pos;
    //Boundaries for the platform's movement
    private Vector2 bounds;
    // Start is called before the first frame update
    void Start()
    {
        //get the block's position
        pos = GetComponent<Transform>();
        //get the bounds from the subclass
        bounds = setBounds();
    }

    // Update is called once per frame
    void Update()
    {
        //If the pressure plate is pressed
        if (press.pressed == 0)
        {
            //if the position is less than the higher bounds
            if (pos.position.y < bounds.x)
            {
                //move the block up
                pos.position = new Vector3(pos.position.x, Mathf.Lerp(pos.position.y, bounds.x, 2f * Time.deltaTime), pos.position.z);
            }
        }
        else
        {
            //if the block is higher than the lower bounds
            if (pos.position.y > bounds.y)
            {
                //move the block down
                pos.position = new Vector3(pos.position.x, Mathf.Lerp(pos.position.y, bounds.y, 2f * Time.deltaTime), pos.position.z);
            }
        }
    }

    //virtual funcion to set the boundaries for each individual block.
    public virtual Vector2 setBounds() { return new Vector2(0f, 0f); }
}
