using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftWall1 : presanim
{
    public override Vector2 setBounds()
    {
        //Set the moving platform's movement boundaries (Called in the base class)
        return new Vector2(61, 57);
    }
}

