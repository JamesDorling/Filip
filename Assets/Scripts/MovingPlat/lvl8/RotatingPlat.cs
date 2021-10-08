using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlat : MonoBehaviour
{
    //Script for the special interactable on level 8

    //Platform to be rotated by the interactable's transform
    private Transform rotatable;
    //Rotatable platform's transform
    public Transform rotatedableInter;

    //Quaternion for applying the 
    Quaternion quat;
    // Start is called before the first frame update
    void Start()
    {
        //Get the rotatable's transform
        rotatable = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //Set quats eulerangles to the interactable's rotation (With the Y axis of the interactable affecting the X axis of the platform.)
        quat.eulerAngles = new Vector3(-rotatedableInter.rotation.eulerAngles.y, -90, 0);
        //Set the rotateable platform's rotation
        rotatable.rotation = quat;
    }
}
