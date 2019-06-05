using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigid2D;
    private float x, y;
    private readonly float speed = 10.0f;

    private void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        rigid2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        rigid2D.gravityScale = 0.0f;
        rigid2D.drag = 10.0f; // removes inertia
    }

    void Update()
    {
        /* Movement with Mouse */
        if (Input.GetMouseButton(0))
        {
            Vector2 mouseV = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            this.rigid2D.position = mouseV;
        }

        /* Movement with Keyboard */
        else
        {
            x = Input.GetAxisRaw("Horizontal");
            y = Input.GetAxisRaw("Vertical");

            Vector2 velocity = new Vector2(x, y);
            velocity.Normalize();
            velocity *= speed;
            this.rigid2D.velocity = velocity;
        }
    }
}
