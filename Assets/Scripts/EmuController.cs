using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmuController : MonoBehaviour
{
    public float moveSpeed = 1f; // movement speed
    public Rigidbody2D playerRB; // reference to player 1 rigidbody
    Vector2 movement; // movement vector
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // refers to player 1's input axes from the input manager (WASD)
        movement.x = Input.GetAxisRaw("Horizontal1");
        movement.y = Input.GetAxisRaw("Vertical1");
    }

    void FixedUpdate()
    {
        // moves the player
        playerRB.MovePosition(playerRB.position + movement * moveSpeed * Time.deltaTime);
    }
}
