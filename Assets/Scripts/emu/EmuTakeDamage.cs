using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmuTakeDamage : MonoBehaviour
{
    public float Maxhealth;
   public float health;
    public UIMoneyDisplay Money;
    public int Moneydropped;

    public void Start()
    {
        health = Maxhealth;
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
            Money.Internalmoney = Money.Internalmoney + Moneydropped;
            Debug.Log(Money.Internalmoney);
        }
    }
}
