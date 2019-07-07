using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Minigame2Controller : MonoBehaviour
{
    private static int maxAttributesSide = 4;
    private static int maxAttlivutesAll = maxAttributesSide * 2;
    
    public Button finishButton;
    public GameObject startPanel, successPanel, failedPanel;

    public GameObject leftAtt1, leftAtt2, leftAtt3, leftAtt4;
    public GameObject rightAtt1, rightAtt2, rightAtt3, rightAtt4;
    public GameObject nameLeft, nameRight;

    private void Start()
    {
        finishButton.gameObject.SetActive(false);
        leftAtt1.SetActive(false);
        leftAtt2.SetActive(false);
        leftAtt3.SetActive(false);
        leftAtt4.SetActive(false);
        rightAtt1.SetActive(false);
        rightAtt2.SetActive(false);
        rightAtt3.SetActive(false);
        rightAtt4.SetActive(false);
        nameRight.SetActive(false);
        nameLeft.SetActive(false);
        successPanel.SetActive(false);
        failedPanel.SetActive(false);
        startPanel.SetActive(true);
        PlayerPrefs.SetInt("allAttributes", 0);
        PlayerPrefs.SetInt("leftAttributes", 0);
        PlayerPrefs.SetInt("rightAttributes", 0);
    }

    private void Update()
    {
        if (PlayerPrefs.GetInt("allAttributes") == maxAttlivutesAll)
        {
            finishButton.gameObject.SetActive(true);
        } else
        {
            finishButton.gameObject.SetActive(false);
        }
    }

    public void EndGame()
    {
        if(PlayerPrefs.GetInt("leftAttributes") == maxAttributesSide &&
           PlayerPrefs.GetInt("rightAttributes") == maxAttributesSide)
        {
            successPanel.SetActive(true);
            PlayerPrefs.SetInt("minigame2", 1);
        } else
        {
            failedPanel.SetActive(true);
        }
    }

    public void StartGame()
    {
        startPanel.SetActive(false);
        leftAtt1.SetActive(true);
        leftAtt2.SetActive(true);
        leftAtt3.SetActive(true);
        leftAtt4.SetActive(true);
        rightAtt1.SetActive(true);
        rightAtt2.SetActive(true);
        rightAtt3.SetActive(true);
        rightAtt4.SetActive(true);
        nameRight.SetActive(true);
        nameLeft.SetActive(true);
    }
}
