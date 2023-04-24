using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerBody;
    private bool facingRight = true; // checks if player is facing right
    public float moveSpeed = 1f;
    public int controllerSettings = 0;


    private void Start()
    {
        playerBody = this.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 movement = Vector2.zero; 
        switch(controllerSettings)
        {
            case 1: // player 1's Keyboard input
                movement += Vector2.up * Convert.ToInt32(Input.GetKey("w"));
                movement += Vector2.left * Convert.ToInt32(Input.GetKey("a"));
                movement += Vector2.down * Convert.ToInt32(Input.GetKey("s"));
                movement += Vector2.right * Convert.ToInt32(Input.GetKey("d"));
                break;
            case 2: // player 2's Keyboard input
                movement += Vector2.up * Convert.ToInt32(Input.GetKey("up"));
                movement += Vector2.left * Convert.ToInt32(Input.GetKey("left"));
                movement += Vector2.down * Convert.ToInt32(Input.GetKey("down"));
                movement += Vector2.right * Convert.ToInt32(Input.GetKey("right"));
                break;
            case 3: // Controller input for both players
                movement += Vector2.right * Input.GetAxis("HorizontalController");
                movement += Vector2.down * Input.GetAxis("VerticalController");
                break;
        }

        movement.Normalize();

        if (((movement.x < 0) == facingRight) && movement.x != 0)
        {
            facingRight = !facingRight;
            this.transform.Rotate(0, 180f, 0f);
        }

        playerBody.MovePosition(playerBody.position + movement * moveSpeed * Time.deltaTime);
    }
}
