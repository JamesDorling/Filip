using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetColourSwap : MonoBehaviour
{
    //left block
    public GameObject left;
    //right block
    public GameObject right;

    //Red and green materials
    public Material red;
    public Material green;

    //bool to track the current colour
    private bool swapper = false;
    //bool of if it is swapping
    private bool swapping = false;

    // Update is called once per frame
    void Update()
    {
        //if it is not currently swapping,  make it swap
        if (swapping == false)
            StartCoroutine(swap());
    }

    IEnumerator swap()
    {
        //set swapping to true so it only happens once at a time
        swapping = true;
        //wait for 2 seconds
        yield return new WaitForSeconds(2);
        //set the swap cycle
        swapper = !swapper;
        //use the swap cycle to change the colours
        switch(swapper)
        {
            case true: //Set left to green and right to red
                left.GetComponent<Renderer>().material = green;
                right.GetComponent<Renderer>().material = red;
                break;
            case false: //Set right to green and left to red
                left.GetComponent<Renderer>().material = red;
                right.GetComponent<Renderer>().material = green;
                break;
        }
        //end the swap cycle
        swapping = false;
    }
}
