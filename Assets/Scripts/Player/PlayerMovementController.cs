using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovementController : MonoBehaviour
{
    private Rigidbody2D playerBody;
    private GameObject firePoint;
    public float moveSpeed = 1f;


    void Start()
    {
        playerBody = this.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 movement = Vector2.zero;
        movement += Vector2.right * Input.GetAxis("HorizontalController");
        movement += Vector2.down * Input.GetAxis("VerticalController");
        movement.Normalize();
        playerBody.MovePosition(playerBody.position + movement * moveSpeed * Time.deltaTime);
    }
}
