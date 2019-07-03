using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    private const int ITEM_SPRITE_COUNT = 3;
    private const float MIN_SPEED = 5.0f; // minimum speed of the item when falling
    private const float MAX_SPEED = 5.0f; // maximum speed of the item when falling
    private const float Y_THRESHOLD = -5.5f; // defines when the item will despawn

    private bool correctItem = false;

    private MiniGameManager miniGameManager;
    private PlayerController playerController;
    private AudioManager audioManager;

    private SpriteRenderer spriteRenderer;
    public Sprite[] itemSprites = new Sprite[ITEM_SPRITE_COUNT];

    private int itemNr;

    private void Start()
    {
        miniGameManager = GameObject.Find("Minigame").GetComponent<MiniGameManager>();
        audioManager = GameObject.Find("Audio").GetComponent<AudioManager>();

        this.gameObject.name = "item";
        this.transform.position = RndStartV();

        itemNr = RndSpriteIndex();

        if(itemNr == 0)
        {
            // gazelle has bigger image -> double the size of the collider
            GetComponent<BoxCollider2D>().size = new Vector2(1f, 1f);
        }
        else
        {
            // default collider size
            GetComponent<BoxCollider2D>().size = new Vector2(0.5f, 0.5f);
        }

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = itemSprites[itemNr];

        if(itemNr == miniGameManager.correctItemToBeCollected)
        {
            correctItem = true;
        }
    }

    private int RndSpriteIndex()
    {
        return (int)Random.Range(0, ITEM_SPRITE_COUNT);
    }

    private Vector2 RndStartV()
    {
        float y = Random.Range(MiniGameManager.Y_MIN_POS, MiniGameManager.Y_MAX_POS);
        float x = Random.Range(-MiniGameManager.X_BARRIER_POS, MiniGameManager.X_BARRIER_POS);

        return new Vector2(x, y);
    }

    private void SpawnItem()
    {
        Instantiate(this.gameObject);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
           if(correctItem)
            {
                audioManager.PickUpItem();
                playerController.IncreaseItemsCollected(itemNr);
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

        this.transform.position += new Vector3(0, - Random.Range(MIN_SPEED, MAX_SPEED)) * Time.deltaTime;

        if(this.transform.position.y < Y_THRESHOLD)
        {
            this.SpawnItem();
        }
    }
}
