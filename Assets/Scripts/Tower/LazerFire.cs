using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LazerFire : MonoBehaviour
{
    public Transform bulletPos;

    private float timer;
    private GameObject Emu;
    private EmuTakeDamage damageScript;

    public float attackDamge = 10;
    public float force = 5;
    public float range = 10;

    public Transform target;
    private LineRenderer laserLine;
    // Start is called before the first frame update
    void Start()
    {
        laserLine = GetComponent<LineRenderer>();
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        //Emu = GameObject.FindGameObjectWithTag("Emu");
        //try
        //{
        //    float distance = Vector2.Distance(transform.position, Emu.transform.position);
        //    if (distance < range)
        //    {
        //        Debug.Log("Emu in range of tower");
        //        if (distance > 2)
        //        {
        //            //Debug.Log(timer);
        //            timer += Time.deltaTime;

        //            if (timer > 2)
        //            {
        //                timer = 0;
        //                shoot();
        //            }
        //        }
        //    }
        //}
        //catch (System.Exception)
        //{
        //    Debug.Log("No emu to hit");
        //}

        if (target == null)
        {
            return;
        }

    }
    void UpdateTarget()
    {
        GameObject[] emus = GameObject.FindGameObjectsWithTag("Emu");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject emu in emus)
        {
            float distance = Vector2.Distance(transform.position, emu.transform.position);
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                nearestEnemy = emu;
            }
        }
        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            //Debug.Log(timer);
            timer += Time.deltaTime;

            if (timer > 0.01)
            {
                timer = 0;
                shoot(target);
            }
        }
    }
    void shoot(Transform target)
    {
        laserLine.enabled = true;
        Vector3 temp = target.transform.position  - this.transform.position;
        temp.Normalize();
        LayerMask mask = LayerMask.GetMask("Emu");
        RaycastHit2D hit2D = Physics2D.Raycast(bulletPos.transform.position, temp, range, mask);
        laserLine.SetPosition(0, bulletPos.position); // bullet position
        if (hit2D)
        {
            Debug.Log("Tack Shooter hit " + hit2D.transform.name);
            if (hit2D.transform.tag == "Emu")
            {
                damageScript = hit2D.transform.gameObject.GetComponent<EmuTakeDamage>();
                damageScript.TakeDamge(attackDamge);
                laserLine.SetPosition(1, (Vector3)hit2D.point); // the position of emu
            }
        }
        else
        {
            laserLine.SetPosition(1, target.transform.position /*+ new Vector3(0,0,-1)*/);
        }
        StartCoroutine(LaserCountdown());
    }

    IEnumerator LaserCountdown()
    {
        yield return new WaitForSeconds(0.2f);
        laserLine.enabled = false;
    }
    // draws a sphere around the tower representing its range in the editor
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
