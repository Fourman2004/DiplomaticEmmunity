using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerBody;
    private bool facingRight = true; // checks if player is facing right
    private GameObject gun;
    private SpriteRenderer spriteRenderer;
    public float moveSpeed = 1f; // movement speed
    public int controllerSettings = 0;
    private Collider2D collider;

    // Start is called before the first frame update
    void Start()
    {
        playerBody = this.GetComponent<Rigidbody2D>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        collider = this.GetComponent<Collider2D>();
    }

    private void FixedUpdate()
    {
        Vector2 movement = Vector2.zero; 
        switch(controllerSettings)
        {
            case 1: // player 1's input
                movement += Vector2.up * Convert.ToInt32(Input.GetKey("w"));
                movement += Vector2.left * Convert.ToInt32(Input.GetKey("a"));
                movement += Vector2.down * Convert.ToInt32(Input.GetKey("s"));
                movement += Vector2.right * Convert.ToInt32(Input.GetKey("d"));
                break;
            case 2: // player 2's input
                movement += Vector2.up * Convert.ToInt32(Input.GetKey("up"));
                movement += Vector2.left * Convert.ToInt32(Input.GetKey("left"));
                movement += Vector2.down * Convert.ToInt32(Input.GetKey("down"));
                movement += Vector2.right * Convert.ToInt32(Input.GetKey("right"));
                break;
        }

        movement.Normalize();

        if ((movement.x < 0) && (facingRight == true))
        {
            //spriteRenderer.flipX = true;
            facingRight = false;
            this.transform.Rotate(0, 180f, 0f);
        }
        else if ((movement.x > 0) && (facingRight == false))
        {
            //spriteRenderer.flipX = false;
            facingRight = true;
            this.transform.Rotate(0,180f,0f);
        }

        playerBody.MovePosition(playerBody.position + movement * moveSpeed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Emu")
        {
            Physics2D.IgnoreCollision(collision.collider, collider);
        }
    }
}
