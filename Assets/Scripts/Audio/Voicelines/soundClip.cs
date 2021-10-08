using UnityEngine.Audio;
using UnityEngine;

[System.Serializable] //System serialisable to edit it in the editor
public class soundClip
{
    //Name of the soundclip
    public string name;

    //Audio to play
    public AudioClip clip;

    [HideInInspector] //Hide in inspector so that the audiosource wont be editted.
    public AudioSource src; //Audiosource to play the clip
}
