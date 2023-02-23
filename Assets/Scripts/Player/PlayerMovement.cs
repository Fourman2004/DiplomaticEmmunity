using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerBody;
    public float moveSpeed = 1f; // movement speed
    public int controllerSettings = 0;
    private bool facingRight = true; // checks if player is facing right
    private GameObject firePoint;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        playerBody = this.GetComponent<Rigidbody2D>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
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
