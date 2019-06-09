using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapControl : MonoBehaviour
{
    public Button buttonMinigame1;
    public Image minigame1Check;

    private void Start()
    {
        if(PlayerPrefs.GetInt("minigame1") == 1)
        {
            minigame1Check.gameObject.SetActive(true);
        }
    }

    //For revealing Minigames when clicking on Minigame Button
    public void RevealMinigames()
    {
        if (buttonMinigame1.gameObject.activeSelf == false)
        {
            buttonMinigame1.gameObject.SetActive(true);
        }
        else if (buttonMinigame1.gameObject.activeSelf == true)
        {
            buttonMinigame1.gameObject.SetActive(false);
        }
    }
}
