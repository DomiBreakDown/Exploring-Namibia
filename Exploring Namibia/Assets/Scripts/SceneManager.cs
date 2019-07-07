using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    //To call Main Menu
    public void OpenMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    //To Call Options from Main Menu
    public void OpenOptionsMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    //To call Headquarters/Home
    public void OpenHeadquarter()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }

    //To call Map
    public void OpenMap()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(3);
    }

    //To call Village
    public void OpenVillage()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(4);
    }

    //To call National Park
    public void OpenAnimalRescueStation()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(5);
    }

    //To call Animal Rescue Station
    public void OpenNationalPark()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(6);
    }

    //To call Credits
    public void OpenCredits()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(7);
    }

    public void OpenMinigame01()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(8);
    }

    public void OpenMinigame02()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(12);
    }

    public void OpenOutro()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(13);
    }

    public void OpenProgress()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(9);
    }

    public void OpenIntro()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(10);
    }

    public void OpenSecretSettings()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(11);
    }
}
