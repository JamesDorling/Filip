using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sfxSetter : MonoBehaviour
{
    private AudioSource audio;
    // Start is called before the first frame update
    void Awake()
    {
        //
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        //Set the audio volume (Called in update because I was thinking about making it changeable in game.)
        float i = PlayerPrefs.GetFloat("sfxVolume");
        audio.volume = i;
    }
}
