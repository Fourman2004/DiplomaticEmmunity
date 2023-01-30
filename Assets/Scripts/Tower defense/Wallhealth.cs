using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallhealth : MonoBehaviour
{
    public int wallHP;
    public int currentWallHP;
    void Start()
    {
        //setting the walls hp
        currentWallHP = wallHP;
    }

    //public void which can be accessed by the emu damage script to lower the walls health.
    public void takeDamage(int damage)
    {
        //deducting walls health
        currentWallHP -= damage;
        if (currentWallHP <= 0)
        {
            Destroy(gameObject);
        }
    }
    
       
        
            
         
    
}
