using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour
{
    private Rigidbody2D playerBody;
    private bool facingRight = true;
    private Transform firePoint;
    private SpriteRenderer spriteRenderer;
    public float moveSpeed = 1f;
    public bool controllerSetting = false;
    private Vector3 position;

    void Start()
    {
        playerBody = this.GetComponent<Rigidbody2D>();
        firePoint = this.GetComponent<Transform>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Vector2 movement = Vector2.zero;
        if (controllerSetting == true)
        {
            movement += Vector2.right * Input.GetAxis("targetingH");
            movement += Vector2.down * Input.GetAxis("targetingV");
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
        else
        {
            Vector3 mousePosition = Input.mousePosition;
            transform.position = Vector2.MoveTowards(transform.position, mousePosition, moveSpeed * Time.deltaTime);
            Debug.Log(mousePosition);
        }
    }
    private void FixedUpdate()
    {

    }
}
