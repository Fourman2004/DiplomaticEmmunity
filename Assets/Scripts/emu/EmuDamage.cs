using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmuDamage : MonoBehaviour
{
    public int damage;
    //creating an instance of the Wallhealth script
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
    //accessing OnCollisionStay as we intend to stay in contact with the object until it is destroyed
    private void OnCollisionStay2D(Collision2D collision)
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
            wallhealth.takeDamage(damage);
        }
    }
}
