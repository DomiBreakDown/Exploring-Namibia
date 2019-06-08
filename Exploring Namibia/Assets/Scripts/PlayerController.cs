using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float x, y;
    private readonly float speed = 8.0f;
    private int lifePoints = 10;
    private int itemsCollected = 0;

    private Rigidbody2D rigid2D;
    private AudioSource audioSource;
    private HUDManager hudManager;

    private void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        rigid2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        rigid2D.gravityScale = 0.0f;
        rigid2D.drag = speed; // removes inertia

        audioSource = GameObject.Find("HitObstacleAudio").GetComponent<AudioSource>();
        hudManager = GameObject.Find("HUD").GetComponent<HUDManager>();
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
        audioSource.Play(); // https://www.youtube.com/watch?v=NTnaMsGryJ4
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
        if(itemsCollected > 4)
        {
            hudManager.ShowScoreScreen(itemsCollected, lifePoints);
            this.gameObject.SetActive(false);
        }
    }

    public void Reset()
    {
        lifePoints = 10;
        itemsCollected = 0;
        this.transform.position = new Vector3(0, -4);
        this.transform.gameObject.SetActive(true);
    }
}
