using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    private Rigidbody2D playerBody;
    public float moveSpeed = 1f; // movement speed
    
    // Start is called before the first frame update
    void Start()
    {
        playerBody = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector2 movement = Vector2.zero;
        Debug.Log(Input.GetAxis("HorizontalController"));
        Debug.Log(Input.GetAxis("VerticalController"));
        movement += Vector2.right * Input.GetAxis("HorizontalController");
        movement += Vector2.down * Input.GetAxis("VerticalController");
        playerBody.MovePosition(playerBody.position + movement * moveSpeed * Time.deltaTime);
    }
}
