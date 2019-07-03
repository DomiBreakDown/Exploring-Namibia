using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject optionsUI;

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
        Time.timeScale = 1f;
        gameIsPaused = false;
        pauseMenuUI.GetComponent<Animator>().enabled = true;

        if (audioManager != null)
        {
            audioManager.ResumeAudio();
        }
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;

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
    }

    public void BackToPause()
    {
        optionsUI.SetActive(false);
        pauseMenuUI.SetActive(true);
    }

    public void BackToHQ()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
        gameIsPaused = false;
    }
}
