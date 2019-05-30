using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public Button buttonMinigame1;

    //To call Main Menu
    public void OpenMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    //To Call Options from Main Menu
    public void OpenOptionsMainMenu()
    {
        SceneManager.LoadScene(1);
    }

    //To call Headquarters/Home
    public void OpenHeadquarter()
    {
        SceneManager.LoadScene(2);
    }

    //To call Map
    public void OpenMap()
    {
        SceneManager.LoadScene(3);
    }

    //To call Village
    public void OpenVillage()
    {
        SceneManager.LoadScene(4);
    }

    //To call National Park
    public void OpenNationalPark()
    {
        SceneManager.LoadScene(5);
    }

    //To call Animal Rescue Station
    public void OpenAnimalRescueStation()
    {
        SceneManager.LoadScene(6);
    }

    //To call Credits
    public void OpenCredits()
    {
        SceneManager.LoadScene(7);
    }

    //For revealing Minigames when clicking on Minigame Button
    public void RevealMinigames()
    {
        if(buttonMinigame1.gameObject.activeSelf == false)
        {
            buttonMinigame1.gameObject.SetActive(true);
        } else if(buttonMinigame1.gameObject.activeSelf == true)
        {
            buttonMinigame1.gameObject.SetActive(false);
        }
    }
    
}
