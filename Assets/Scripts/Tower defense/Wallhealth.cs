using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallhealth : MonoBehaviour
{
    public int wallHP;
    public int currentWallHP;
    void Start()
    {
        currentWallHP = wallHP;
    }


    public void takeDamage(int damage)
    {
        currentWallHP -= damage;
        if (currentWallHP <= 0)
        {
            Destroy(gameObject);
        }
    }
    
       
        
            
         
    
}
