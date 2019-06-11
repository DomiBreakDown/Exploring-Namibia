using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapControl : MonoBehaviour
{
    public Button buttonMinigame1;
    public Button buttonMinigame2;
    public Button buttonMinigame3;
    public Image minigame1Check;
    public Image minigame2Check;
    public Image minigame3Check;

    private void Start()
    {
        
    }

    //For revealing Minigames when clicking on Minigame Button
    public void RevealMinigames()
    {
        if (buttonMinigame1.gameObject.activeSelf == false)
        {
            buttonMinigame1.gameObject.SetActive(true);
            buttonMinigame2.gameObject.SetActive(true);
            buttonMinigame3.gameObject.SetActive(true);
            if (PlayerPrefs.GetInt("minigame1") == 1)
            {
                minigame1Check.gameObject.SetActive(true);
            }
            if (PlayerPrefs.GetInt("minigame2") == 1)
            {
                minigame2Check.gameObject.SetActive(true);
            }
            if (PlayerPrefs.GetInt("minigame3") == 1)
            {
                minigame3Check.gameObject.SetActive(true);
            }
        }
        else if (buttonMinigame1.gameObject.activeSelf == true)
        {
            buttonMinigame1.gameObject.SetActive(false);
            buttonMinigame2.gameObject.SetActive(false);
            buttonMinigame3.gameObject.SetActive(false);
            minigame1Check.gameObject.SetActive(false);
            minigame2Check.gameObject.SetActive(false);
            minigame3Check.gameObject.SetActive(false);
        }
    }
}
