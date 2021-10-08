using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftFloor2 : presanim
{
    public override Vector2 setBounds()
    {
        //Set the moving platform's movement boundaries (Called in the base class)
        return new Vector2(58.82f, 50.82f);
    }
}

