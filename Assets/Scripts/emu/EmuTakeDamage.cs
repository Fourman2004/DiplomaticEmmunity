using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmuTakeDamage : MonoBehaviour
{
   public float Maxhealth;
   public float health;
    public int Moneydropped;
    public UIMoneyDisplay moneydisplay;

    public void Start()
    {
        health = Maxhealth;
        //Moneydropped = Maxhealth / 10;
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
            //moneydisplay.Internalmoney += Moneydropped; // commented for now as it stopped the emus being destroyed
            Destroy(this.gameObject);
            //Debug.Log("Money:" + moneydisplay.Internalmoney);
        }
    }

}
