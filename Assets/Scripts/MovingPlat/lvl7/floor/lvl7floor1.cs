using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvl7floor1 : presanim
{
    //This is not used anymore, and has been replaced with a rotation script. This is because the ball would fall through the platform too easily with this.
    public override Vector2 setBounds()
    {
        return new Vector2(4.66f, 4.66f); //Set the boundaries of the platform
    }

    public override float setSpeed()
    {
        return 5f; //set the platform's speed
    }
}
