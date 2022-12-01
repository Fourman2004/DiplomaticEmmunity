using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class launchProjectile : MonoBehaviour
{
    public GameObject projectile;
    public float launchVelocity = 700f;
    public float count = 0f;
    GameObject ball;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space") && count < 5)
        {
            GameObject ball = Instantiate(projectile, transform.position, transform.rotation);
            ball.GetComponent<Rigidbody>().AddRelativeForce(new Vector2(1, launchVelocity));
            count += 1;
        }

    }
}
