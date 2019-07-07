using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HQControl : MonoBehaviour
{
    private int minigamesDone;
    private int maxMinigames = 2;
    private static bool firstTime = true;
    private static bool showEndPanel = true;
    public Button endGameButton;
    public GameObject startupPanel;
    public GameObject endPanel;
    
    void Start()
    {
        minigamesDone = PlayerPrefs.GetInt("minigame1") + PlayerPrefs.GetInt("minigame2");
        if (minigamesDone == maxMinigames)
        {
            endGameButton.gameObject.SetActive(true);
            if(showEndPanel == true)
            {
                endPanel.SetActive(true);
            }
        }
        if (firstTime == false)
        {
            CloseStartupWindow();
        }
    }

    public void CloseStartupWindow()
    {
        startupPanel.SetActive(false);
        firstTime = false;
    }

    public void CloseEndWindow()
    {
        endPanel.SetActive(false);
        showEndPanel = false;
    }
}
