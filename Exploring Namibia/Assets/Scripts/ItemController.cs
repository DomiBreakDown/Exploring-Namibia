using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    private static int itemsCollected = 0;

    private static int itemCounter = 0;

    private static int spriteCount = 4;
    private readonly float minSpeed = 4.0f;
    private readonly float maxSpeed = 8.0f;

    private SpriteRenderer spriteRenderer;
    public Sprite[] itemSprites = new Sprite[spriteCount];

    private int RndSpriteIndex()
    {
        return (int)Random.Range(0, spriteCount);
    }

    private Vector2 RndStartV()
    {
        float y = 5.0f;
        float x = Random.Range(-5.1f, 5.1f);

        return new Vector2(x, y);
    }

    private void Start()
    {
        this.gameObject.name = "item_" + itemCounter;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = itemSprites[RndSpriteIndex()];

        // Mehr Informationen ueber das Item hier spezifizieren:
        // Ist das Essen fuer das Tier brauchbar?
        // Falls ja dann ++score ansonsten --score

        Vector3 startV = RndStartV();
        this.transform.position = startV;
    }

    private void SpawnItem()
    {
        ++itemCounter;
        Instantiate(this.gameObject);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            ++itemsCollected;
            Debug.Log("Items collected: " + itemsCollected);
            this.SpawnItem();
        }
        
    }

    void Update()
    {
        this.transform.position += new Vector3(0, - Random.Range(minSpeed, maxSpeed)) * Time.deltaTime;

        if(this.transform.position.y < -5.5f)
        {
            this.SpawnItem();
        }
    }
}
