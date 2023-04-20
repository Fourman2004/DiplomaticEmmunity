using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MEDIC : MonoBehaviour
{
    public PlayerHealth PH;
    public FarmHealth FH;
    public GameObject farm, player, projectile;
    public float timer, projectileSpeed, heal;
    private Transform projectileMove;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
        farm = GameObject.FindGameObjectWithTag("Farm");
    }

    // Update is called once per frame
    void Update()
    {
      if(PH.health > FH.currentHealth)
        {
            HealPlayer();
        }  
      else if (PH.health < FH.currentHealth)
        {
            Healfarm();
        }
      else
        {
            Debug.Log("Nothing to heal");
        }
    }

    public void HealPlayer()
    {
        Debug.Log("Player heals");
        projectile = Instantiate(projectile, projectileMove.position, Quaternion.identity);
    }  
    public void Healfarm()
    {
        Debug.Log("Farm heals");
    }
}
