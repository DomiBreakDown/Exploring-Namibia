using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public const int LIFE_POINTS = 5; // maximum 10 life points
    private const int MAX_ITEM_NR = 10; // how much items to reach the end of the current stage
    private const float SPEED = 6.0f; // speed of player
    private Vector3 START_V = new Vector3(0, -4); // start position of the player

    private float x, y;
    private int currLifePoints = LIFE_POINTS;
    private int itemsCollected = 0;

    private Rigidbody2D rigid2D;
    private HUDManagerMinigame01 hudManager;
    private MiniGameManager miniGameManager;
    private AudioManager audioManager;

    private void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        rigid2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        rigid2D.gravityScale = 0.0f;
        rigid2D.drag = SPEED; // removes inertia

        hudManager = GameObject.Find("HUD").GetComponent<HUDManagerMinigame01>();
        miniGameManager = GameObject.Find("Minigame").GetComponent<MiniGameManager>();
        audioManager = GameObject.Find("Audio").GetComponent<AudioManager>();
    }

    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        Vector2 velocity = new Vector2(x, y);
        velocity.Normalize();
        velocity *= SPEED;
        this.rigid2D.velocity = velocity;
    }

    public void HurtPlayer()
    {
        currLifePoints--;
        hudManager.RemoveHeart();

        if (currLifePoints < 1)
        {
            hudManager.ShowDeathScreen(true);
            this.gameObject.SetActive(false);
            audioManager.DeathSound();
        }
        else
        {
            audioManager.ReceiveDamage();
        }
    }

    public void IncreaseItemsCollected(int itemNr)
    {
        itemsCollected++;
        hudManager.UpdateItemCounter(itemsCollected);

        if(itemsCollected >= MAX_ITEM_NR)
        {
            hudManager.ShowScoreScreen(itemsCollected, itemNr);
            miniGameManager.NextIteration();
            this.gameObject.SetActive(false);
        }
    }

    public void Reset()
    {
        currLifePoints = LIFE_POINTS;
        itemsCollected = 0;
        this.transform.position = START_V;
        this.transform.gameObject.SetActive(true);
    }

    public void StartEngine()
    {
        audioManager.StartEngine();
    }

    public int GetLifepoints()
    {
        return currLifePoints;
    }
}
