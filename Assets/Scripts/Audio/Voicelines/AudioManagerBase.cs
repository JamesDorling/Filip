using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManagerBase : MonoBehaviour
{
    //Soundclips array, stores each soundclip, name of the soundclip, and the audiosource its in.
    public soundClip[] clips;

    //Needed for pausing
    bool paused = false;
    //Index of the sound that was playing when the game paused.
    string index;
    //Progress through the soundclip (Time)
    float progress;

    void Awake()
    {
        //Get the desired volume
        float vol = PlayerPrefs.GetFloat("sVolume", 50);
        //Run through each sound clip
        foreach (soundClip s in clips)
        {
            //Give it an audio source
            s.src = gameObject.AddComponent<AudioSource>();
            //Give the audiosource the sound clip
            s.src.clip = s.clip;
            //Set the audiosource's volume
            s.src.volume = vol;
        }
    }

    void Update()
    {
        //If the game is paused but the soundmanager isnt yet
        if(inGameMenu.GamePaused == true && paused == false)
        {
            //Pause the sound manager.
            gamePaused();
        }//If the sound manager is paused but the game isnt
        else if(inGameMenu.GamePaused == false && paused == true)
        {
            //Play the sound again
            Play(index, progress);
            //Unpause the sound manager.
            paused = false;
        }
    }
    //Play takes the name of the desired soundclip and the time to start it at, initialised at 0.
    public void Play(string name, float time = 0f)
    {
        //Find the applicable soundclip
        soundClip s = Array.Find(clips, clips => clips.name == name);
        //if the soundclip = null and therefore couldnt be found
        if (s == null)
        {
            //Log a warning
            Debug.LogWarning("Sound " + name + " not found!");
            //End the function
            return;
        }
        //Set the sound source's time (To start at a set point
        s.src.time = time;
        //Play the sound source
        s.src.Play();
        
    }
    //Pause takes the name of the clip to pause.
    public void Pause(string name)
    {
        //find the soundclip
        soundClip s = Array.Find(clips, clips => clips.name == name);
        //if the soundclip = null and therefore couldnt be found
        if (s == null)
        {
            //Log a warning
            Debug.LogWarning("Sound " + name + " not found!");
            //End the function
            return;
        }
        //Pause the sound source
        s.src.Pause();
    }

    public AudioSource getSource(string name)
    {
        soundClip s = Array.Find(clips, clips => clips.name == name);
        //if the soundclip = null and therefore couldnt be found
        if (s == null)
        {
            //Log a warning
            Debug.LogWarning("Sound " + name + " not found!");
            //End the function
            return null;
        }
        //Return the sound source
        return s.src;
    }

    //gamePaused() is called whenever the game has paused to pause the audio. However, this will not work too well if there are multiple sound sources playing. But it doesnt really need to.
    private void gamePaused()
    {
        //Only one clip should be playing at a time
        paused = true; //set paused to true
        //Debug.Log("Pausing");
        //Go through each soundclip
        foreach (soundClip s in clips) //For each sound clip
        {
            //If this soundclip is playing
            if(s.src.isPlaying == true) //Check if its playing
            {
                index = s.name; //Get the name
                progress = s.src.time; //Make sure its playing at the right bit
                Pause(index); //Pause the clip
            }
        }
    }
}
