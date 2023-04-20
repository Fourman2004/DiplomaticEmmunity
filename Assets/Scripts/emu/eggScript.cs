using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eggScript : MonoBehaviour
{
    private GameObject crop;
    private Rigidbody2D rb;
    public float force = 5;
    private float timer;
    private FarmHealth damageScript;
    public int pierce;
    public int eggDamage = 10;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        crop = GameObject.FindGameObjectWithTag("Wall");

        Vector3 direction = crop.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
        pierce = 1;
    }

    // Update is called once per frame
    void Update()
    {
        timer = +Time.deltaTime;

        if (timer > 10)
        {
            Destroy(gameObject);
        }
        if (pierce == 0)
        {
            Destroy(this.gameObject);
        }

    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            damageScript = other.transform.gameObject.GetComponent<FarmHealth>();
            damageScript.DamageFarm(eggDamage);
            pierce -= 1;
            Destroy(this.gameObject);
        }

    }
}
