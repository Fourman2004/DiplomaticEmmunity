using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform player;

    public int reloadTimer = 2;

    public float maxCapacity;
    private float currentCapacity;
    [SerializeField] private bool canShoot = true;
    [SerializeField] private bool reloading = false;
    public float shootCooldown = .5f;
    WaitForSeconds shootDelay;

    public bool ControllerControls;
    [Header("UI")]
    [SerializeField] private Text ammoText;

    private void Start()
    {

        shootDelay = new WaitForSeconds(shootCooldown);
        currentCapacity = maxCapacity;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.R) && currentCapacity != maxCapacity)
        {
            StartCoroutine(Reload());
        }

    }
    public void Shoot()
    {
        if (canShoot && !reloading && currentCapacity > 0)
        {
            Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            GameObject currentBullet = Instantiate(bullet, player.position, rotation);
            canShoot = false;
            StartCoroutine(ShootCooldown());

            currentCapacity--;
            ammoText.text = "Ammo: " + currentCapacity + " / " + maxCapacity;
        }
    }
    IEnumerator Reload()
    {
        reloading = true;
        canShoot = false;
        yield return new WaitForSeconds(reloadTimer);
        currentCapacity = maxCapacity;
        ammoText.text = "Ammo: " + currentCapacity + " / " + maxCapacity;
        reloading = false;
        canShoot = true;

    }

    IEnumerator ShootCooldown()
    {
        yield return shootDelay;
        canShoot = true;
    }
}
