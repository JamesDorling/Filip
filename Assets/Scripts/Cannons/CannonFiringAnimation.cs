using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonFiringAnimation : MonoBehaviour
{
    //cannon's trigger script
    public CannonTrigger trig;
    //Transform of the parent object of the moving parts
    private Transform parts;
    //speed to spin at
    private float speed = 0.25f;


    void Start()
    {
        //Get the cannon's parts
        parts = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //if the game is not paused
        if (inGameMenu.GamePaused == false)
        {
            //If the cannon is charging to fire
            if (trig.firing == true)
            {
                //Increase the rotation speed with a lerp
                speed = Mathf.Lerp(speed, 10.0f, 1.0f * Time.deltaTime);
                //rotate the parts with the "speed" value
                parts.transform.Rotate(0.0f, speed, 0.0f, Space.Self);
                //Debug.Log("FiringAnimation");
            }
            else
            {
                //Decrease the rotation speed with a lerp
                speed = Mathf.Lerp(speed, 0.25f, 1.0f * Time.deltaTime);
                //rotate the parts slowly
                parts.transform.Rotate(0.0f, speed, 0.0f, Space.Self);
            }
        }
    }
}
