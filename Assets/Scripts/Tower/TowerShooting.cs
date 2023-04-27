using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;

    private float timer;
    private GameObject Emu;

    public float attackDamge = 10;
    public float force = 5;
    public float range = 10;
    // Start is called before the first frame update
    void Start()
    {
        ///Emu = GameObject.FindGameObjectWithTag("Emu");
        //centre = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Emu = GameObject.FindGameObjectWithTag("Emu");
        try
        {
            Debug.Log("Tower trying to shoot " + Emu);
            float distance = Vector2.Distance(transform.position, Emu.transform.position);
            if (distance < range)
            {
                Debug.Log("Emu in range of tower");
                if (distance > 2)
                {
                    //Debug.Log(timer);
                    timer += Time.deltaTime;

                    if (timer > 2)
                    {
                        timer = 0;
                        shoot();
                    }
                }
            }
        }
        catch (System.Exception)
        {
            Debug.Log("No emu to hit");
        }
        

        
    }

    void shoot()
    {
        GameObject Bullet = Instantiate(bullet, bulletPos.position, Quaternion.identity);
        //Bullet.AddComponent<bulletScript>();
       // bulletScript bulletScript = Bullet.GetComponent<bulletScript>();
        //bulletScript.force = force;
       // bulletScript.towerDamage = attackDamge;
    }
}
