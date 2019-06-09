using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MiniGameManager : MonoBehaviour
{
    // Bugs:

    // Nach dem Abschließen von Minispiel erneut Minispiel starten: 
    //    -> HUDManager:  
    //          heartsFilled[i] = HUD.transform.GetChild(0).GetChild(j).gameObject.GetComponent<Image>(); 
    //          index out of bounds

    // ESC -> Zurück zur bleibe -> zurück zum Minispiel : Spiel wird nicht wieder von vorne angefangen

    private PlayerController playerController;
    private HUDManager HUDManager;
    private GameObject backG1, backG2;

    private static int iteration = 0;
    private readonly int goal = 3;

    public int correctItemToBeCollected = 0;
    public bool Reset = false;
    public bool Finished = false;

    private void Awake()
    {
        playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        HUDManager = GameObject.Find("HUD").GetComponent<HUDManager>();

        backG1 = this.transform.GetChild(0).transform.gameObject;
        backG2 = this.transform.GetChild(1).transform.gameObject;

        Physics2D.IgnoreLayerCollision(0, 10);
        Physics2D.IgnoreLayerCollision(8, 10);
        Physics2D.IgnoreLayerCollision(9, 10);
    }

    private void Start()
    {
        backG1.transform.position = new Vector3(0, 0);
        backG2.transform.position = new Vector3(0, 10.5f);

        Finished = false;
        iteration = 0;
    }

    private void Update()
    {
        switch (iteration)
        {
            case 0:
                HUDManager.UpdateStartGamePanel("Phase 1: Sammle Futter für einen Löwen");
                correctItemToBeCollected = 0;
                break;
            case 1:
                HUDManager.UpdateStartGamePanel("Phase 2: Sammle Futter für ein Zebra");
                correctItemToBeCollected = 1;
                break;
            case 2:
                HUDManager.UpdateStartGamePanel("Phase 3: Sammle Futter für einen Elefanten");
                correctItemToBeCollected = 2;
                break;
            default:
                break;
        }

        if(iteration >= goal)
        {
            Finished = true;
            PlayerPrefs.SetInt("minigame1", 1);
        }

        MoveBackground();
    }

    public void NextIteration()
    {
        iteration++;
    }

    public bool CheckFinished()
    {
        return Finished;
    }

    public void StartGame()
    {
        backG1.transform.position = new Vector3(0, 0);
        backG2.transform.position = new Vector3(0, 10.5f);
        Reset = true;
        playerController.Reset();
        HUDManager.Reset();
        HUDManager.UpdateStartGamePanel(false);
        StartCoroutine(Countdown());
        PauseMenu.gameIsPaused = false;
    }

    private IEnumerator Countdown()
    {
        playerController.StartEngine();
        Time.timeScale = 0.001f;
        
        int c = 3;
        while (c > 0)
        {
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
