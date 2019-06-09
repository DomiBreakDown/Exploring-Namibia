using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    private readonly static int obstacleCount = 3;
    private readonly float minSpeed = 7.0f;
    private readonly float maxSpeed = 7.0f;

    private MiniGameManager miniGameManager;
    private PlayerController playerController;
    private SpriteRenderer spriteRenderer;

    public Sprite[] obstacles = new Sprite[obstacleCount];

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
        return (int)Random.Range(0, obstacleCount);
    }

    private Vector2 RndStartV()
    {
        float y = Random.Range(5.5f, 7.0f);
        float x = Random.Range(-5.1f, 5.1f);

        return new Vector2(x, y);
    }

    private void SpawnObstacle()
    {
        Instantiate(this.gameObject);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /* Player gets hit */
        if (collision.gameObject.tag == "Player" && this.gameObject.layer == 9)
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


        this.transform.position += new Vector3(0, -Random.Range(minSpeed, maxSpeed)) * Time.deltaTime;

        if (this.transform.position.y < -5.5f)
        {
            this.SpawnObstacle();
        }
    }
}
