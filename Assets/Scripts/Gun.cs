using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject projectile;
    public GameObject projectile2d;
    public float launchVelocity = 700f;
    public int MaxCapacity;
    int Capacity;
    public bool ThirdDimensionEnviroment;
    public Transform FirePoint; // the point on the player where the bullet is spawned, we'll need this once we get proper character sprites
    public int reloadTimer = 2;
    private bool reloading;
    public int playerNo;
    public float shootRange = 100f;
    private LineRenderer laserLine;
    // Start is called before the first frame update

    private void Start()
    {
        //makes the capacity the amount "Maxcapacity", which can be edited within engine. 
        Capacity = MaxCapacity;

        laserLine = GetComponent<LineRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        // checks player number and sends shoot/reload input name accordingly
        switch (playerNo)
        {
            case 1:
                GetShootInput("TestFire2"); // left click to shoot
                GetReloadInput("TestReload1"); // R to reload for player 1
                break;
            case 2:
                GetShootInput("TestFire2"); // left click to shoot for player 2
                GetReloadInput("TestReload2"); // right click to reload for player 2
                break;
            default:
                Debug.LogError("No player number given");
                break;
        }
        
    }
    private void FixedUpdate()
    {

    }

    private void GetReloadInput(string button)
    {
        //if Reload button pressed and the Capacity int from before is 0.
        if (Input.GetButtonDown(button) && Capacity == 0)
        {
            //sets capacity back to Maxcapacity. UI for Ammo needs to be made. Debug Log for Dev work.
            Debug.Log("Player " + playerNo + " has reloaded");
            Capacity = MaxCapacity;
        }
    }

    private void GetShootInput(string button)
    {
        
        //when it gets the input button and the int is not 0, it will spawn the projectile
        if (Input.GetButtonDown(button) && Capacity != 0)
        {
            //spawns the projectile and removes 1 from the capacity. Requires rigidbody on Projectile.
            if (ThirdDimensionEnviroment == true)
            {
                GameObject ball = Instantiate(projectile, FirePoint.position, transform.rotation);
                ball.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(launchVelocity, 0, 0));
            }
            else
            {
                // casts a ray at game object and if it has the tag "Emu", destroy it
                RaycastHit2D hit2D = Physics2D.Raycast(FirePoint.transform.position, FirePoint.transform.right, shootRange);
                if (hit2D)
                {
                    laserLine.SetPosition(0, hit2D.point);
                    
                    Debug.Log("I hit " + hit2D.collider.name);
                    if (hit2D.transform.tag == "Emu")
                    {
                        Destroy(hit2D.transform.gameObject); // need an emu script that has public take damage function
                    }
                }
                else
                {
                    laserLine.SetPosition(0, FirePoint.transform.position + (FirePoint.transform.right * shootRange));
                }
                Debug.DrawRay(FirePoint.transform.position, FirePoint.transform.right);
            }
            Debug.Log("Player " + playerNo + " has shot");
            Capacity--;
        }
        
        StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {
        //Creates a delay for "reloadTimer" seconds (currently 2 seconds)
        yield return new WaitForSeconds(reloadTimer);

        //allows for another projectile to be created, since the timer is finished
        reloading = false;
    }
}
