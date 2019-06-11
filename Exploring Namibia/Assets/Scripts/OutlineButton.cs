using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutlineButton : MonoBehaviour
{
    public Button button;
    
    public void OnMouseOver()
    {
        button.GetComponent<Outline>().enabled = true;
    }

    public void OnMouseExit()
    {
        button.GetComponent<Outline>().enabled = false;
    }
}
