using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    //float of time
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        //start time at 0
        time = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        //Add deltatime to make a timer
        time += Time.deltaTime;
    }

    public float getTime()
    {
        //Return the time value
        return time;
    }

    
}
