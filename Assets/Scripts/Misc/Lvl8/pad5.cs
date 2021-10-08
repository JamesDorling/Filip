using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pad5 : invertPad
{
    public override void setChangeables()
    {
        //Set the changeables of the fifth pad
        changeables = new int[3];
        changeables[0] = 3;
        changeables[1] = 4;
        changeables[2] = 5;
    }
}