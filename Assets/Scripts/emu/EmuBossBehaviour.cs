using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmuBossBehaviour : MonoBehaviour
{
    public GameObject egg;
    private Vector2 eggPos;

    private float timer;
    private GameObject crop;

    public int attackDamge = 10;
    public float force = 5;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        crop = GameObject.FindGameObjectWithTag("Wall");
        try
        {
            float distance = Vector2.Distance(transform.position, crop.transform.position);
            //Debug.Log(distance);
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
        catch (System.Exception)
        {
            Debug.Log("No crop to hit");
        }



    }

    void shoot()
    {
        eggPos = transform.position;
        GameObject Egg = Instantiate(egg, eggPos, Quaternion.identity);
        Debug.Log(eggPos);
        Egg.AddComponent<eggScript>();
        eggScript eggScript = Egg.GetComponent<eggScript>();
        eggScript.force = force;
        eggScript.eggDamage = attackDamge;
    }
}
