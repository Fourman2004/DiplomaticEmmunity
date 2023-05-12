using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSupportShooting : MonoBehaviour
{
    public Transform bulletPos;
    public GameObject Target;

    public float delay, heal, range;

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
            if(Target != null && towerDistance < range)
            {

            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
