using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmuTakeDamage : MonoBehaviour
{
   public float Maxhealth;
   public float health;
    public float Moneydropped;
    public UIMoneyDisplay moneydisplay;

    public void Start()
    {
        health = Maxhealth;
        Moneydropped = Maxhealth / 10;
    }

    public void TakeDamge(float damage)
    {
        health -= damage;
    }
    private void Update()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
            moneydisplay.Internalmoney = moneydisplay.Internalmoney + Moneydropped;
            Debug.Log("Money:" + moneydisplay.Internalmoney);
        }
    }

}
