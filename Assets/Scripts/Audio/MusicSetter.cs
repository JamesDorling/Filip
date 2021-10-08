using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSetter : MonoBehaviour
{
    //Audiosource to set the volume of
    private AudioSource audio;
    // Start is called before the first frame update
    void Start()
    { //Get the audiosource
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        //Set the audio volume (Called in update because I was thinking about making it changeable in game.)
        float i = PlayerPrefs.GetFloat("mVolume");
        audio.volume = i;
    }
}
