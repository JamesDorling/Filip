using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonMouseOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //The button's transform
    private Transform button;

    //Scaler value
    private float scale = 1.2f;
    //Original scale values
    private Vector3 originalscale;

    private void Start()
    {
        //get the button's position
        button = GetComponent<Transform>();
        //store the button's original scale (Not really used anymore, but kept to show progress. If this was removed though, nothing would really change.)
        originalscale = button.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Multiply the buttons size by the scaler
        button.localScale *= scale;
        //move the button right as it grows from the centre
        button.position = new Vector3(button.position.x + 20f, button.position.y, button.position.z);
        //Debug.Log("MouseEnter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //Divide the buttons size by the scaler
        button.localScale /= scale;
        //move the button left as it shrinks from the centre
        button.position = new Vector3(button.position.x - 20f, button.position.y, button.position.z);
        //Debug.Log("MouseExit");
    }

    public void shrinkOnPress()
    {
        //Divide the buttons size by the scaler
        button.localScale /= scale;
        //move the button left as it shrinks from the centre
        button.position = new Vector3(button.position.x - 20f, button.position.y, button.position.z);
    }
}
