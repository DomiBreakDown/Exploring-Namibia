using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NationalParkController : MonoBehaviour
{
    private TextMeshProUGUI text;
    private GameObject leaveButton, skipButton;
    private int textIndex = 0;

    private const int lineCount = 13;
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
        PlayerPrefs.SetInt("nationalpark", 1);
        UnityEngine.SceneManagement.SceneManager.LoadScene(3);
    }

    private void InitLines()
    {
        // Alle Informationen für das Minispiel2 - Namenlos
        lines[0] = "Willkommen im Nationalpark!";
        lines[1] = "Hier leben viele verschiedene Tiere.";
        lines[2] = "Von Elefanten oder Löwen hast du bestimmt schon mal gehört oder sie sogar im Zoo gesehen.";
        lines[3] = "Jedoch leben hier noch einige andere Tiere.";
        lines[4] = "In diesem Park gibt es eine große Wasserstelle, wo sich jeden Tag viele Tiere sammeln um zu trinken.";
        lines[5] = "Die Nilpferde und Krokodile sind jedoch den ganzen Tag am Wasser.";
        lines[6] = "Nilpferde sind Säugetiere und ernähren sich von Pflanzen.";
        lines[7] = "Sie haben vier Zehen an jedem Huf und gehören somit zu den Paarhufern.";
        lines[8] = "Nilpferde besitzen eine Haut, die mit kurzen und dünnen Haaren überzogen ist, weshalb sie nackt aussehen.";
        lines[9] = "Krokodile sind da ganz anders. Sie sind Reptilien und legen Eier.";
        lines[10] = "Sie ernähren sich von Fleisch. Anstelle von Hufen haben sie Krallen.";
        lines[11] = "Sie besitzen einen Schuppenpanzer, der sie gut schützt.";
        lines[12] = "Wie du siehst, sind Nilpferde und Krokodile sehr unterschiedlich. Dennoch sind sie beide gerne im Wasser.";
    }
}