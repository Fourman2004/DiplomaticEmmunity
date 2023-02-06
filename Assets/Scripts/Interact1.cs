using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public class Interact1 : MonoBehaviour
{

    private PlayerUIInterface UIManager;
    private Behaviour PlayerMovement;


    void Start()
    {
        UIManager = GameObject.Find("UI Manager").GetComponent<PlayerUIInterface>();
        PlayerMovement = GetComponent<PlayerMovement>();
    }


    void Update()
    {
        if (Input.GetKeyDown("l"))
        {
            int PlayerNum = (int)Char.GetNumericValue(transform.name[7]);
            UIManager.StartInteraction(PlayerNum-1, 0);
        }
    }
}
