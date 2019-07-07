using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProgressMenu : MonoBehaviour
{
    public TextMeshProUGUI textMinigame;
    public TextMeshProUGUI textMinigame1;
    public TextMeshProUGUI textMinigame2;
    private int minigamesDone;
    private string textZeroMinigames = "0 von 2 Minispielen geschafft";
    private string textOneMinigame = "1 von 2 Minispielen geschafft";
    private string textTwoMinigames = "2 von 2 Minispielen geschafft";
    private string textDone = "geschafft!";
    private string textNotDone = "noch nicht geschafft!";

    // Start is called before the first frame update
    void Start()
    {
        minigamesDone = PlayerPrefs.GetInt("minigame1") + PlayerPrefs.GetInt("minigame2");
        if (minigamesDone == 0)
        {
            textMinigame.text = textZeroMinigames;
        } else if (minigamesDone == 1)
        {
            textMinigame.text = textOneMinigame;
        } else
        {
            textMinigame.text = textTwoMinigames;
        }

        if(PlayerPrefs.GetInt("minigame1") == 1)
        {
            textMinigame1.text = textDone;
        } else
        {
            textMinigame1.text = textNotDone;
        }

        if (PlayerPrefs.GetInt("minigame2") == 1)
        {
            textMinigame2.text = textDone;
        }
        else
        {
            textMinigame2.text = textNotDone;
        }
    }
}
