using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float Maxhealth;
    public float health;
    // Start is called before the first frame update
    void Start()
    {
        health = Maxhealth;
    }

    // Update is called once per frame
    
    public void Damaged(int damage)
    {
        if (health != 0)
        {
          health -= damage;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
