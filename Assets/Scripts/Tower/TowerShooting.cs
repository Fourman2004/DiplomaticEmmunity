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

    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
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
        GameObject Bullet = Instantiate(bullet, bulletPos.position, Quaternion.identity);
        AudioClip shootClip = GameObject.Find("Game Manager").GetComponent<AudioManager>().turretShoot;
        GameObject.Find("Game Manager").GetComponent<AudioManager>().audioSource.PlayOneShot(shootClip);
        bulletScript bulletScript = Bullet.GetComponent<bulletScript>();
        bulletScript.Emu = target.gameObject;
        bulletScript.force = force;
        bulletScript.towerDamage = attackDamge;
    }

    // draws a sphere around the tower representing its range in the editor
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
