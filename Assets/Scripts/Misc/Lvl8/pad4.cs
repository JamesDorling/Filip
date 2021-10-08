using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pad4 : invertPad
{
    public override void setChangeables()
    {
        //Set the changeables of the fourth pad
        changeables = new int[3];
        changeables[0] = 2;
        changeables[1] = 3;
        changeables[2] = 4;
    }
}
