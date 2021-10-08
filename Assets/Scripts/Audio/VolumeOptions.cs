using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeOptions : MonoBehaviour
{
    public Slider audio;
    public InputField audiotxt;

    // Start is called before the first frame update
    void Start()
    {
        //set the starting value
        audio.value = PlayerPrefs.GetFloat("mVolume", 0.5f);
        //set the listener for when the inputfield is changed
        audiotxt.onValueChanged.AddListener(delegate { musicChangeCheck(); });
    }

    // Update is called once per frame
    void Update()
    {
        //convert the slider value to the input value's text
        audiotxt.text = Mathf.Round(audio.value * 100).ToString();
        //Set the playerprefs float
        PlayerPrefs.SetFloat("mVolume", audio.value);
    }

    void musicChangeCheck()
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
