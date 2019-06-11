using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecretSettingsControl : MonoBehaviour
{
    public Toggle checkboxMinigame1;
    public Toggle checkboxMinigame2;
    public Toggle checkboxMinigame3;
    
    void Start()
    {
        if (PlayerPrefs.GetInt("minigame1") == 1)
        {
            checkboxMinigame1.isOn = true;
        }
        if (PlayerPrefs.GetInt("minigame2") == 1)
        {
            checkboxMinigame2.isOn = true;
        }
        if (PlayerPrefs.GetInt("minigame3") == 1)
        {
            checkboxMinigame3.isOn = true;
        }
    }

    public void ToggleMinigame1()
    {
        if (checkboxMinigame1.isOn)
            PlayerPrefs.SetInt("minigame1", 1);
        if (!checkboxMinigame1.isOn)
            PlayerPrefs.SetInt("minigame1", 0);
    }

    public void ToggleMinigame2()
    {
        if (checkboxMinigame2.isOn)
            PlayerPrefs.SetInt("minigame2", 1);
        if (!checkboxMinigame2.isOn)
            PlayerPrefs.SetInt("minigame2", 0);
    }

    public void ToggleMinigame3()
    {
        if (checkboxMinigame3.isOn)
            PlayerPrefs.SetInt("minigame3", 1);
        if (!checkboxMinigame3.isOn)
            PlayerPrefs.SetInt("minigame3", 0);
    }
}
