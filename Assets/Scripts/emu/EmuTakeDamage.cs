using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmuTakeDamage : MonoBehaviour
{
   public float Maxhealth;
   public float health;
   public Moneymanager moneymanager;
    public void Start()
    {
        health = Maxhealth;
    }

    public void TakeDamge(float damage)
    {
        health -= damage;
    }
    public void Update()
    {
        if (health <= 0)
        {
            WaveSpawner.emusAlive--;     
            Destroy(this.gameObject);        
        }
    }

}
