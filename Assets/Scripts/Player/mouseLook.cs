using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseLook : MonoBehaviour
{
    public Transform playerDir; //Player's transform

    public movement playMove; //Player movement script

    private Quaternion desiredRotation; //Desired rotation of the camera

    float xRotation = 0f; //x axis rotation
    //float zRotation = 0f; //z axis rotation, used in the gravity switch

    public float mouseSensitivity = 80.0f; //Sensitivity


    void Start()
    {
        mouseSensitivity = PlayerPrefs.GetFloat("Sens", 80) / 100; //Get the mouse sensitivity
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(mouseSensitivity);
        if (inGameMenu.GamePaused == false)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity; //Gets the movement on the x axis
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity; //Gets the movement on the Y axis
            playerDir.Rotate(Vector3.up * mouseX); //Move the player

            xRotation -= mouseY; //minus the mouseY from xRotation to get the offset on the x axis (For looking up and down)
            xRotation = Mathf.Clamp(xRotation, -90.0f, 80.0f); //clamp the rotation, so that the player cannot look too high or low. This happens anyway, but this is just in case.
            transform.localRotation = Quaternion.Euler(xRotation, 0.0f, 0.0f); //Move the camera upwards
        }
    }
}
