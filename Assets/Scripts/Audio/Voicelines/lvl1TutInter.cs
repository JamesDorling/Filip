using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class lvl1TutInter : MonoBehaviour
{
    //Interrupted bool, to check if the player has left the starting platform during the tutorial
    private bool interrupted = false;
    //Level1's audio
    public lvl1Audio sound;
    //Audiosource for the tutorial
    private AudioSource src;
    //Intro clip
    public AudioClip intro;
    //Progress through the clip
    float progress;

    void Start()
    {
        //Get the audio source
        src = sound.getSource("Intro");
    }

    void OnTriggerExit(Collider col)
    {
        //If the player leaves the trigger
        if (col.gameObject.tag == "Player")
        {
            //If the clip hasnt already been interrupted/finished
            if (src.clip == intro && src.isPlaying && interrupted == false)
            {
                //Get the current progress of the audio
                progress = src.time;
                //pause the audio
                sound.Pause("Intro");
                //play the interrupt audio
                sound.Play("Interrupt");
                //start a coroutine to restart the tutorial audio
                StartCoroutine(TutorialRestarter());
            }
        }
    }

    IEnumerator TutorialRestarter()
    {
        //Set interrupted to true so it only happens once
        interrupted = true;
        //wait for the interrupt audioclip to stop
        yield return new WaitForSeconds(4);
        //Play the tutorial from where it left off.
        sound.Play("Intro", progress);
    }
}
