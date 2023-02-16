using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    public int playerNo;
    public GameObject firePoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (playerNo)
        {
            //case 1:
            //    // removed keyboard input
            //    Debug.Log("no");
            //    break;
            //case 2:
            //    break;
            default:
                MouseInput();
                break;
        }
    }

    private void MouseInput()
    {
        // rotates player based on mouse position
        var pos = Camera.main.WorldToScreenPoint(transform.position);
        var dir = Input.mousePosition - pos;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        firePoint.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void FixedUpdate()
    {
        
    }

    private void KeyboardInput()
    {
        Vector2 thisPosition = this.transform.position;
        float x = firePoint.transform.position.x;
        float y = firePoint.transform.position.y;
        if (Input.GetKeyDown("j") && (firePoint.transform.rotation.y == 0)) // left
        {
            firePoint.transform.RotateAround(this.transform.position, new Vector3(0,180,0) , 180);
        }
        else if (Input.GetKeyDown("k") && (this.transform.rotation.z == 0)) // down
        {
            firePoint.transform.RotateAround(this.transform.position, new Vector3(0, 0, 90), -90);
        }
        else if (Input.GetKeyDown("l") && (firePoint.transform.rotation.y != 0)) // right
        {
            firePoint.transform.RotateAround(this.transform.position, new Vector3(0, 180, 0), -180);
            Debug.Log("Player 1 is facing right");
        }
        else if (Input.GetKeyDown("i") && (this.transform.position.z == 90)) // up
        {
            firePoint.transform.RotateAround(this.transform.position, new Vector3(0, 0, 90), 180);
        }
    }
}
