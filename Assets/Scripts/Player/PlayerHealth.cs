using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float Maxhealth;
    public float health;
    private Collider2D Collider2D;
    // Start is called before the first frame update
    void Start()
    {
        health = Maxhealth;
        Collider2D = this.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Untagged")
        {
            Physics2D.IgnoreCollision(collision.collider, Collider2D);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

}
