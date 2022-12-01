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
        // If the space bar is pressed and the count is less than 5 it will count it as true
        if(Input.GetKeyDown("space") && count < 5)
        {
            //spawns in the object using a vector2, which works on the X/Y axis.
            GameObject ball = Instantiate(projectile, transform.position, transform.rotation);
            ball.GetComponent<Rigidbody>().AddRelativeForce(new Vector2(1, launchVelocity));
            //increases count by 1, when count reaches 5, the if statement is false and can't be activated again, as no method to lower the count is avalible

            count += 1;
        }

    }
}
