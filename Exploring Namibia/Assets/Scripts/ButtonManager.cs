using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{

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
    
}
