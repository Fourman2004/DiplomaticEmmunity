using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public class Interact : MonoBehaviour
{

    private PlayerUIInterface UIManager;
    private Behaviour PlayerMovement;
    private List<string> InputKey = new List<string> {"KeyboardInteract", "ControllerInteract" };
    public bool ControllerControls;


    void Start()
    {
        UIManager = GameObject.Find("UI Manager").GetComponent<PlayerUIInterface>();
        PlayerMovement = GetComponent<PlayerMovement>();
    }

    void OnTriggerStay2D(Collider2D collisionInfo) 
    {  
        if (Input.GetButton(InputKey[Convert.ToInt32(ControllerControls)])) // false = keyboard interact, true = controller interact
        {
            Cursor.visible = true;
            if (collisionInfo.gameObject.tag == "Tower Spot")
            {
                int PlayerNum = (int)Char.GetNumericValue(transform.name[transform.name.Length-1]);
                int TowerNum = (int)Char.GetNumericValue(collisionInfo.transform.name[collisionInfo.transform.name.Length-1]);
                UIManager.StartInteraction(PlayerNum-1, TowerNum);
            }
        }
    }
}
