using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sfxSettings : MonoBehaviour
{
    //SFX slider
    public Slider audio;
    //Input field to the right of the slider
    public InputField audiotxt;

    // Start is called before the first frame update
    void Start()
    {
        //Set the starting value
        audio.value = PlayerPrefs.GetFloat("sfxVolume", 1f);
        //set the listener for when the inputfield is changed
        audiotxt.onValueChanged.AddListener(delegate { sfxChangeCheck(); });
    }

    // Update is called once per frame
    void Update()
    {
        //convert the slider value to the input value's text
        audiotxt.text = Mathf.Round(audio.value * 100).ToString();
        //Set the playerprefs float
        PlayerPrefs.SetFloat("sfxVolume", audio.value);
    }

    void sfxChangeCheck()
    {
        //get the input value
        float i;
        //if the value couldnt be read/was invalid
        if (!float.TryParse(audiotxt.text, out i))
        {
            //set audio to 0
            audio.value = 0;
        }
        else //if it was read and was valid
        {
            //set the slider value
            audio.value = i / 100;
        }
    }
}
