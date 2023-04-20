using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LazerFire : MonoBehaviour
{
    public GameObject lazerpoint;
    private LineRenderer laserLine;
    private EmuTakeDamage damageScript;
    public Transform firePoint;
    private GameObject emu;
    // Start is called before the first frame update
    void Start()
    {
        emu = GameObject.FindGameObjectWithTag("Emu");
    }

    // Update is called once per frame
    void Update()
    {
        if (emu == null) {
            emu = GameObject.FindGameObjectWithTag("Emu");
            Console.WriteLine("emu not found");
        }
        else {
            LazerShoot();
            Console.WriteLine("emu found");
        }
        emu = GameObject.FindGameObjectWithTag("Emu");
    }

    public void LazerShoot() {
        // raycasting to hit the emu

        RaycastHit hit;

        // delay cooldown
            
        StartCoroutine(LaserCountdown());
    }
    IEnumerator LaserCountdown()
    {
        yield return new WaitForSeconds(0.2f);
        laserLine.enabled = false;
    }
}
