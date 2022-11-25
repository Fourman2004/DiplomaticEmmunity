using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmuController : MonoBehaviour
{
    public float moveSpeed = 1f;
    public Rigidbody2D playerRB;
    Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal1");
        movement.y = Input.GetAxisRaw("Vertical1");
    }

    void FixedUpdate()
    {
        playerRB.MovePosition(playerRB.position + movement * moveSpeed * Time.deltaTime);
    }
}
