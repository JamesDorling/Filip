using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvl7wall1 : presanim
{
    public override Vector2 setBounds()
    {
        //Set the platform's movement boundaries (Called in the base class)
        //return new Vector2(42.75f, 45.75f);
        return new Vector2(45.75f, 42.75f);
    }
}
