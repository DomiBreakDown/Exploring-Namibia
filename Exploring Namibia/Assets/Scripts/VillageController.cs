using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VillageController : MonoBehaviour
{
    private TextMeshProUGUI text;
    private GameObject leaveButton, skipButton;
    private int textIndex = 0;

    private const int lineCount = 11;
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
        PlayerPrefs.SetInt("village", 1);
        UnityEngine.SceneManagement.SceneManager.LoadScene(3);
    }

    private void InitLines()
    {
        // Alle Informationen für das Minispiel1 - Nahrungssuche
        lines[0] = "Guten Tag Reisender.";
        lines[1] = "Dies ist unser Dorf. Wir gehören zu den Herero und sind Einwohner Namibias.";
        lines[2] = "Wir sind ein Hirtenvolk. Wir passen mit auf das Land auf.";
        lines[3] = "Vielleicht warst du schon in der Tierrettungsstation und hast die Elefanten kennengelernt.";
        lines[4] = "Vielleicht ist dir dort aufgefallen, dass die Elefanten nicht mehr ihre gesamten Stoßzähne hatten.";
        lines[5] = "Leider gibt es Wilderer, die Elefanten und Nashörner aufgrund der Hörner jagen.";
        lines[6] = "Dies ist sehr traurig. Die Mitarbeiter der Tierrettungsstation kümmern sich um die verletzten Tiere.";
        lines[7] = "Aber nicht nur Pflanzenfresser werden gejagt. Löwen und Geparde werden wegen ihrem schönen Fell gejagt.";
        lines[8] = "Wir hoffen sehr, dass die Wilderei irgendwann aufhört.";
        lines[9] = "Danke, dass du das Dorf besucht hast und uns zugehört hast.";
        lines[10] = "Noch eine schöne Reise!";
    }
}