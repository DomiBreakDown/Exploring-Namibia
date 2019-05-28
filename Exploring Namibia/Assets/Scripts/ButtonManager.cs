using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    
    //To Call Options from Main Menu
    public void OptionsMainMenu()
    {
        SceneManager.LoadScene(1);
    }

    //To call Main Menu
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
