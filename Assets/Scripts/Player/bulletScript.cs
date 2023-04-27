using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public GameObject Emu;
    private Rigidbody2D rb;
    public float force;
    private float timer;
    private EmuTakeDamage damageScript;
    public int pierce;
    public float towerDamage = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //Emu = GameObject.FindGameObjectWithTag("Emu");

        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
        pierce = 1;
    }

    // Update is called once per frame
    void Update()
    {
        timer =+ Time.deltaTime;

        if(timer > 10)
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
            Debug.Log("A tower hit an emu");
            damageScript = other.transform.gameObject.GetComponent<EmuTakeDamage>();
            damageScript.TakeDamge(towerDamage);
            pierce -= 1;
        }
        
    }
}
