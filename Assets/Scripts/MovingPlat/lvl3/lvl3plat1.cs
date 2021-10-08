using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvl3plat1 : presanim
{
    public override Vector2 setBounds()
    {
        //set the boundaries of the first moving platform
        return new Vector2(3f, -15f);
    }
}