using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this script gets controller input
public class PlayerMovementController : MonoBehaviour
{
    private Rigidbody2D playerBody;
    private GameObject firePoint;
    public float moveSpeed = 1f; // movement speed


    // Start is called before the first frame update
    void Start()
    {
        playerBody = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        GetControllerInput();
    }

    private void GetControllerInput()
    {
        Vector2 movement = Vector2.zero;
        movement += Vector2.right * Input.GetAxis("HorizontalController");
        movement += Vector2.down * Input.GetAxis("VerticalController");
        movement.Normalize();
        playerBody.MovePosition(playerBody.position + movement * moveSpeed * Time.deltaTime);
    }
}
