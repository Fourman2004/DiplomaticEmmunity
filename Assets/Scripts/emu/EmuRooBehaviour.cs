using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmuRooBehaviour : MonoBehaviour
{
    public int emuDamage;
    //creating an instance of the Wallhealth script
    public float cooldown;
    float timer;
    float lastHit;
    private Collider2D collider;
    public GameObject feet;
    public float range = 10f;
    private List<GameObject> towers = new List<GameObject>();
    private GameObject targetTower;
    public float speed = 1;
    private GameObject obj;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        collider= GetComponent<Collider2D>();
        obj = this.gameObject;
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] temp = GameObject.FindGameObjectsWithTag("Tower");
        for (int i = 0; i < temp.Length; i++)
        {
            towers.Add(temp[i]);
        }
        TargetTower();
        timer += Time.deltaTime;
        if (timer > cooldown)
        {
            KickAttack();
        }
    }
    private void KickAttack()
    {
        RaycastHit2D hit2D = Physics2D.Raycast(feet.transform.position, new Vector2(0,-1), range);
        if (hit2D)
        {
            Debug.Log("EmuRoo hit " + hit2D.transform.name);
            if (hit2D.transform.tag == "Player")
            {
                PlayerHealth damageScript = hit2D.transform.gameObject.GetComponent<PlayerHealth>();
                damageScript.TakeDamage(emuDamage);
            }
            //else if (hit2D.transform.tag == "Wall")
            //{
            //    FarmHealth damageScript = hit2D.transform.gameObject.GetComponent<FarmHealth>();
            //    damageScript.DamageFarm(emuDamage);
            //}
            else if (hit2D.transform.name == targetTower.name)
            {
                StartCoroutine(DelayTowerDestroy());
                GameObject tower = hit2D.transform.gameObject;
                Debug.Log(tower.name);
                towers.Remove(tower);
                Destroy(tower);

            }
            timer = 0;
            Debug.DrawRay(feet.transform.position, feet.transform.right);
        }
    }

    private IEnumerator DelayTowerDestroy()
    {
        yield return new WaitForSeconds(cooldown);
    }

    void TargetTower()
    {
        try
        {
            if (targetTower == null)
            {
                int randomTowerIndex = UnityEngine.Random.Range(0, towers.Count);
                targetTower = towers[randomTowerIndex];
            }
            Vector2 actualPosition2D = (Vector2)this.transform.position;
            this.transform.position = Vector2.MoveTowards(actualPosition2D, targetTower.transform.position, speed * Time.deltaTime);
            Debug.Log(targetTower.name);
        }
        catch (System.ArgumentOutOfRangeException)
        {
            Debug.Log("no towers to attack");
            ChasePlayer();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ignores colliding with other emus
        if (collision.gameObject.tag == "Emu")
        {
            Physics2D.IgnoreCollision(collision.collider, collider);
        }
        //else if (collision.gameObject.tag == "Tower Spot")
        //{
        //    Physics2D.IgnoreCollision(collision.collider, collider);
        //}
    }
    void ChasePlayer()
    {

        Vector2 actualPosition2D = (Vector2)obj.transform.position;
        obj.transform.position = Vector2.MoveTowards(actualPosition2D, player.transform.position, speed * Time.deltaTime);
        Debug.Log("EmuRoo move to player");
    }
}
