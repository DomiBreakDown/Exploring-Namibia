using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDManagerMinigame01 : MonoBehaviour
{
    private const int HEART_COUNT = PlayerController.LIFE_POINTS;
    private static int currHeartCount = HEART_COUNT;

    private GameObject[] heartsFilled = new GameObject[HEART_COUNT];
    private GameObject[] heartsEmpty = new GameObject[HEART_COUNT];
    private GameObject HUD;
    private GameObject startGamePanel, introPanel, deathPanel;
    private GameObject ScoreScreen;
    private TextMeshProUGUI txtSuccess, txtItemsCollected, txtBtnNextPart, txtCountdown, txtItemCounter;
    private GameObject btnBackToHQ;
    private MiniGameManager miniGameManager;

    private void Start()
    {
        HUD = GameObject.Find("HUD");
        startGamePanel = GameObject.Find("Panel-StartGame");
        introPanel = GameObject.Find("Panel-Introduction");
        deathPanel = GameObject.Find("Panel-DeathScreen");
        ScoreScreen = GameObject.Find("ScoreScreen");

        txtCountdown = GameObject.Find("Text-Countdown").GetComponent<TextMeshProUGUI>();
        txtItemCounter = GameObject.Find("Text-Progress").GetComponent<TextMeshProUGUI>();

        txtSuccess = ScoreScreen.gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        txtItemsCollected = ScoreScreen.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        txtBtnNextPart = ScoreScreen.transform.GetChild(3).GetChild(0).GetComponent<TextMeshProUGUI>();
        btnBackToHQ = ScoreScreen.transform.GetChild(4).gameObject;

        introPanel.SetActive(false);
        deathPanel.SetActive(false);
        ScoreScreen.SetActive(false);
        txtCountdown.transform.gameObject.SetActive(false);

        miniGameManager = GameObject.Find("Minigame").GetComponent<MiniGameManager>();
        miniGameManager.PauseGame(true);

        InstantiateHearts();
    }

    public void RemoveHeart()
    {
        if (currHeartCount > 0)
        {
            heartsFilled[currHeartCount - 1].SetActive(false);
            heartsEmpty[currHeartCount - 1].SetActive(true);
            --currHeartCount;
        }
    }

    public void ShowScoreScreen(int itemsCollected, int itemNr)
    {
        
        string foodStr;
        miniGameManager.PauseGame(true);
        txtItemsCollected.gameObject.SetActive(true);
        txtSuccess.text = "Du hast es geschafft!";
        
        switch (itemNr)
        {
            case 0:
                foodStr = "Gazellen für die Löwen";
                break;
            case 1:
                foodStr = "Büschel Gras für die Zebras";
                break;
            case 2:
                foodStr = "Knollen für die Warzenschweine";
                break;
            default:
                foodStr = "Nahrung für die Tiere";
                break;
        }

        txtItemsCollected.text = "Du hast " + itemsCollected + " " + foodStr + " gesammelt.";
        txtBtnNextPart.text = "Weiter";
        ScoreScreen.SetActive(true);
    }

    public void CloseScoreScreen()
    {
        ScoreScreen.SetActive(false);
        if (miniGameManager.CheckFinished())
        {
            ShowEndScreen();
        }
        else
        {
            startGamePanel.SetActive(true);
        }
    }

    public void ShowEndScreen()
    {
        txtSuccess.text = "Du hast Minispiel 1 Abgeschlossen";
        txtBtnNextPart.transform.parent.gameObject.SetActive(false);
        txtItemsCollected.gameObject.SetActive(false);
        ScoreScreen.SetActive(true);
    }

    public void ShowDeathScreen(bool active)
    {
        deathPanel.SetActive(active);
    }

    public void ShowIntroScreen(bool active)
    {
        introPanel.SetActive(active);
    }

    public void UpdateStartGamePanel(string explanation)
    {
        startGamePanel.transform.GetChild(2).transform.gameObject.GetComponent<TextMeshProUGUI>().text = explanation;
    }

    public void ShowStartGamePanel(bool active)
    {
        startGamePanel.SetActive(active);
    }

    public void Reset()
    {
        ShowDeathScreen(false);

        currHeartCount = HEART_COUNT;
        InstantiateHearts();
        UpdateItemCounter(0);
    }

    private void InstantiateHearts()
    {
        int i = 0;
        for (int j = 0; j < HEART_COUNT * 2; j++)
        {
            heartsFilled[i] = HUD.transform.GetChild(0).GetChild(j).gameObject;
            heartsFilled[i].SetActive(true);

            heartsEmpty[i] = HUD.transform.GetChild(0).GetChild(j + 1).gameObject;
            heartsEmpty[i].SetActive(false);

            j++;
            i++;
        }
    }

    public void ShowCountdown(int c)
    {
        txtCountdown.transform.gameObject.SetActive(true);
        if (c > 0)
        {
            txtCountdown.text = c.ToString();
        }
        else
        {
            txtCountdown.transform.gameObject.SetActive(false);
        }
    }

    public void UpdateItemCounter(int i)
    {
        txtItemCounter.text = i + "/10";
    }
}
