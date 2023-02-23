using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmuTakeDamage : MonoBehaviour
{
    public float health;

    public void TakeDamge(float damage)
    {
        health -= damage;
    }
    private void Update()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
