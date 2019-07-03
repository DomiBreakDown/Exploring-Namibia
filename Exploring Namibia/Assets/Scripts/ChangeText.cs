using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChangeText : MonoBehaviour
{
    private TextMeshProUGUI text;
    private GameObject leaveButton;
    private int textIndex = 0;

    private const int lineCount = 7;
    private readonly string[] lines = new string[lineCount];

    private void Start()
    {
        text = GameObject.Find("Text-Bubble").GetComponent<TextMeshProUGUI>();
        leaveButton = GameObject.Find("Button-Leave").gameObject;
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
        }
    }

    private void InitLines()
    {
        // Alle Informationen für das Minispiel
        lines[0] = "Das hier ist der Nationalpark. Viele Tiere sind scheu und verschwinden beim Anblick von Menschen.";
        lines[1] = "Die Zebras, die du da siehst ernähren sich Hauptsächlich von Gras was sie auf dem Boden finden.";
        lines[2] = "Außerdem haben wir hier noch andere Pflanzenfresser, wie Elefanten und Giraffen, die sich von Blättern an den Bäumen ernähren.";
        lines[3] = "Die Tiere sind hier im Nationalpark sicher vor Großwildjägern, die auf die Trophäen von den Tieren aus sind.";
        lines[4] = "Allerdings herrschen hier dieselben Bedingungen für die Tiere wie außerhalb.";
        lines[5] = "Deswegen gibt es hier auch Löwen, die Jagd auf Pflanzenfresser wie Zebras oder Gazellen machen.";
        lines[6] = "Löwen sind sehr gefährlich und gehören zu den Fleischfressern.";
    }
}