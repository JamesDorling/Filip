using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class inGameMenu : MonoBehaviour
{
    //Crosshair icon
    public GameObject crosshair;
    //Menu parent object
    public GameObject menu;
    //Boost cooldown
    public GameObject cooldown;

    //Load screen parent object
    public GameObject loadScreen;
    //Load bar of the loadscreen
    public Slider loadBar;

    public static bool GamePaused = false;

    // Start is called before the first frame update
    void Start()
    {
        //Set the timescale to 1 with the pauser function
        Pauser();
    }

    // Update is called once per frame
    void Update()
    {
        //If escape is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Pause the game if paused, unpause if not
            GamePaused = !GamePaused;
            //Set the timescale with "Pauser()"
            Pauser();
            //Invert the menu's enabled value
            menu.SetActive(!menu.activeSelf);
            //Invert the crosshair's enabled value
            crosshair.SetActive(!crosshair.activeSelf);
            //Invert the cooldown bar's enabled value
            cooldown.SetActive(!cooldown.activeSelf);
        }
        if(menu.activeSelf)
        {
            Cursor.lockState = CursorLockMode.None; //unlock the cursor
            Cursor.visible = true; //Make the cursor visible
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked; //Lock the cursor to the middle of the screen
            Cursor.visible = false; //Make the cursor invisible
        }
    }

    public void quitToMenu()
    {
        GamePaused = false; //Unpause the game
        StartCoroutine(Loader(0)); //Load the menu
    }

    void Pauser()
    {
        //If the game is paused
        switch(GamePaused)
        {
            case true: //Set the time scale to 0, pausing time
                Time.timeScale = 0f;
                break;
            case false: //else set it to 1, making the time run as normal
                Time.timeScale = 1f;
                break;
        }
    }

    IEnumerator Loader(int sceneIndex)
    {
        //Disable the UI, and enable the loading screen
        crosshair.SetActive(false);
        menu.SetActive(false);
        cooldown.SetActive(false);
        loadScreen.SetActive(true);
        //Load the menu asyncronously (Thats seriously difficult to spell)
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        //While the level has not yet loaded
        while (!operation.isDone)
        {
            //Get the progress and clamp it between 0 and 1 (divide it by 0.9 to make it go from 0 to 1 rather than 0 to 0.9)
            float progress = Mathf.Clamp01(operation.progress / .9f);
            //set the loadbar value
            loadBar.value = progress;
            //wait a frame before doing this again
            yield return null;
        }
    }
}
