using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChangeText : MonoBehaviour
{
    private TextMeshProUGUI text;
    private int textIndex = 0;

    private readonly static int lineCount = 7;
    private string[] lines = new string[lineCount];
    private bool back = false;

    private void Start()
    {
        text = this.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
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
        if (back)
        {
            back = false;
            UnityEngine.SceneManagement.SceneManager.LoadScene(2);
        }
        else
        {
            if (textIndex + 1 < lineCount)
            {
                textIndex++;
                text.text = lines[textIndex];
            }
            else
            {
                text.text = "Zurück";
                back = true;
            }
        }
    }

    private void InitLines()
    {
        // Alle Informationen für das Minispiel
        lines[0] = "Das hier ist der Nationalpark. Viele Tiere sind scheu und verschwinden beim Anblick von Menschen.";
        lines[1] = "Die Zebras, die du da siehst ernähren sich Hauptsächlich von Gras was sie auf dem Boden finden.";
        lines[2] = "Außerdem haben wir hier noch ander Pflanzenfresser wie Elefanten und Giraffen die sich von Blättern an den Bäumen ernähren.";
        lines[3] = "Die Tiere sind hier im Nationalpark sicher vor Großwildjägern, die auf die Trophäen von den Tieren aus sind.";
        lines[4] = "Allerdings herrschen hier dieselben Bedingungen für die Tiere wie außerhalb.";
        lines[5] = "Deswegen gibt es hier auch Löwen, die Jagd auf die Zebras machen.";
        lines[6] = "Löwen sind sehr gefährlich und gehören zu den Fleischfressern.";
    }
}