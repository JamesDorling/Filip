using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionPrinter : MonoBehaviour
{
    //Object's position
    private Transform pos;
    // Start is called before the first frame update
    void Start()
    {
        //Get the object's position
        pos = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //Print the objects position (Used for debugging)
        Debug.Log(pos.position);
    }
}
