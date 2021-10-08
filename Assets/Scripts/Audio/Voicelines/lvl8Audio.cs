using UnityEngine.Audio;
using UnityEngine;

public class lvl8Audio : AudioManagerBase
{
    //Same as level1 audio, however this is applied to all other levels. 
    void Start()
    {
        //Play the level intro at the start.
        Play("Intro");
    }
}
