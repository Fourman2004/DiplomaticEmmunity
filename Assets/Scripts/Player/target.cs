using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour
{
    private Rigidbody2D playerBody;
    private bool facingRight = true;
    private GameObject firePoint;
    private SpriteRenderer spriteRenderer;
    public float moveSpeed = 1f;
    public bool controllerSetting = false;

    void Start()
    {
        playerBody = this.GetComponent<Rigidbody2D>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        Vector2 movement = Vector2.zero;
        if (controllerSetting == true)
        {
            movement += Vector2.right * Input.GetAxis("targetingH");
            movement += Vector2.down * Input.GetAxis("targetingV");
        }
        else
        {
            movement += Vector2.right * Input.GetAxis("Mouse X");
            movement += Vector2.up * Input.GetAxis("Mouse Y");
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
