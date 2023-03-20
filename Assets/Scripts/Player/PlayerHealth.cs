using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float Maxhealth;
    public float health;
    public Collider2D Collider2;
    // Start is called before the first frame update
    void Start()
    {
        health = Maxhealth;
        Collider2 = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

}
