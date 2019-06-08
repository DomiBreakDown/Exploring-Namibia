using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class HUDManager : MonoBehaviour
{
    private static int heartCount = 10;

    private Image[] heartsFilled = new Image[heartCount];
    private Image[] heartsEmpty = new Image[heartCount];
    private GameObject HUD;
    private GameObject ScoreScreen;
    private TextMeshProUGUI txtSuccess, txtItemsCollected, txtBtnNextPart, txtCountdown;
    private GameObject btnBackToHQ;
    private MiniGameManager miniGameManager;

    private void Start()
    {
        HUD = GameObject.Find("HUD").gameObject;
        ScoreScreen = HUD.transform.GetChild(1).gameObject;
        txtSuccess = ScoreScreen.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        txtItemsCollected = ScoreScreen.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        txtBtnNextPart = ScoreScreen.transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>();
        txtCountdown = HUD.transform.GetChild(3).GetComponent<TextMeshProUGUI>();
        txtCountdown.transform.gameObject.SetActive(false);
        btnBackToHQ = ScoreScreen.transform.GetChild(3).gameObject;
        btnBackToHQ.SetActive(false);
        miniGameManager = GameObject.Find("Minigame").GetComponent<MiniGameManager>();

        InstantiateHearts();
    }

    public void RemoveHeart()
    {
        if (heartCount > 0)
        {
            heartsFilled[heartCount - 1].enabled = false;
            heartsEmpty[heartCount - 1].enabled = true;
            --heartCount;
        }
    }

    public void ShowScoreScreen(int itemsCollected, int remainingLifes)
    {
        if (remainingLifes > 0)
        {
            txtSuccess.text = "Du hast es geschafft!";
            txtItemsCollected.text = "Du hast alle " + itemsCollected + " Stück Nahrung gesammelt.";
            txtBtnNextPart.text = "Weiter";
            miniGameManager.Succeeded(true);
        }
        else
        {
            txtSuccess.text = "Du hast es nicht geschafft!";
            txtBtnNextPart.text = "Noch mal";
            txtItemsCollected.enabled = false;
            miniGameManager.Succeeded(false);
        }
        
        ScoreScreen.SetActive(true);
    }

    public void ShowEndScreen()
    {
        txtSuccess.text = "Du hast Minispiel 1 Abgeschlossen";
        txtBtnNextPart.transform.parent.gameObject.SetActive(false);
        btnBackToHQ.SetActive(true);

        ScoreScreen.SetActive(true);
    }

    public void CloseScoreScreen()
    {
        ScoreScreen.SetActive(false);
        miniGameManager.NextIteration();
    }

    public void Reset()
    {
        heartCount = 10;
        InstantiateHearts();
    }

    private void InstantiateHearts()
    {
        int i = 0;
        for (int j = 0; j < heartCount * 2; j++)
        {
            heartsFilled[i] = HUD.transform.GetChild(0).GetChild(j).gameObject.GetComponent<Image>();
            heartsFilled[i].enabled = true;

            heartsEmpty[i] = HUD.transform.GetChild(0).GetChild(j + 1).gameObject.GetComponent<Image>();
            heartsEmpty[i].enabled = false;

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
}
