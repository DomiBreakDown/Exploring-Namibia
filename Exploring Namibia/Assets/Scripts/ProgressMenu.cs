using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProgressMenu : MonoBehaviour
{
    public TextMeshProUGUI textMinigame;
    public TextMeshProUGUI textMinigame1;
    private int minigamesDone;
    private string textZeroMinigames = "0 von 1 Minispielen geschafft";
    private string textOneMinigame = "1 von 1 Minispielen geschafft";
    private string textDone = "geschafft!";
    private string textNotDone = "noch nicht geschafft!";

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

        if(PlayerPrefs.GetInt("minigame1") == 1)
        {
            textMinigame1.text = textDone;
        } else
        {
            textMinigame1.text = textNotDone;
        }
    }
}
