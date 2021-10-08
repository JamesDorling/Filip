using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    //Timer
    public timer time;
    //Current scene to get the build index
    private Scene currentScene;
    void Start()
    {
        currentScene = SceneManager.GetActiveScene(); //Get the current scene
    }

    public void complete()
    {
        //EACH CASE IS THE SAME IN THIS SWITCH, WITH THE ONLY DIFFERENCE BEING WHAT PLAYERPREFS ARE BEING CHANGED.
        switch (currentScene.buildIndex) //Switch with the current scene's build index
        {       
            case 2:
                //If the player has beat their best time
                if (time.getTime() < PlayerPrefs.GetFloat("lvl1T", 0) || PlayerPrefs.GetFloat("lvl1T", 0) == 0)
                {
                    PlayerPrefs.SetFloat("lvl1T", (Mathf.Round(time.getTime() * 100) / 100));  //Set their best time to the newest time
                }
                //Set whether they have completed the level to true for the main menu
                PlayerPrefs.SetInt("1Complete", 1);
                break;
            case 3:
                if (time.getTime() < PlayerPrefs.GetFloat("lvl2T", 0) || PlayerPrefs.GetFloat("lvl2T", 0) == 0)
                {
                    PlayerPrefs.SetFloat("lvl2T", (Mathf.Round(time.getTime() * 100) / 100));
                }
                PlayerPrefs.SetInt("2Complete", 1);
                break;
            case 4:
                if (time.getTime() < PlayerPrefs.GetFloat("lvl3T", 0) || PlayerPrefs.GetFloat("lvl3T", 0) == 0)
                {
                    PlayerPrefs.SetFloat("lvl3T", (Mathf.Round(time.getTime() * 100) / 100));
                }
                PlayerPrefs.SetInt("3Complete", 1);
                break;
            case 5:
                if (time.getTime() < PlayerPrefs.GetFloat("lvl4T", 0) || PlayerPrefs.GetFloat("lvl4T", 0) == 0)
                {
                    PlayerPrefs.SetFloat("lvl4T", (Mathf.Round(time.getTime() * 100) / 100));
                }
                PlayerPrefs.SetInt("4Complete", 1);
                break;
            case 6:
                if (time.getTime() < PlayerPrefs.GetFloat("lvl5T", 0) || PlayerPrefs.GetFloat("lvl5T", 0) == 0)
                {
                    PlayerPrefs.SetFloat("lvl5T", (Mathf.Round(time.getTime() * 100) / 100));
                }
                PlayerPrefs.SetInt("5Complete", 1);
                break;
            case 7:
                if (time.getTime() < PlayerPrefs.GetFloat("lvl6T", 0) || PlayerPrefs.GetFloat("lvl6T", 0) == 0)
                {
                    PlayerPrefs.SetFloat("lvl6T", (Mathf.Round(time.getTime() * 100) / 100));
                }
                PlayerPrefs.SetInt("6Complete", 1);
                break;
            case 8:
                if (time.getTime() < PlayerPrefs.GetFloat("lvl7T", 0) || PlayerPrefs.GetFloat("lvl7T", 0) == 0)
                {
                    PlayerPrefs.SetFloat("lvl7T", (Mathf.Round(time.getTime() * 100) / 100));
                }
                PlayerPrefs.SetInt("7Complete", 1);
                break;
            case 9:
                if (time.getTime() < PlayerPrefs.GetFloat("lvl8T", 0) || PlayerPrefs.GetFloat("lvl8T", 0) == 0)
                {
                    PlayerPrefs.SetFloat("lvl8T", (Mathf.Round(time.getTime() * 100) / 100));
                }
                PlayerPrefs.SetInt("8Complete", 1);
                break;
            default:
                break;
        }

    }
}
