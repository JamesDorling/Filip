using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class optionsSens : MonoBehaviour
{
    //Sensitivity slider
    public Slider sens;
    //Input text to the right of the slider
    public InputField inputtxt;

    // Start is called before the first frame update
    void Start()
    {
        //Get the preset sensitivity value and set the slider's value to it
        sens.value = PlayerPrefs.GetFloat("Sens", 80f);
        //Set the input text's listener to sensChangeCheck
        inputtxt.onValueChanged.AddListener(delegate {sensChangeCheck(); });
    }

    // Update is called once per frame
    void Update()
    {
        //Set the input text's text to the slider's value
        inputtxt.text = sens.value.ToString();
        //Set the sensitivity float to the slider's value
        PlayerPrefs.SetFloat("Sens", sens.value);
    }

    void sensChangeCheck()
    {
        //Predefine a float
        float i;
        //Try and read that float as a string, if that fails
        if (!float.TryParse(inputtxt.text, out i))
        {
            sens.value = 0; //Set the slider's value to 0
        }
        else //If that succeeds
        {
            sens.value = i; //Set the slider's value to the read value
        }
    }
}
