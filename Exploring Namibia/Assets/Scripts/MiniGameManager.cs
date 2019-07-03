using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameManager : MonoBehaviour
{
    public const float X_BARRIER_POS = 7.2f; // position of the collider on the sides of the arena
    public const float Y_MIN_POS = 5.5f; // minimum position of the area where items/obstacles will spawn
    public const float Y_MAX_POS = 10.0f; // maximum position of the area where items/obstacles will spawn

    private PlayerController playerController;
    private HUDManagerMinigame01 HUDManager;
    private PauseMenu pauseMenu;
    private SceneManager sceneManager;

    private GameObject backG1, backG2;

    private static int iteration; // current iteration
    private const int GOAL = 3; // number of iterations (needs to stay on 3 unless switch case on line 56 is changed)

    public int correctItemToBeCollected = 0;
    public bool Reset = false;
    private bool finished = false;

    private void Awake()
    {
        playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        HUDManager = GameObject.Find("HUD").GetComponent<HUDManagerMinigame01>();
        pauseMenu = GameObject.Find("Canvas-Pause-Menu").GetComponent<PauseMenu>();
        sceneManager = GameObject.Find("SceneManagerScript").GetComponent<SceneManager>();

        backG1 = this.transform.GetChild(0).transform.gameObject;
        backG2 = this.transform.GetChild(1).transform.gameObject;
    }

    private void Start()
    {
        backG1.transform.position = new Vector3(0, 0);
        backG2.transform.position = new Vector3(0, 10.5f);

        finished = false;
        iteration = 0;
        HUDManager.UpdateStartGamePanel("Phase 1: Sammle Futter für die Löwen");
    }

    private void Update()
    {
        MoveBackground();
    }

    public void NextIteration()
    {
        ++iteration;

        if(iteration == 1)
        {
            HUDManager.UpdateStartGamePanel("Phase 2: Sammle Futter für die Zebras");
            correctItemToBeCollected = 1;
        }
        else if(iteration == 2)
        {
            HUDManager.UpdateStartGamePanel("Phase 3: Sammle Futter für die Warzenschweine");
            correctItemToBeCollected = 2;
        }
        else // (iteration >= GOAL)
        {
            finished = true;
            PlayerPrefs.SetInt("minigame1", 1);
        }
    }

    public bool CheckFinished()
    {
        return finished;
    }

    public void ShowIntroduction()
    {
        if(iteration < 1)
        {
            HUDManager.ShowStartGamePanel(false);
            HUDManager.ShowIntroScreen(true);
        }
        else
        {
            StartGame();
        }
    }

    public void PauseGame(bool pausing)
    {
        if(pausing)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }
    }


    public void Retry()
    {
        ResetGame();
        HUDManager.ShowStartGamePanel(true);
        PauseGame(true);
    }

    private void ResetGame()
    {
        Reset = true;
        playerController.Reset();
        HUDManager.Reset();
    }

    public void StartGame()
    {
        backG1.transform.position = new Vector3(0, 0);
        backG2.transform.position = new Vector3(0, 10.5f);
        HUDManager.ShowStartGamePanel(false);
        HUDManager.ShowIntroScreen(false);
        ResetGame();
        PauseGame(false);
        StartCoroutine(Countdown());
    }

    public void ExitGame()
    {
        ResetGame();
        sceneManager.OpenMap();
    }

    private IEnumerator Countdown()
    {
        playerController.StartEngine();
        
        int c = 3;
        while (c > 0)
        {
            Time.timeScale = 0.001f;
            HUDManager.ShowCountdown(c);
            c--;
            yield return new WaitForSeconds(0.001f);
        }

        HUDManager.ShowCountdown(0);
        Time.timeScale = 1f;
        Reset = false;
    }

    private void MoveBackground()
    {
        float speed = 5f;
        float yThreshold = -10.5f;
        Vector3 startV = new Vector3(0, 10.5f);

        backG1.transform.position += new Vector3(0, -speed) * Time.deltaTime;
        backG2.transform.position += new Vector3(0, -speed) * Time.deltaTime;

        if (backG1.transform.position.y < yThreshold)
        {
            backG1.transform.position = startV;
        }
        if (backG2.transform.position.y < yThreshold)
        {
            backG2.transform.position = startV;
        }
    }
}
