using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] private float damage = 10f;
    [SerializeField] private float pierce = 1f;
    [SerializeField] private float force = 5f;
    private EmuTakeDamage damageScript;
    private float timer;
    private Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
    }

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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Emu"))
        {
            Debug.Log("Player hit an emu");
            damageScript = other.transform.gameObject.GetComponent<EmuTakeDamage>();
            damageScript.TakeDamge(damage);
            pierce -= 1;
        }

    }
}
