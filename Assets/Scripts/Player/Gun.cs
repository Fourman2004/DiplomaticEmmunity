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
    public Text ammoText;
    private bool canShoot = true;
    public float recoilTimer = 2;
    public GameObject gun;
    private void Start()
    {
        //makes the capacity the amount "MaxCapacity", which can be edited within engine. 
        Capacity = MaxCapacity;
        laserLine = GetComponent<LineRenderer>();
        PlayerNo = (int)Char.GetNumericValue(transform.name[transform.name.Length - 1]);
        ammoText.text = "Ammo: " + Capacity + " / " + MaxCapacity;
        
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
            StartCoroutine(ReloadCountdown());
              //  Debug.Log("Player " + PlayerNo + " has reloaded");
                Capacity = MaxCapacity;
                //bulletImage.fillAmount = 1;
            }
        }

        private void GetShootInput()
        {
        laserLine.enabled = true;
        laserLine.sortingLayerName = "Object";
            //when it gets the input button and the int is not 0, it will spawn the projectile - Andrew: TODO comment needs to be updated
            //spawns the projectile and removes 1 from the capacity. Requires rigidbody on Projectile.  - Andrew: TODO comment needs to be updated
            if (ThirdDimensionEnviroment == true)
            {
                RaycastHit hit;
                if (Physics.Raycast(FirePoint.transform.position, FirePoint.transform.right, out hit, HitRange))
                {
                    laserLine.SetPosition(0, hit.point /*+ new Vector3(0,0,-1)*/);
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
                laserLine.SetPosition(0, gun.transform.position /*+ new Vector3(0, 0, -1)*/);
                if (hit2D)
                {
                    laserLine.SetPosition(1, (Vector3) hit2D.point /*+ new Vector3(0, 0, -1)*/);

                    Debug.Log("I hit " + hit2D.transform.name);
                    if (hit2D.transform.tag == "Emu")
                    {
                        damageScript = hit2D.transform.gameObject.GetComponent<EmuTakeDamage>();
                        damageScript.TakeDamge(HitDamage);
                    }
                }
                else
                {
                    laserLine.SetPosition(1, FirePoint.transform.position /*+ new Vector3(0,0,-1)*/);
                }
            }
        Capacity--;
        ammoText.text = "Ammo: " + Capacity + " / " + MaxCapacity;
        StartCoroutine(LaserCountdown());
        }

    IEnumerator LaserCountdown()
    {
        yield return new WaitForSeconds(0.2f);
        laserLine.enabled = false;
    }

    IEnumerator ReloadCountdown()
        {
            //Creates a delay for "reloadTimer" seconds (currently 2 seconds)
            yield return new WaitForSeconds(reloadTimer);

            //allows for another projectile to be created, since the timer is finished
            reloading = false;
        }
}
