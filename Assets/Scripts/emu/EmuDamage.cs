using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmuDamage : MonoBehaviour
{
    public int emuDamage;
    //creating an instance of the Wallhealth script
    public float cooldown;
    float timer;
    float lastHit;
    private Collider2D collider;
    public GameObject beak;
    public float range = 10f;
    
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider2D>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ignores colliding with other emus
        if (collision.gameObject.tag == "Emu")
        {
            Physics2D.IgnoreCollision(collision.collider, collider);
        }
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > cooldown)
        {
            PeckAttack();
        }
    }

    private void PeckAttack()
    {
        RaycastHit2D hit2D = Physics2D.Raycast(beak.transform.position, beak.transform.right, range);
        if (hit2D)
        {
            Debug.Log("emu hit " + hit2D.transform.name);
            if (hit2D.transform.tag == "Player")
            {
                PlayerHealth damageScript = hit2D.transform.gameObject.GetComponent<PlayerHealth>();
                damageScript.TakeDamage(emuDamage);
            }
            else if (hit2D.transform.tag == "Wall")
            {
                FarmHealth damageScript = hit2D.transform.gameObject.GetComponent<FarmHealth>();
                damageScript.DammageFarm(emuDamage);
            }
            timer = 0;
        }
    }
}
