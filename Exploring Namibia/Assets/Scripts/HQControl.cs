using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HQControl : MonoBehaviour
{
    private int minigamesDone = 0;
    private int maxMinigames = 1;
    private static bool firstTime = true;
    public Button endGameButton;
    public GameObject startupPanel;

    // Start is called before the first frame update
    void Start()
    {
        minigamesDone = PlayerPrefs.GetInt("minigame1");
        if (minigamesDone == maxMinigames)
        {
            endGameButton.gameObject.SetActive(true);
        }
        if (firstTime == false)
        {
            CloseStartupWindow();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseStartupWindow()
    {
        startupPanel.SetActive(false);
        firstTime = false;
    }
}
