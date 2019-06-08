using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProgressMenu : MonoBehaviour
{
    public TextMeshProUGUI textMinigame;
    private int minigamesDone;
    private string textZeroMinigames = "0 von 1 Minispielen geschafft";
    private string textOneMinigame = "1 von 1 Minispielen geschafft";

    // Start is called before the first frame update
    void Start()
    {
        minigamesDone = PlayerPrefs.GetInt("minigame1");
        if (minigamesDone == 0)
        {
            textMinigame.text = textZeroMinigames;
        } else if (minigamesDone == 1)
        {
            textMinigame.text = textOneMinigame;
        }
    }
}
