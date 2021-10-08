using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvl1Audio : AudioManagerBase
{
    //Same as lvl8 audio. I found out after making them all that they could be the same script, and because this wont have a negative effect on the game but would take a while to fix I did not fix it.
    void Start()
    {
        Play("Intro"); //Play the intro immediately
    }
}
