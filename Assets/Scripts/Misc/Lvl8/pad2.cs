using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pad2 : invertPad
{
    public override void setChangeables()
    {
        //Set the changeables of the second pad
        changeables = new int[3];
        changeables[0] = 0;
        changeables[1] = 1;
        changeables[2] = 2;
    }
}
