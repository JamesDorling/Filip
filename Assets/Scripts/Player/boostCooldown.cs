using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class boostCooldown : MonoBehaviour
{
    //Bar slider
    private Slider slide;

    //Back image of the slider
    public Image back;
    //Bar image
    public Image bar;

    //Is it on cooldown?
    private bool cool = false;

    void Start()
    {
        //Get the slider component
        slide = GetComponent<Slider>();
        //Back colour of the slider
        back.color = new Color(0.87f, 0.937f, 0.96f);
    }

    // Update is called once per frame
    void Update()
    {
        //If the slider is on cooldown
        if(slide.value < 3 && cool == true)
        {
            //Count up the slider value by adding the deltaTime
            slide.value += Time.deltaTime;
        }
        if(slide.value >= 3) //Else if the cooldown has ended
        {
            //End the cooldown
            cool = false;
        }

        if(cool == false) //If not on cooldown
        {
            //Set the colour's opacity to become mostly invisible
            back.color = new Color(back.color.r, back.color.g, back.color.b, Mathf.Lerp(back.color.a, 0.05f, 2f * Time.deltaTime));
            bar.color = new Color(bar.color.r, bar.color.g, bar.color.b,     Mathf.Lerp(bar.color.a,  0.1f, 2f * Time.deltaTime));
        }
        else if (cool == true) //Else if on cooldown
        {
            //Make the cooldown bar visible
            back.color = new Color(back.color.r, back.color.g, back.color.b, Mathf.Lerp(back.color.a, 0.2f, 2f * Time.deltaTime));
            bar.color = new Color(bar.color.r, bar.color.g, bar.color.b,     Mathf.Lerp(bar.color.a,  0.5f, 2f * Time.deltaTime));
        }
        //deeff5  <----- Hex code of the bar  
    }

    public void boost()
    {
        //Set the slide cooldown to 0
        slide.value = 0;
        //Set cooldown to true
        cool = true;
    }
}
