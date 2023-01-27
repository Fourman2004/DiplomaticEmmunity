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
        
    }
    private void FixedUpdate()
    {
        switch (playerNo)
        {
            case 1:
                KeyboardInput();
                break;
            case 2:
                break;
            default:
                Debug.LogError("Not a valid player number.");
                break;
        }
    }

    private void KeyboardInput()
    {
        Vector2 thisPosition = this.transform.position;
        float x = firePoint.transform.position.x;
        float y = firePoint.transform.position.y;
        if (Input.GetKey("j"))
        {
            firePoint.transform.position = new Vector2(x * 1, y);
        }
        else if (Input.GetKey("k"))
        {
            firePoint.transform.position = new Vector2(thisPosition.x, x * -1);
        }
        else if (Input.GetKey("l"))
        {
            firePoint.transform.position = new Vector2(x* -1, y);
        }
        else if (Input.GetKey("i"))
        {
            firePoint.transform.position = new Vector2(thisPosition.x, x * 1);
        }
    }
}
