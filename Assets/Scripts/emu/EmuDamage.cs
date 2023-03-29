using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmuDamage : MonoBehaviour
{
    public int emuDamage;
    //creating an instance of the Wallhealth script
    public float cooldown;
    float lastHit;
    private Collider2D collider;
    
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider2D>();
    }

    //accessing OnCollisionStay as we intend to stay in contact with the object until it is destroyed
    private void OnCollisionStay2D(Collision2D collision)
    {
        //making it differentiate collision based on tag
        if (collision.gameObject.tag == "Wall")
        {
            FarmHealth farm = collision.gameObject.GetComponent<FarmHealth>();
            //attack delay as to not instantly kill everything
            if (Time.time - lastHit < cooldown)
            {
                return;
            }
            lastHit = Time.time;
            //calling on the public void in farm health script
            farm.DammageFarm(emuDamage);

        }
        else if (collision.gameObject.tag == "Player")
        {
            PlayerHealth player = collision.gameObject.GetComponent<PlayerHealth>();
            if (Time.time - lastHit < cooldown)
            {
                return;
            }
            lastHit = Time.time;
            //calling on the public void in player health script
            
            player.TakeDamage(emuDamage);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ignores colliding with other emus
        if (collision.gameObject.tag == "Emu")
        {
            Physics2D.IgnoreCollision(collision.collider, collider);
        }
    }
}
