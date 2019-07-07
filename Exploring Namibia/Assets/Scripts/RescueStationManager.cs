using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RescueStationManager : MonoBehaviour
{
    private TextMeshProUGUI text;
    private GameObject leaveButton, skipButton;
    private int textIndex = 0;

    private const int lineCount = 10;
    private readonly string[] lines = new string[lineCount];

    private void Start()
    {
        text = GameObject.Find("Text-Bubble").GetComponent<TextMeshProUGUI>();
        leaveButton = GameObject.Find("Button-Leave").gameObject;
        skipButton = GameObject.Find("Button-Skip").gameObject;
        leaveButton.SetActive(false);
        InitLines();
        ResetText();
    }

    private void ResetText()
    {
        textIndex = 0;
        text.text = lines[textIndex];
    }

    public void ChangeBubbleText()
    {
        textIndex++;

        if (textIndex < lineCount - 1)
        {
            text.text = lines[textIndex];
        }
        else
        {
            text.text = lines[lineCount - 1];
            leaveButton.SetActive(true);
            skipButton.SetActive(false);
        }
    }

    public void Skip()
    {
        Leave();
    }

    public void Leave()
    {
        UnityEngine.PlayerPrefs.SetInt("rescueStation", 1);
        UnityEngine.SceneManagement.SceneManager.LoadScene(3);
    }

    private void InitLines()
    {
        // Alle Informationen für das Minispiel1 - Nahrungssuche
        lines[0] = "Das hier ist die Tierrettungsstation. Viele Tiere wurden verletzt und werden hier versorgt.";
        lines[1] = "Die Elefanten, die du da hinten sehen kannst wurden hier vor einiger Zeit aufgenommen.";
        lines[2] = "Sie sind sehr treue und einfühlsame Geschöpfe. Sie lieben die Blätter von den Bäumen zu fressen.";
        lines[3] = "Wir haben hier auch Zebras, Warzenschweine und sogar zwei Löwen.";
        lines[4] = "Zebras sind Pflanzenfresser. Sie ernähren sich von Gräsern die sie finden können.";
        lines[5] = "Warzenschweine sind Allesfresser vertragen also sowohl Pflanzen als auch Fleisch.";
        lines[6] = "Sie bevorzugen aber pflanzliche Nahrung wie z.B. Knollen die sie im Boden finden.";
        lines[7] = "Löwen zählen zu den Fleischfressern und sind gleichzeitig auch Raubtiere.";
        lines[8] = "In der freien Wildbahn machen sie Jagd auf Gazellen oder Zebras.";
        lines[9] = "Sie jagen in Rudeln um bessere Chancen zu haben, weil die Beute sich zusammenrottet wenn es gefährlich wird.";
    }
}