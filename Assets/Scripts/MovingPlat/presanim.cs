using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class presanim : MonoBehaviour
{
    //pressure plate script
    public pressurePlate press;

    //position of the platform
    private Transform pos;
    //boundaries of the movement
    private Vector2 bounds;

    // Start is called before the first frame update
    void Start()
    {
        //Get the position of the platform
        pos = GetComponent<Transform>();
        //Set the boundaries (From the subclass)
        bounds = setBounds();
    }

    // Update is called once per frame
   void Update()
   {
        //If the pressure plate is pressed
        if (press.pressed > 0)
        {
            //Move the block down
            pos.position = new Vector3(pos.position.x, Mathf.Lerp(pos.position.y, bounds.x, setSpeed() * Time.deltaTime), pos.position.z);
        }
        else //if the plate is not pressed
        {
            //Move the block up
            pos.position = new Vector3(pos.position.x, Mathf.Lerp(pos.position.y, bounds.y, setSpeed() * Time.deltaTime), pos.position.z);
        }
   }

    //virtual functions for the speed at which to move the platform and the boundaries of the movement.
    public virtual Vector2 setBounds() { return new Vector2(0f, 0f); }
    public virtual float setSpeed() { return 1.2f; }
}

