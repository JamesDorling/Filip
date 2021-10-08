using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turbo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        if(Input.GetKey(KeyCode.E))
        {
            Time.timeScale = 5;
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            Time.timeScale = 0.05f;
        }
        else if(inGameMenu.GamePaused == false)
        {
            Time.timeScale = 1;
        }
#endif
    }
}
