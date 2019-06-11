using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProgressMenu : MonoBehaviour
{
    public TextMeshProUGUI textMinigame;
    public TextMeshProUGUI textMinigame1;
    public TextMeshProUGUI textMinigame2;
    public TextMeshProUGUI textMinigame3;
    private int minigamesDone;
    private string textZeroMinigames = "0 von 3 Minispielen geschafft";
    private string textOneMinigame = "1 von 3 Minispielen geschafft";
    private string textTwoMinigames = "2 von 3 Minispielen geschafft";
    private string textThreeMinigames = "3 von 3 Minispielen geschafft";
    private string textDone = "geschafft!";
    private string textNotDone = "noch nicht geschafft!";

    // Start is called before the first frame update
    void Start()
    {
        minigamesDone = PlayerPrefs.GetInt("minigame1") + PlayerPrefs.GetInt("minigame2") + PlayerPrefs.GetInt("minigame3");
        if (minigamesDone == 0)
        {
            textMinigame.text = textZeroMinigames;
        } else if (minigamesDone == 1)
        {
            textMinigame.text = textOneMinigame;
        } else if (minigamesDone == 2)
        {
            textMinigame.text = textTwoMinigames;
        } else
        {
            textMinigame.text = textThreeMinigames;
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

        if (PlayerPrefs.GetInt("minigame3") == 1)
        {
            textMinigame3.text = textDone;
        }
        else
        {
            textMinigame3.text = textNotDone;
        }
    }
}
