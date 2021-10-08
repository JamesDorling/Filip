using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class portal : MonoBehaviour
{
    //Virtual getter for the portal's state, unused but still here for future endeavours
    public virtual bool getPortalState() { return true; }

    //Level completion script
    public LevelComplete lvlcomp;
    //Crosshair gameobject
    public GameObject cross;
    //Menu parent gameobject
    public GameObject menu;
    //boost bar gameobject
    public GameObject boost;
    //Timer in the top left of the menu
    public GameObject timerTL;
    //Timer in the top right of the game
    public GameObject timerTR;
    //Should the screen be fading?
    bool fadeScreen = false;
    //Sound manager
    public lvl8Audio sound;
    //Image to fade the screen with
    public Image screenFade;
    //Loading screen
    public GameObject loadScreen;
    //Loading bar on the loadscreen
    public Slider loadBar;


    private void OnTriggerEnter(Collider col)
    {
        //If the player hits an active trigger
        if(col.gameObject.tag == "Player" && getPortalState() == true)
        {
            //Complete the level with the levelComplete script
            lvlcomp.complete();
            //Load the next scene if it is not level 8
            if (SceneManager.GetActiveScene().buildIndex < 9 && SceneManager.GetActiveScene().buildIndex > 1)
                StartCoroutine(Loader(SceneManager.GetActiveScene().buildIndex + 1));
            else if (SceneManager.GetActiveScene().buildIndex == 9) //If it is level 8 then load the main menu after a delay
                StartCoroutine(LateLoaderLevel8());

        }
    }

    private void Update()
    {
        //if the screen should be fading then increase the screenfade image's opacity over time
        if(fadeScreen)
            screenFade.color = new Vector4(screenFade.color.r, screenFade.color.g, screenFade.color.b, Mathf.Lerp(screenFade.color.a, 1.0f, 1 * Time.deltaTime));
    }

    IEnumerator Loader(int sceneIndex)
    {
        //Set the timescale to 0
        Time.timeScale = 0;
        //Make the UI entirely inactive
        cross.SetActive(false);
        menu.SetActive(false);
        boost.SetActive(false);
        timerTL.SetActive(false);
        timerTR.SetActive(false);
        //Make the loadscreen active
        loadScreen.SetActive(true);
        //load the given scene asyncronously, meaning alongside without closing the open scene
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        //While the given scene has not yet loaded
        while (!operation.isDone)
        {
            //Get the progress / 0.9 to make it go from 0-1 rather than 0-0.9
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            //Set the slider value 
            loadBar.value = progress;
            //yield return for a frame
            yield return null;
        }
        //Restart the timescale, just in case
        Time.timeScale = 1;
    }
    //LateLoaderLevel8 is a function called on level 8 to allow for a voiceline before loading the menu.
    IEnumerator LateLoaderLevel8()
    {
        //Set fadescreen to true
        fadeScreen = true;
        //Wait for a second
        yield return new WaitForSeconds(1);
        //Play the final voiceline
        sound.Play("Final");
        //wait for 4 seconds
        yield return new WaitForSeconds(4);
        //Load the menu
        StartCoroutine(Loader(0));
    }
}
