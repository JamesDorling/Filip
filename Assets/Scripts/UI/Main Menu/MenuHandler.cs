using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    //Main menu parent object
    public GameObject MainMenu;
    //Options menu parent object
    public GameObject Options;
    //Quit menu parent object
    public GameObject QuitSure;
    //Levels menu parent object
    public GameObject Saves;
    //Loading screen parent object
    public GameObject loadScreen;
    //Loadbar on the loadscreen
    public Slider loadBar;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None; //Lock the cursor to the middle of the screen
        Cursor.visible = true; //Make the cursor invisible
    }

    public void LoadMainMenu()
    {
        MainMenu.SetActive(true); //Set the main menu to true
        Options.SetActive(false); //Set the options menu to false
        QuitSure.SetActive(false);//Set the quit menu to false
        Saves.SetActive(false);   //Set the levels menu to false
    }

    public void LoadOptions()
    {
        MainMenu.SetActive(false);//Set the main menu to false
        Options.SetActive(true);  //Set the options menu to true
        QuitSure.SetActive(false);//Set the quit menu to false
        Saves.SetActive(false);   //Set the levels menu to false
    }

    public void LoadSavesScreen()
    {
        MainMenu.SetActive(false);//Set the main menu to false
        Options.SetActive(false); //Set the options menu to false
        QuitSure.SetActive(false);//Set the quit menu to false
        Saves.SetActive(true);    //Set the levels menu to true
    }

    public void QuitScreen()
    {
        MainMenu.SetActive(false);//Set the main menu to false
        Options.SetActive(false); //Set the options menu to false
        QuitSure.SetActive(true); //Set the quit menu to true
        Saves.SetActive(false);   //Set the levels menu to false
    }

    public void Quit()
    {
        //Get the current scene
        Scene scene = SceneManager.GetActiveScene();
        //If the player is on the main menu
        if (scene.buildIndex == 0)
        {
            //Close the application
            Application.Quit();
        }
    }

    public void level1load()
    {
        StartCoroutine(Loader(2)); //Load the specified level
    }

    public void level2load()
    {
        StartCoroutine(Loader(3)); //Load the specified level
    }

    public void level3load()
    {
        StartCoroutine(Loader(4)); //Load the specified level
    }

    public void level4load()
    {
        StartCoroutine(Loader(5)); //Load the specified level
    }

    public void level5load()
    { 
        StartCoroutine(Loader(6)); //Load the specified level
    }

    public void level6load()
    {
        StartCoroutine(Loader(7)); //Load the specified level
    }

    public void level7load()
    {
        StartCoroutine(Loader(8)); //Load the specified level
    }

    public void level8load()
    {
        StartCoroutine(Loader(9)); //Load the specified level
    }

    public void levelSecretload()
    {
        StartCoroutine(Loader(1)); //Load the specified level
    }

    IEnumerator Loader(int sceneIndex)
    {
        //Set the UI as inactive
        MainMenu.SetActive(false);
        Options.SetActive(false);
        QuitSure.SetActive(false);
        Saves.SetActive(false);
        //Set the loadscreen as active
        loadScreen.SetActive(true);
        //Load the level asyncronously
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        //While the level has not finished loading
        while (!operation.isDone)
        {
            //Get the progress and clamp it to between 0 and 1 (Times 0.9 so it goes from 0 to 1 rather than 0 to 0.9)
            float progress = Mathf.Clamp01(operation.progress / .9f);
            //Set the loadbar's value to the progress value
            loadBar.value = progress;

            //Wait for a frame before doing it again
            yield return null;
        }
    }
}
