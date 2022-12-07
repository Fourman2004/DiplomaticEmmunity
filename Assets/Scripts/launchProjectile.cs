using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class launchProjectile : MonoBehaviour
{
    public GameObject projectile;
    public float launchVelocity = 700f;
    public float launchAngle = 0f;
    public int reloadTimer = 2;
    GameObject ball;

    public bool reloading;

    // Update is called once per frame
    void Update()
    {
        // If the space bar is pressed and the reloading countdown has finished
        if (Input.GetKeyDown("space") && reloading == false)
        {
            //spawns in the object using a vector2, which works on the X/Y axis.
            GameObject ball = Instantiate(projectile, transform.position, transform.rotation);
            ball.GetComponent<Rigidbody>().AddRelativeForce(new Vector2(launchAngle, launchVelocity));

            //Prevents another projectile from being created
            reloading = true;

            //Runs the coroutine "Countdown"
            StartCoroutine(Countdown());
        }
    }


    IEnumerator Countdown()
    {
        //Creates a delay for "reloadTimer" seconds (currently 2 seconds)
        yield return new WaitForSeconds(reloadTimer);

        //allows for another projectile to be created, since the timer is finished
        reloading = false;
    }
}
