using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emuAttack : MonoBehaviour
{
    //[SerializeField] private LayerMask mask;

    private void OnTriggerEnter2D(Collider2D other)
    { 
        if (other.GetComponent<Health>() != null)
        {
            //When the target is hit, 25 health is removed
            other.GetComponent<Health>().Damage(25);
        }
    }
}
