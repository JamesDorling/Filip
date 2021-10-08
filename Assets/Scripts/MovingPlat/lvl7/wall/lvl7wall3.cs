using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvl7wall3 : presanim
{
    public override Vector2 setBounds()
    {
        //Set the platform's movement boundaries (Called in the base class)
        return new Vector2(52.5f, 50f);
    }
}
