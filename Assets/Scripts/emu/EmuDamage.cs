using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmuDamage : MonoBehaviour
{
    public int Walldamage;
    //creating an instance of the Wallhealth script
    public Wallhealth wallhealth;
    public PlayerHealth playerhealth;
    public float cooldown;
    float lastHit;
    private Collider2D collider;
    
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider2D>();
    }

    //accessing OnCollisionStay as we intend to stay in contact with the object until it is destroyed
   public void OnCollisionStay2D(Collision2D collision)
    {
        //making it differentiate collision based on tag
        if(collision.gameObject.tag == "Wall")
        {
            //attack delay as to not instantly kill everything
            if (Time.time - lastHit < cooldown)
            {
                return;
            }
            lastHit = Time.time;
            //calling on the public void in Wallhealth script
            wallhealth.takeDamage(Walldamage);

        }
        else if (collision.gameObject.tag == "Player")
        {
            if (Time.time - lastHit < cooldown)
            {
                return;
            }
            lastHit = Time.time;
            //calling on the public void in Wallhealth script
            playerhealth.TakeDamage(Walldamage);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Emu")
        {
            Physics2D.IgnoreCollision(collision.collider, collider);
        }
    }
}
