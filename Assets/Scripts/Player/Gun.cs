using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Gun : MonoBehaviour
{
    private LineRenderer laserLine;
    private EmuTakeDamage damageScript;
    private bool reloading = true;
    private float Capacity;
    public float MaxCapacity;
    public int PlayerNo;
    public int reloadTimer = 2;
    public float HitDamage = 10;
    public float HitRange = 100f;
    public bool ThirdDimensionEnviroment;
    public bool ControllerControls;
    public Transform FirePoint; // the point on the player where the bullet is spawned, we'll need this once we get proper character sprites
    // public float launchVelocity = 700f;
    public Image bulletImage;
    private bool canShoot = true;
    public float recoilTimer = 2;
    private void Start()
    {
        //makes the capacity the amount "MaxCapacity", which can be edited within engine. 
        Capacity = MaxCapacity;
        laserLine = GetComponent<LineRenderer>();
        PlayerNo = (int)Char.GetNumericValue(transform.name[transform.name.Length - 1]);
    }

    void FixedUpdate()
    {
        // checks player number and sends shoot/reload input name accordingly
        switch (PlayerNo)
        {
            case 1:
                if (ControllerControls == false)
                {
                    // GetShootInput("Fire1"); // F to shoot
                    if (Input.GetButton("Fire1") && Capacity != 0)
                    {
                        if (canShoot == true)
                        {
                            StartCoroutine(GetShootRoutine());
                        }
                    }
                    GetReloadInput("Reload1"); // R to reload
                }
                else
                {
                    // GetShootInput("FireController"); // South controller button to shoot
                    if (Input.GetAxis("FireController") != 0 && Capacity != 0)
                    {
                        GetShootInput();
                    }
                    GetReloadInput("ReloadController"); // North controller button to reload
                }
                break;
            case 2: // player 2 settings
                GetShootInput(); // right shift to shoot (REMOVED BUTTON PARAMETER, WILL NOT WORK)
                GetReloadInput("Reload2"); // right ctrl to reload
                break;
        }
    }

    private IEnumerator GetShootRoutine()
    {
        GetShootInput();
        canShoot = false;
        yield return new WaitForSeconds(recoilTimer);
        canShoot = true;
    }

    private void GetReloadInput(string button)
        {
            // If Reload button pressed and the Capacity int from before is 0.
            if (Input.GetButton(button) && Capacity == 0)
            {
                // Sets capacity back to MaxCapacity. UI for Ammo needs to be made. Debug Log for Dev work.
                reloading = true;
                Debug.Log("Player " + PlayerNo + " has reloaded");
                Capacity = MaxCapacity;
                bulletImage.fillAmount = 1;
            }
        }

        private void GetShootInput()
        {
            //when it gets the input button and the int is not 0, it will spawn the projectile - Andrew: TODO comment needs to be updated
            //spawns the projectile and removes 1 from the capacity. Requires rigidbody on Projectile.  - Andrew: TODO comment needs to be updated
            if (ThirdDimensionEnviroment == true)
            {
                RaycastHit hit;
                if (Physics.Raycast(FirePoint.transform.position, FirePoint.transform.right, out hit, HitRange))
                {
                    laserLine.SetPosition(0, hit.point);
                    Debug.Log("I hit " + hit.transform.name);
                    if (hit.transform.tag == "Emu")
                    {
                        damageScript = hit.transform.gameObject.GetComponent<EmuTakeDamage>(); // need an emu script that has public take damage function
                        damageScript.TakeDamge(HitDamage);
                    }
                }
            }
            else
            {
                // casts a ray at game object and if it has the tag "Emu", destroy it
                RaycastHit2D hit2D = Physics2D.Raycast(FirePoint.transform.position, FirePoint.transform.right, HitRange);
                Vector3 temp = hit2D.point;
                if (hit2D)
                {
                    laserLine.SetPosition(0, hit2D.point);

                    Debug.Log("I hit " + hit2D.transform.name);
                    if (hit2D.transform.tag == "Emu")
                    {
                        damageScript = hit2D.transform.gameObject.GetComponent<EmuTakeDamage>();
                        damageScript.TakeDamge(HitDamage);
                    }
                }
                else
                {
                    laserLine.SetPosition(0, FirePoint.transform.position + (FirePoint.transform.right * HitRange));
                }
                Debug.DrawRay(FirePoint.transform.position, FirePoint.transform.right);
            }
        Debug.Log("Player " + PlayerNo + " has shot");
        Capacity--;
        Debug.Log(Capacity);
        bulletImage.fillAmount = Capacity / MaxCapacity;
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
