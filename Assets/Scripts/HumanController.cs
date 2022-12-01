using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanController : MonoBehaviour
{
    public float moveSpeed = 1f; // movement speed
    public Rigidbody2D playerRB; // reference to player 2 rigidbody
    Vector2 movement; // movement vector
    bool facingRight = true; // true when facing right, false when left
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // refers to player 2's input axes from the input manager (arrow keys)
        movement.x = Input.GetAxisRaw("Horizontal2");
        movement.y = Input.GetAxisRaw("Vertical2");
        // flips the character horizontally
        if (movement.x < 0 && facingRight == true)
        {
            transform.Rotate(0,180,0);
            facingRight = false;
        }
        if (movement.x > 0 && facingRight == false)
        {
            transform.Rotate(0,-180,0);
            facingRight = true;
        }
    }

    private void FixedUpdate()
    {
        // moves the player
        playerRB.MovePosition(playerRB.position + movement * moveSpeed * Time.deltaTime);
    }
}
