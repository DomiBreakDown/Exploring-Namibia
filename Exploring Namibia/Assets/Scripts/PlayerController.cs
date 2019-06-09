using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float x, y;
    private readonly float speed = 8.0f;
    private int lifePoints = 5;
    private int itemsCollected = 0;

    private Rigidbody2D rigid2D;
    private AudioSource obstacleAudioSource;
    private AudioSource startEngineAudioSource;
    private HUDManager hudManager;
    private MiniGameManager miniGameManager;

    private void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        rigid2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        rigid2D.gravityScale = 0.0f;
        rigid2D.drag = speed; // removes inertia

        obstacleAudioSource = GameObject.Find("HitObstacleAudio").GetComponent<AudioSource>();
        startEngineAudioSource = this.transform.GetChild(0).GetComponent<AudioSource>();
        hudManager = GameObject.Find("HUD").GetComponent<HUDManager>();
        miniGameManager = GameObject.Find("Minigame").GetComponent<MiniGameManager>();
    }

    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        Vector2 velocity = new Vector2(x, y);
        velocity.Normalize();
        velocity *= speed;
        this.rigid2D.velocity = velocity;
    }

    public void HurtPlayer()
    {
        lifePoints--;
        obstacleAudioSource.Play(); // https://www.youtube.com/watch?v=NTnaMsGryJ4
        hudManager.RemoveHeart();

        if (lifePoints == 0)
        {
            hudManager.ShowScoreScreen(itemsCollected, lifePoints);
            this.gameObject.SetActive(false);
        }
    }

    public void IncreaseItemsCollected()
    {
        itemsCollected++;
        hudManager.UpdateItemCounter(itemsCollected);
        if(itemsCollected > 9)
        {
            hudManager.ShowScoreScreen(itemsCollected, lifePoints);
            miniGameManager.NextIteration();
            this.gameObject.SetActive(false);
        }
    }

    public void Reset()
    {
        lifePoints = 5;
        itemsCollected = 0;
        this.transform.position = new Vector3(0, -4);
        this.transform.gameObject.SetActive(true);
    }

    public void StartEngine()
    {
        startEngineAudioSource.Play(); // https://freesound.org/people/Diramus/sounds/351421/
    }

    public int GetLifepoints()
    {
        return lifePoints;
    }
}
