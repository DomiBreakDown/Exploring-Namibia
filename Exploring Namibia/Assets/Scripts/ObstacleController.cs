using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    private const int OBSTACLE_SPRITE_COUNT = 3;
    private const float MIN_SPEED = 5.0f; // minimum speed of the obstacle when falling
    private const float MAX_SPEED = 5.0f; // maximum speed of the obstacle when falling
    private const float Y_THRESHOLD = -5.5f; // Defines when the obstacle will despawn

    private MiniGameManager miniGameManager;
    private PlayerController playerController;
    private SpriteRenderer spriteRenderer;

    public Sprite[] obstacles = new Sprite[OBSTACLE_SPRITE_COUNT];

    private void Start()
    {
        miniGameManager = GameObject.Find("Minigame").GetComponent<MiniGameManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = obstacles[RndSpriteIndex()];

        this.gameObject.name = "obstacle";
        this.transform.position = RndStartV();
    }

    private int RndSpriteIndex()
    {
        return (int)Random.Range(0, OBSTACLE_SPRITE_COUNT);
    }

    private Vector2 RndStartV()
    {
        float y = Random.Range(MiniGameManager.Y_MIN_POS, MiniGameManager.Y_MAX_POS);
        float x = Random.Range(-MiniGameManager.X_BARRIER_POS, MiniGameManager.X_BARRIER_POS);

        return new Vector2(x, y);
    }

    private void SpawnObstacle()
    {
        Instantiate(this.gameObject);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerController.HurtPlayer();
            this.SpawnObstacle();
        }
    }

    private void Update()
    {
        if (miniGameManager.Reset)
        {
            this.SpawnObstacle();
        }

        if (GameObject.FindWithTag("Player") != null)
        {
            playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        }

        this.transform.position += new Vector3(0, -Random.Range(MIN_SPEED, MAX_SPEED)) * Time.deltaTime;

        if (this.transform.position.y < Y_THRESHOLD)
        {
            this.SpawnObstacle();
        }
    }
}
