using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pad6 : invertPad
{
    public override void setChangeables()
    {
        //Set the changeables of the sixth pad
        changeables = new int[3];
        changeables[0] = 4;
        changeables[1] = 5;
        changeables[2] = 6;
    }
}
