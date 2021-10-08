using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timerPosSetter : MonoBehaviour
{
    //In menu timer position
    public GameObject inMenu;
    //Top left timer position
    public GameObject tLeft;
    //Top right timer position
    public GameObject tRight;
    //Desired position (A mode counter,0 is in menu, 1 top left, 2 top right. Timer is always in the menu, too.)
    private int desiredPos;
    //Boolean for if the menu is open
    private bool menuOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        //Get the desired position
        desiredPos = PlayerPrefs.GetInt("timerPos");
        switch (desiredPos)
        {
            case 0: //Case 0 is only in menu.
                //inMenu.SetActive(true);
                tLeft.SetActive(false); //Top left is false
                tRight.SetActive(false);//Top right is false
                break;
            case 1: //Case 1 is top left of the screen
                //inMenu.SetActive(false);
                tLeft.SetActive(true);  //Top left is true
                tRight.SetActive(false);//Top right is false
                break;
            case 2: //Case 2 is top right of the screen
                //inMenu.SetActive(false);
                tLeft.SetActive(false);//Top left is false
                tRight.SetActive(true);//Top right is true
                break;
        }
    }

    void Update()
    {
        //When escape is pressed, if the menu is closed
        if(Input.GetKeyDown(KeyCode.Escape) && menuOpen == false)
        {
            menuOpen = true; //Set the menu to be open
            openMenu(); //Open the menu
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && menuOpen == true) //If escape is pressed and the menu is open
        {
            menuOpen = false; //Set the menu to be closed
            closeMenu(); //Close the menu
        }
    }

    void openMenu()
    {
        inMenu.SetActive(true); //Enable the menu timer
        tLeft.SetActive(false); //Disable the top left timer
        tRight.SetActive(false); //Disable the top right timer
    }

    void closeMenu()
    {
        switch (desiredPos)
        {
            case 0: //Case 0 is only in menu.
                //inMenu.SetActive(true);
                tLeft.SetActive(false); //Top left is false
                tRight.SetActive(false);//Top right is false
                break;
            case 1: //Case 1 is top left of the screen
                //inMenu.SetActive(false);
                tLeft.SetActive(true);  //Top left is true
                tRight.SetActive(false);//Top right is false
                break;
            case 2: //Case 2 is top right of the screen
                //inMenu.SetActive(false);
                tLeft.SetActive(false);//Top left is false
                tRight.SetActive(true);//Top right is true
                break;
        }
    }
}
