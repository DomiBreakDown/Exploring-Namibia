using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MiniGameManager : MonoBehaviour
{
    private GameObject startGamePanel;
    private TextMeshProUGUI txtObjective;
    private PlayerController playerController;
    private HUDManager HUDManager;
    private GameObject backG1, backG2;

    private static int iteration = 0;
    private readonly int goal = 3;
    private static bool started = false;
    private static bool starting = false;
    private bool success = false;

    public int[] correctItemToBeCollected;

    private void Awake()
    {
        startGamePanel = GameObject.Find("Panel-StartGame");
        txtObjective = startGamePanel.transform.GetChild(2).transform.gameObject.GetComponent<TextMeshProUGUI>();
        playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        HUDManager = GameObject.Find("HUD").GetComponent<HUDManager>();

        backG1 = this.transform.GetChild(0).transform.gameObject;
        backG2 = this.transform.GetChild(1).transform.gameObject;

        correctItemToBeCollected = new int[2];

        // default values
        correctItemToBeCollected[0] = 0;
        correctItemToBeCollected[1] = 1;

        Physics2D.IgnoreLayerCollision(0, 10);
        Physics2D.IgnoreLayerCollision(8, 10);
        Physics2D.IgnoreLayerCollision(9, 10);
    }

    private void Update()
    {
        switch (iteration)
        {
            case 0:
                txtObjective.text = "Phase 1: Sammle Futter für einen Löwen";
                correctItemToBeCollected[0] = 0;
                correctItemToBeCollected[1] = 1;
                break;
            case 1:
                txtObjective.text = "Phase 2: Sammle Futter für ein Zebra";
                correctItemToBeCollected[0] = 2;
                correctItemToBeCollected[1] = -1;
                break;
            case 2:
                txtObjective.text = "Phase 3: Sammle Futter für einen Elefanten";
                correctItemToBeCollected[0] = 3;
                correctItemToBeCollected[1] = -1;
                break;
            default:
                break;
        }

        ManagePause();
        MoveBackground();
    }

    private void ManagePause()
    {
        if(!started)
        {
            startGamePanel.SetActive(true);
            PauseMenu.gameIsPaused = true;
            Time.timeScale = 0f;
        }
        else
        {
            startGamePanel.SetActive(false);
            PauseMenu.gameIsPaused = false;
            Time.timeScale = 1.0f;
        }

        if(starting)
        {
            Time.timeScale = 0.001f;
        }
    }

    public void NextIteration()
    {
        if(success)
        {
            iteration++;
            if (iteration >= goal)
            {
                PlayerPrefs.SetInt("minigame1", 1);
                HUDManager.ShowEndScreen();
            }
            else
            {
                started = false;
            }
        }
        else
        {
            started = false;
        }
        
    }

    public void Succeeded(bool success)
    {
        this.success = success;
    }

    public void StartGame()
    {
        playerController.Reset();
        HUDManager.Reset();
        started = true;
        StartCoroutine(Countdown());
        starting = true;
    }

    private IEnumerator Countdown()
    {
        int c = 3;
        while (c > 0)
        {
            HUDManager.ShowCountdown(c);
            yield return new WaitForSeconds(0.001f);
            c--;
        }

        HUDManager.ShowCountdown(0);
        starting = false;
        started = true;
    }

    private void MoveBackground()
    {
        float speed = 7f;
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
