using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class PlayerHealth : MonoBehaviour
{
    private Collider2D Collider2D;
    public float Maxhealth;
    public float health;
    public Slider slider;


    private void Start()
    {
        health = Maxhealth;
        slider.maxValue = health;
        slider.value = health;
        Collider2D = this.GetComponent<Collider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Untagged")
        {
            Physics2D.IgnoreCollision(collision.collider, Collider2D);
        }
        else if (collision.transform.tag == "Tower")
        {
            Physics2D.IgnoreCollision(collision.collider, Collider2D);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        slider.value = health;
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
