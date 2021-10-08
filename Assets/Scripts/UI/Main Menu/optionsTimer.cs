using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class optionsTimer : MonoBehaviour
{
    //In menu toggle button
    public Toggle inMenu;
    //Top left toggle button
    public Toggle tLeft;
    //Top right toggle button
    public Toggle tRight;

    void Start()
    {
        //Get the saved timer position
        int t = PlayerPrefs.GetInt("timerPos", 0);
        switch(t)
        {
            case 0:
                inMenu.isOn = true; //Enable the "in menu" toggle
                tLeft.isOn = false; //Disable the "top left" toggle
                tRight.isOn = false;//Disable the "top right" toggle
                break;
            case 1:
                inMenu.isOn = false;//Disable the "in menu" toggle
                tLeft.isOn = true;  //Enable the "top left" toggle
                tRight.isOn = false;//Disable the "top right" toggle
                break;
            case 2:
                inMenu.isOn = false;//Disable the "in menu" toggle
                tLeft.isOn = false; //Disable the "top left" toggle
                tRight.isOn = true; //Enable the "top right" toggle
                break;
        }
    }

    void Update()
    {
        //Debug.Log(PlayerPrefs.GetInt("timerPos", 0));
        //If none of the toggles are on
        if (inMenu.isOn == false && tLeft.isOn == false && tRight.isOn == false)
        {
            //Switch through what should be on, to not allow none to be toggled
            switch (PlayerPrefs.GetInt("timerPos", 0))
            {
                case 0:
                    inMenu.isOn = true; //Enable the "in menu" toggle
                    tLeft.isOn = false; //Disable the "top left" toggle
                    tRight.isOn = false;//Disable the "top right" toggle
                    break;
                case 1:
                    inMenu.isOn = false;//Disable the "in menu" toggle
                    tLeft.isOn = true;  //Enable the "top left" toggle
                    tRight.isOn = false;//Disable the "top right" toggle
                    break;
                case 2:
                    inMenu.isOn = false;//Disable the "in menu" toggle
                    tLeft.isOn = false; //Disable the "top left" toggle
                    tRight.isOn = true; //Enable the "top right" toggle
                    break;
            }
        }
    }

    public void InMenu()
    {
        if (inMenu.isOn)
        {
            inMenu.isOn = true; //Enable the "in menu" toggle
            tLeft.isOn = false; //Disable the "top left" toggle
            tRight.isOn = false;//Disable the "top right" toggle
            //Save this option
            PlayerPrefs.SetInt("timerPos", 0);
        }
    }

    public void TopLeft()
    {
        if (tLeft.isOn)
        {
            inMenu.isOn = false; //Disable the "in menu" toggle
            tLeft.isOn = true;   //Enable the "top left" toggle
            tRight.isOn = false; //Disable the "top right" toggle
            //Save this option
            PlayerPrefs.SetInt("timerPos", 1);
        }
    }

    public void TopRight()
    {
        if (tRight.isOn)
        {
            inMenu.isOn = false; //Disable the "in menu" toggle
            tLeft.isOn = false;  //Disable the "top left" toggle
            tRight.isOn = true;  //Enable the "top right" toggle
            //Save this option
            PlayerPrefs.SetInt("timerPos", 2);
        }
    }
}
