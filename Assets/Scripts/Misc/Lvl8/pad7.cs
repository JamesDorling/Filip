using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pad7 : invertPad
{
    public override void setChangeables()
    {
        //Set the changeables of the seventh pad
        changeables = new int[3];
        changeables[0] = 5;
        changeables[1] = 6;
        changeables[2] = 0;
    }
}
