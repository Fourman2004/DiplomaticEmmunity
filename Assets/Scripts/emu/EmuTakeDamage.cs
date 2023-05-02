using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmuTakeDamage : MonoBehaviour
{
   public float Maxhealth;
   public float health;
   private Moneymanager moneymanager;
    public int emuWorth;
    public void Start()
    {
        GameObject gameManager = GameObject.Find("Game Manager");
        moneymanager = gameManager.GetComponent<Moneymanager>();
        health = Maxhealth;
    }

    public void TakeDamge(float damage)
    {
        
        health -= damage;
    }
    public void Update()
    {
        if (health <= 0)
        {
            AudioClip deathClip = GameObject.Find("Game Manager").GetComponent<AudioManager>().emuDeath;
            GameObject.Find("Game Manager").GetComponent<AudioManager>().audioSource.PlayOneShot(deathClip);
            WaveSpawner.emusAlive--;
            moneymanager.EmuCash(emuWorth);
            Destroy(this.gameObject);        
        }
    }

}
