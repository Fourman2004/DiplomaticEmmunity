using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovementController : MonoBehaviour
{
    private Rigidbody2D playerBody;
    private bool facingRight = true; // checks if player is facing right
    private GameObject firePoint;
    private SpriteRenderer spriteRenderer;
    public float moveSpeed = 1f;


    void Start()
    {
        playerBody = this.GetComponent<Rigidbody2D>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        Vector2 movement = Vector2.zero;
        movement += Vector2.right * Input.GetAxis("HorizontalController");
        movement += Vector2.down * Input.GetAxis("VerticalController");

        movement.Normalize();

        if ((movement.x < 0) && (facingRight == true))
        {
            spriteRenderer.flipX = true;
            facingRight = false;
        }
        else if ((movement.x > 0) && (facingRight == false))
        {
            spriteRenderer.flipX = false;
            facingRight = true;
        }

        playerBody.MovePosition(playerBody.position + movement * moveSpeed * Time.deltaTime);
    }
}
