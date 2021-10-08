using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class optionsCrosshair : MonoBehaviour
{
    public Slider r; //Slider for the RGB values
    public Slider g;
    public Slider b;
    public InputField rValue; //Input fields to the right of the sliders
    public InputField gValue;
    public InputField bValue;

    //Crosshair image in the options menu
    public Image cross;
    // Start is called before the first frame update
    void Start()
    {
        r.value = PlayerPrefs.GetFloat("CHR", 255); //Get the RGB values from memory and set the starting values as them
        g.value = PlayerPrefs.GetFloat("CHG", 255);
        b.value = PlayerPrefs.GetFloat("CHB", 255);
        rValue.onValueChanged.AddListener(delegate { rValueChangeCheck(); }); //Set the input field listeners for each input field
        gValue.onValueChanged.AddListener(delegate { gValueChangeCheck(); });
        bValue.onValueChanged.AddListener(delegate { bValueChangeCheck(); });
    }

    // Update is called once per frame
    void Update()
    {
        //Update the text to be the same as the slider's value
        rValue.text = r.value.ToString();
        gValue.text = g.value.ToString();
        bValue.text = b.value.ToString();

        //Set the playerpref values to the colour values
        PlayerPrefs.SetFloat("CHR", r.value);
        PlayerPrefs.SetFloat("CHG", g.value);
        PlayerPrefs.SetFloat("CHB", b.value);

        //Set the crosshair's preview colour
        cross.color = new Color(r.value / 255, g.value / 255, b.value / 255);
    }

    //WHAT FOLLOWS ARE THE LISTENERS, THEY ARE ALL THE SAME BUT CHANGE DIFFERENT VALUES. HERE ARE HOW THEY FUNCTION
    /*
    void rValueChangeCheck()
    {
        //Predefine an integer value
        int i;

        //Try and parse the integer value to text.
        if(!int.TryParse(rValue.text, out i))
        {
            //If the integer value was not parsed to text, set it to 0
            r.value = 0;
        }
        else
        {
            //If the value was read properly, pass its value to the corresponding slider
            r.value = i;
        }
    }

    */



    void rValueChangeCheck()
    {
        int i;
        if(!int.TryParse(rValue.text, out i))
        {
            r.value = 0;
        }
        else
        {
            r.value = i;
        }
    }

    void gValueChangeCheck()
    {
        int i;
        if (!int.TryParse(gValue.text, out i))
        {
            g.value = 0;
        }
        else
        {
            g.value = i;
        }
    }

    void bValueChangeCheck()
    {
        int i;
        if (!int.TryParse(bValue.text, out i))
        {
            b.value = 0;
        }
        else
        {
            b.value = i;
        }
    }
}
