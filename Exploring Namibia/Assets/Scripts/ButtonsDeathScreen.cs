using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsDeathScreen : MonoBehaviour
{
    GameObject hoverText;
    bool hoverActive = false;

    private void Start()
    {
        hoverText = this.transform.GetChild(1).gameObject;
    }

    public void ActivateHover()
    {
        hoverActive = true;
    }

    public void DeactivateHover()
    {
        hoverActive = false;
    }

    public void BackToInfo()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(5);
    }

    private void Update()
    {
        hoverText.SetActive(hoverActive);
    }
}
