using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MapControl : MonoBehaviour
{
    public Button buttonMinigame1;
    public Button buttonMinigame2;
    public Image minigame1Check;
    public Image minigame2Check;
    public GameObject minigame1Warning;
    public GameObject minigame2Warning;
    public GameObject minigameMessagePanel;
    public TextMeshProUGUI minigameMessagePanelText;
    public TextMeshProUGUI textButtonMinigame1;
    public TextMeshProUGUI textButtonMinigame2;
    public Texture2D handCursor;
    public CursorMode curMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    private static bool showMinigame1Panel = true;
    private static bool showMinigame2Panel = true;
    private static string minigame1Message = "Du hast nun das Minispiel 1 - Nahrungssuche freigeschaltet!";
    private static string minigame2Message = "Du hast nun das Minispiel 2 - Eigenschaften freigeschaltet!";

    private void Start()
    {
        minigameMessagePanel.SetActive(false);
        if (PlayerPrefs.GetInt("rescueStation") == 0)
        {
            buttonMinigame1.interactable = false;
        }
        else
        {
            buttonMinigame1.interactable = true;
        }
        if (PlayerPrefs.GetInt("nationalpark") == 0)
        {
            buttonMinigame2.interactable = false;
        } else
        {
            buttonMinigame2.interactable = true;
        }
        if(PlayerPrefs.GetInt("rescueStation") == 1 && showMinigame1Panel == true)
        {
            minigameMessagePanel.SetActive(true);
            minigameMessagePanelText.text = minigame1Message;
            showMinigame1Panel = false;
        }
        if (PlayerPrefs.GetInt("nationalpark") == 1 && showMinigame2Panel == true)
        {
            minigameMessagePanel.SetActive(true);
            minigameMessagePanelText.text = minigame2Message;
            showMinigame2Panel = false;
        }
    }

    //For revealing Minigames when clicking on Minigame Button
    public void RevealMinigames()
    {
        if (buttonMinigame1.gameObject.activeSelf == false)
        {
            buttonMinigame1.gameObject.SetActive(true);
            buttonMinigame2.gameObject.SetActive(true);
            textButtonMinigame1.gameObject.SetActive(true);
            textButtonMinigame2.gameObject.SetActive(true);
            if (PlayerPrefs.GetInt("minigame1") == 1)
            {
                minigame1Check.gameObject.SetActive(true);
            }
            if (PlayerPrefs.GetInt("minigame2") == 1)
            {
                minigame2Check.gameObject.SetActive(true);
            }
        }
        else if (buttonMinigame1.gameObject.activeSelf == true)
        {
            buttonMinigame1.gameObject.SetActive(false);
            buttonMinigame2.gameObject.SetActive(false);
            minigame1Check.gameObject.SetActive(false);
            minigame2Check.gameObject.SetActive(false);
            textButtonMinigame1.gameObject.SetActive(false);
            textButtonMinigame2.gameObject.SetActive(false);
        }
    }

    public void CloseMinigameMessagePanel()
    {
        minigameMessagePanel.SetActive(false);
    }

    public void Minigame1WarningShow()
    {
        if (!buttonMinigame1.interactable)
            minigame1Warning.SetActive(true);
    }

    public void Minigame1WarningClose()
    {
        if (!buttonMinigame1.interactable)
            minigame1Warning.SetActive(false);
    }

    public void Minigame2WarningShow()
    {
        if (!buttonMinigame2.interactable)
            minigame2Warning.SetActive(true);
    }

    public void Minigame2WarningClose()
    {
        if (!buttonMinigame2.interactable)
            minigame2Warning.SetActive(false);
    }

    public void OnMouseOverMinigame1()
    {
        if(buttonMinigame1.IsInteractable())
        {
            Cursor.SetCursor(handCursor, hotSpot, curMode);
        }
    }

    public void OnMouseOverMinigame2()
    {
        if (buttonMinigame2.IsInteractable())
        {
            Cursor.SetCursor(handCursor, hotSpot, curMode);
        }
    }
}
