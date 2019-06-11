using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    private readonly static int spriteCount = 3;

    private readonly float minSpeed = 5.0f;
    private readonly float maxSpeed = 5.0f;

    private bool correctItem = false;

    private MiniGameManager miniGameManager;
    private SpriteRenderer spriteRenderer;
    private AudioSource audioSource;
    private PlayerController playerController;

    public Sprite[] itemSprites = new Sprite[spriteCount];

    private void Start()
    {
        miniGameManager = GameObject.Find("Minigame").GetComponent<MiniGameManager>();
        audioSource = GameObject.Find("PickupAudio").GetComponent<AudioSource>();

        this.gameObject.name = "item";
        this.transform.position = RndStartV();

        int i = RndSpriteIndex();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = itemSprites[i];

        if(i == miniGameManager.correctItemToBeCollected)
        {
            correctItem = true;
        }
    }

    private int RndSpriteIndex()
    {
        return (int)Random.Range(0, spriteCount);
    }

    private Vector2 RndStartV()
    {
        float y = Random.Range(5.5f, 8.0f);
        float x = Random.Range(-7.2f, 7.2f);

        return new Vector2(x, y);
    }

    private void SpawnItem()
    {
        Instantiate(this.gameObject);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && this.gameObject.layer == 8)
        {
           if(correctItem)
            {
                audioSource.Play(); // https://freesound.org/people/LeMudCrab/sounds/163452/
                playerController.IncreaseItemsCollected();
            }
           else
            {
                playerController.HurtPlayer();
            }

            this.SpawnItem();
        }
    }

    void Update()
    {
        if(miniGameManager.Reset)
        {
            this.SpawnItem();
        }

        if (GameObject.FindWithTag("Player") != null)
        {
            playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        }


        this.transform.position += new Vector3(0, - Random.Range(minSpeed, maxSpeed)) * Time.deltaTime;

        if(this.transform.position.y < -5.5f)
        {
            this.SpawnItem();
        }
    }
}
