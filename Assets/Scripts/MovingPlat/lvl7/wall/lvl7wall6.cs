using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvl7wall6 : wallVertMove
{
    public override Vector2 setBounds()
    {
        //Set the platform's movement boundaries (Called in the base class)
        //return new Vector2(29.5f, 32.5f);
        return new Vector2(24.5f, 22.5f);
    }
}
