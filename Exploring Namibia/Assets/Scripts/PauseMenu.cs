using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    private static bool options = false;

    public GameObject pauseMenuUI;
    public GameObject optionsUI;
    public GameObject secretSettingsUI;
    public GameObject buttonLogo;

    private AudioManager audioManager;

    private void Start()
    {
        if(GameObject.Find("Audio") != null)
        {
            audioManager = GameObject.Find("Audio").GetComponent<AudioManager>();
        }
    }

    public void PauseButton()
    {
        if (gameIsPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        optionsUI.SetActive(false);
        buttonLogo.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        options = false;
        pauseMenuUI.GetComponent<Animator>().enabled = true;

        if (audioManager != null)
        {
            audioManager.ResumeAudio();
        }
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        buttonLogo.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        options = false;

        if(audioManager != null)
        {
            audioManager.PauseAudio();
        }
    }

    public void Options()
    {
        pauseMenuUI.SetActive(false);
        optionsUI.SetActive(true);
        pauseMenuUI.GetComponent<Animator>().enabled = false;
        options = true;
    }

    public void BackToPause()
    {
        optionsUI.SetActive(false);
        pauseMenuUI.SetActive(true);
        options = false;
    }

    public void BackToHQ()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
        gameIsPaused = false;
    }

    public void SecretSettings()
    {
        pauseMenuUI.SetActive(false);
        optionsUI.SetActive(false);
        buttonLogo.SetActive(false);
        secretSettingsUI.SetActive(true);
        pauseMenuUI.GetComponent<Animator>().enabled = false;
    }

    public void BackFromSecretSettings()
    {
        secretSettingsUI.SetActive(false);
        buttonLogo.SetActive(true);
        if (options)
        {
            optionsUI.SetActive(true);
        } else
        {
            pauseMenuUI.SetActive(true);
        }
    }
}
