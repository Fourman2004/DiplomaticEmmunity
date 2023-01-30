using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmuDamage : MonoBehaviour
{
    public int damage;
    public Wallhealth wallhealth;
    public float cooldown;
    float lastHit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            if (Time.time - lastHit < cooldown)
            {
                return;
            }
            lastHit = Time.time;
            wallhealth.takeDamage(damage);
        }
    }
}
