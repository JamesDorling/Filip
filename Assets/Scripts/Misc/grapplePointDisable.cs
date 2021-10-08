using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grapplePointDisable : MonoBehaviour
{
    public pressurePlate press;

    public Material Emat;
    public Material Dmat;

    public GameObject gp;
    private Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(press.pressed > 0)
        {
            Enable();
        }
        else if(press.pressed == 0)
        {
            Disable();
        }
    }

    void Enable()
    {
        gp.layer = 9;
        rend.material = Emat;
    }

    void Disable()
    {
        gp.layer = 12;
        rend.material = Dmat;
    }
}
