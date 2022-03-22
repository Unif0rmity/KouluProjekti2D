using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public PlayerStats stats;
    public Rigidbody2D rb;
    private Vector2 moveDirection;


    void Start()
    {
        Application.targetFrameRate = 120;
    }

    private void FixedUpdate()
    {
        Vector2 force = new Vector2(moveDirection.x * stats.moveSpeed - rb.velocity.x, 0f);
        rb.AddForce(force, ForceMode2D.Impulse);
    }
    void Update()
    {
        moveDirection = new Vector2(Input.GetAxis("Horizontal"), 0f);
        HandleFlipping();
        if (Input.GetButtonDown("Jump"))
            HandleJumping();
    }

    private void HandleJumping()
    {
        if (moveDirection.x == 0f) return;
        rb.AddForce(Vector2.up * stats.jumpForce, ForceMode2D.Impulse);
    }

    private void HandleFlipping()
    {
        if (moveDirection.x == 0f) return;
        transform.localScale = new Vector3(Mathf.Sign(moveDirection.x), 1f, 1f);
    }
}
