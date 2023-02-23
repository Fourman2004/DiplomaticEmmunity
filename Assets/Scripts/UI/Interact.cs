using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public class Interact : MonoBehaviour
{

    private PlayerUIInterface UIManager;
    private Behaviour PlayerMovement; 


    void Start()
    {
        UIManager = GameObject.Find("UI Manager").GetComponent<PlayerUIInterface>();
        PlayerMovement = GetComponent<PlayerMovement>();
    }

    void OnTriggerStay2D(Collider2D collisionInfo) 
    {  
        if (Input.GetKey("e"))
        {
            if (collisionInfo.gameObject.tag == "Tower Spot")
            {
                int PlayerNum = (int)Char.GetNumericValue(transform.name[transform.name.Length-1]);
                int TowerNum = (int)Char.GetNumericValue(collisionInfo.transform.name[collisionInfo.transform.name.Length-1]);
                UIManager.StartInteraction(PlayerNum-1, TowerNum);
            }
        }
    }
}
