using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pad3 : invertPad
{
    public override void setChangeables()
    {
        //Set the changeables of the third pad
        changeables = new int[3];
        changeables[0] = 1;
        changeables[1] = 2;
        changeables[2] = 3;
    }
}
