using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class HUDManager : MonoBehaviour
{
    private readonly static int heartCount = 5;
    private static int currHeartCount = heartCount;

    private GameObject[] heartsFilled = new GameObject[heartCount];
    private GameObject[] heartsEmpty = new GameObject[heartCount];
    private GameObject HUD;
    private GameObject startGamePanel;
    private GameObject ScoreScreen;
    private TextMeshProUGUI txtSuccess, txtItemsCollected, txtBtnNextPart, txtCountdown, txtItemCounter;
    private GameObject btnBackToHQ;
    private MiniGameManager miniGameManager;

    private void Start()
    {
        HUD = GameObject.Find("HUD").gameObject;
        startGamePanel = GameObject.Find("Panel-StartGame");
        ScoreScreen = HUD.transform.GetChild(1).gameObject;
        txtSuccess = ScoreScreen.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        txtItemsCollected = ScoreScreen.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        txtBtnNextPart = ScoreScreen.transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>();
        txtCountdown = HUD.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        txtCountdown.transform.gameObject.SetActive(false);
        txtItemCounter = HUD.transform.GetChild(3).GetComponent<TextMeshProUGUI>();
        btnBackToHQ = ScoreScreen.transform.GetChild(3).gameObject;
        miniGameManager = GameObject.Find("Minigame").GetComponent<MiniGameManager>();

        InstantiateHearts();
        PauseGame();
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

    public void ShowScoreScreen(int itemsCollected, int remainingLifes)
    {
        if (remainingLifes > 0)
        {
            txtItemsCollected.gameObject.SetActive(true);
            txtSuccess.text = "Du hast es geschafft!";
            txtItemsCollected.text = "Du hast alle " + itemsCollected + " Stück Nahrung gesammelt.";
            txtBtnNextPart.text = "Weiter";
        }
        else
        {
            txtSuccess.text = "Game Over";
            txtItemsCollected.text = "Du hast entweder das falsche Essen eingesammelt oder bist zu oft gegen Hindernisse gefahren.";
            txtBtnNextPart.text = "Noch mal";
        }
        
        ScoreScreen.SetActive(true);
    }

    public void ShowEndScreen()
    {
        txtSuccess.text = "Du hast Minispiel 1 Abgeschlossen";
        txtBtnNextPart.transform.parent.gameObject.SetActive(false);
        ScoreScreen.SetActive(true);
    }

    public void CloseScoreScreen()
    {
        ScoreScreen.SetActive(false);
        if(miniGameManager.CheckFinished())
        {
            ShowEndScreen();
        }
        else
        {
            startGamePanel.SetActive(true);
        }
        
        PauseGame();
    }

    public void UpdateStartGamePanel(string explanation)
    {
        startGamePanel.transform.GetChild(2).transform.gameObject.GetComponent<TextMeshProUGUI>().text = explanation;
    }

    public void UpdateStartGamePanel(bool active)
    {
        startGamePanel.SetActive(active);
    }

    public void Reset()
    {
        currHeartCount = heartCount;
        InstantiateHearts();
        UpdateItemCounter(0);
    }

    private void InstantiateHearts()
    {
        int i = 0;
        for (int j = 0; j < heartCount * 2; j++)
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

    private void PauseGame()
    {
        Time.timeScale = 0f;
        PauseMenu.gameIsPaused = true;
    }
}
