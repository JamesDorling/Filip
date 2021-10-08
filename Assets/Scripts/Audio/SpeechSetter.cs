using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechSetter : MonoBehaviour
{
    //This code is barely used, as the audiomanager handles most of this.

    //audiosource to change the volume of
    private AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        //get the audiosource
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        //Set the audiovolume (Called in update because I was thinking about making it changeable in game.)
        float i = PlayerPrefs.GetFloat("sVolume");
        audio.volume = i;
    }
}
