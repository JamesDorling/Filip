using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class crosshairCol : MonoBehaviour
{
    //Crosshair image
    private Image cross;

    // Start is called before the first frame update
    void Start()
    {
        //Get the crosshair image
        cross = GetComponent<Image>();
        //Set the crosshair colour to the one defined in the settings
        cross.color = new Color(PlayerPrefs.GetFloat("CHR", 255) / 255, PlayerPrefs.GetFloat("CHG", 255) / 255, PlayerPrefs.GetFloat("CHB", 255) / 255);
    }
}
