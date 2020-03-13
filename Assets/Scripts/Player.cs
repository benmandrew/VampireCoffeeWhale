using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour {
    public float speed = 100.0f;
    public float velX;
    private Rigidbody2D rb2D;
    
    void Start() {
        rb2D = GetComponent<Rigidbody2D>();
        velX = 0.0f;
    }

    void Update() {
        velX = 0.0f;
        if (Input.GetKey(KeyCode.A)) {
            velX = -1.0f;
        } else if (Input.GetKey(KeyCode.D)) {
            velX = 1.0f;
        }

        if (Input.GetKeyDown(KeyCode.W)) {
            rb2D.velocity = new Vector2(
                rb2D.velocity.x, 10f);
        }
    }

    void FixedUpdate() {
        rb2D.velocity = new Vector2(
            velX * speed * Time.fixedDeltaTime,
            rb2D.velocity.y);
    }
}
