﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public static bool FirstTime = true;
    private int maxVolume = 1;

    public GameObject popupPanel;

    // Start is called before the first frame update
    void Start()
    {
        if (FirstTime == true)
        {
            FirstTime = false;
            PlayerPrefs.SetFloat("volume", maxVolume);
        }
        PlayerPrefs.SetInt("minigame1", 0);
        PlayerPrefs.SetInt("minigame2", 0);
        PlayerPrefs.SetInt("rescueStation", 0);
        PlayerPrefs.SetInt("nationalpark", 0);
        PlayerPrefs.SetInt("village", 0);
    }

    public void OpenPopUp()
    {
        popupPanel.SetActive(true);
    }

    public void PopUpNo()
    {
        popupPanel.SetActive(false);
    }
}
