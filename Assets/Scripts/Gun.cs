using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject projectile;
    public float launchVelocity = 700f;
    public int MaxCapacity;
    int Capacity;
    // Start is called before the first frame update
    private void Start()
    {
        //makes the capacity the amount "Maxcapacity", which can be edited within engine. 
        Capacity = MaxCapacity;
    }
    // Update is called once per frame
    void Update()
    {
        //when it gets Fire1(Mouse 1) and The int is not 0, it will spawn the projectile
        if (Input.GetButtonDown("Fire1") && Capacity != 0)
        {
            //spawns the projectile and removes 1 from the capacity. Requires rigidbody on Projectile.
            GameObject ball = Instantiate(projectile, transform.position, transform.rotation);
            ball.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(launchVelocity, 0, 0));
            Capacity--;
        }
        //if Reload (needs to be added to input manager) and the Capacity int from before is 0.
        //if (Input.GetButtonDown("Reload") && Capacity == 0)
        //{
        //    //sets capacity back to Maxcapacity. UI for Ammo needs to be made. Debug Log for Dev work.
        //    Debug.Log("reloaded");
        //    Capacity = MaxCapacity;
        //}
    }
}
