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
    private GameObject player;
    private List<GameObject> towers = new List<GameObject>();
    private GameObject targetTower;
    public float speed = 1;
    private int layerMask;
    // Start is called before the first frame update
    void Start()
    {
        // Bit shift the index of the layer (13) to get a bit mask
        layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 13.
        // But instead we want to collide against everything except layer 13. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;

        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] temp = GameObject.FindGameObjectsWithTag("Tower");
        for (int i = 0; i < temp.Length; i++)
        {
            towers.Add(temp[i]);
            Debug.Log("EmuRoo found a tower to attack");
        }
        AttackTower();
        timer += Time.deltaTime;
        if (timer > cooldown)
        {
            KickAttack();
        }
    }
    private void KickAttack()
    {
        RaycastHit2D hit2D = Physics2D.Raycast(feet.transform.position, feet.transform.right, range, layerMask);
        if (hit2D)
        {
            Debug.Log("EmuRoo hit " + hit2D.transform.name);
            if (hit2D.transform.tag == "Player")
            {
                PlayerHealth damageScript = hit2D.transform.gameObject.GetComponent<PlayerHealth>();
                damageScript.TakeDamage(emuDamage);
            }
            else if (hit2D.transform.tag == "Wall")
            {
                FarmHealth damageScript = hit2D.transform.gameObject.GetComponent<FarmHealth>();
                damageScript.DamageFarm(emuDamage);
            }
            else if (hit2D.transform.tag == "Tower")
            {
                Debug.Log("Tower destroyed!");
                GameObject tower = hit2D.transform.gameObject;
                Destroy(tower);
            }
            timer = 0;
            Debug.DrawRay(feet.transform.position, feet.transform.right);
        }
    }
    void AttackTower()
    {
        try
        {
            int randomTowerIndex = UnityEngine.Random.Range(0, towers.Count);
            GameObject tower = towers[randomTowerIndex];
            Vector2 actualPosition2D = (Vector2)this.transform.position;
            this.transform.position = Vector2.MoveTowards(actualPosition2D, tower.transform.position, speed * Time.deltaTime);
            towers.Clear();
            targetTower = tower;
        }
        catch (System.ArgumentOutOfRangeException)
        {
            Debug.Log("no towers to attack");
        }
    }
}
