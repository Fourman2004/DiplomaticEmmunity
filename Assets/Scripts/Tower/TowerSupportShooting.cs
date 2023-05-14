using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSupportShooting : MonoBehaviour
{
    public Transform bulletPos;
    public GameObject Target, Projectile;

    public float delay, heal, range, getTime;
    Transform targetLocation;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateSupportShooting", 0, delay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateSupportShooting()
    {
        float towerDistance = Mathf.Infinity;
        GameObject Injured = null;
        float targetDistance = Vector2.Distance(transform.position, Target.transform.position);
        if (targetDistance < towerDistance)
        {
            towerDistance = targetDistance;
            Injured = Target;
            if( Injured != null && towerDistance < range)
            {
                targetLocation = Injured.transform;
                getTime += Time.deltaTime;
                if (getTime > 0.01)
                {
                    getTime = 0;
                    Fire(targetLocation);
                }
            }
        }
    }

    void Fire(Transform targetTrans)
    {
        GameObject Bullet = Instantiate(Projectile, bulletPos.position, Quaternion.identity);
        AudioClip shootClip = GameObject.Find("Game Manager").GetComponent<AudioManager>().turretShoot;
        GameObject.Find("Game Manager").GetComponent<AudioManager>().audioSource.PlayOneShot(shootClip);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
