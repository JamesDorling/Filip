using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timerSetter : MonoBehaviour
{
    //Timer's text
    private Text text;
    //timer script
    public timer time;
    // Start is called before the first frame update
    void Start()
    {
        //Get the text component
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //If the time passed is less than 1000
        if (time.getTime() <= 1000)
        {
            //Round the timer and set the text to display it
            text.text = (Mathf.Round(time.getTime() * 100) / 100).ToString();
        }
        else //if the time is higher than 1000
        {
            //Set the text to say >1000
            text.text = ">1000";
        }
    }
}
