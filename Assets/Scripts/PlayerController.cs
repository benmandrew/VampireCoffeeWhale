using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour {
    public float speed = 5.0f;
    private float velX;
    private Rigidbody2D rb2D;
    private bool hasJumped;
    
    void Start() {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.freezeRotation = true;
        velX = 0.0f;
        hasJumped = false;
    }

    void Update() {
        velX = 0.0f;
        if (Input.GetKey(KeyCode.A)) {
            velX = -1.0f;
        } else if (Input.GetKey(KeyCode.D)) {
            velX = 1.0f;
        }

        if (Input.GetKeyDown(KeyCode.W) && !hasJumped) {
            rb2D.velocity = new Vector2(
                rb2D.velocity.x, 10f);
            hasJumped = true;
        }
    }

    void FixedUpdate() {
        rb2D.velocity = new Vector2(
            velX * speed,
            rb2D.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D col) {        
        hasJumped = false;
    }
}
