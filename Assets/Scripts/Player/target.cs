using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour
{
    private Rigidbody2D playerBody; // rigidbody of the mouse cursor
    private bool facingRight = true;
    private Transform firePoint;
    private SpriteRenderer spriteRenderer;
    // (1 = right on the mouse, 0.1 being barely moving at all, 2 being still following but less controllable)
    public float moveSpeed = 1f; // the speed the cursor should move at
    public bool controllerSetting = false;
    public Camera cam; // should reference the main camera
    Vector2 currentVelocity; // tracks the velocity of the object between frames
    void Start()
    {
        playerBody = this.GetComponent<Rigidbody2D>();
        firePoint = this.GetComponent<Transform>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    void Update()
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
            Vector2 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition) * moveSpeed; // gets position of mouse relative to screen position
            firePoint.transform.position = Vector2.SmoothDamp(transform.position, mousePosition, ref currentVelocity, moveSpeed * Time.deltaTime);  // moves cursor using mouse
        }
    }
    private void FixedUpdate()
    {

    }
}
