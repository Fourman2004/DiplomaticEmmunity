using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundController : MonoBehaviour
{
    public GameObject basicEnemy;
    public float timeBetweenWaves;
    public float timeBeforeRoundStart;
    public float timeVariable;

    public bool isRoundOngoing;
    public bool isIntermission;
    public bool isStartOfRound;
    void Start()
    {
        isRoundOngoing = false;
        isIntermission = false;
        isStartOfRound = true;

        timeVariable = Time.time + timeBeforeRoundStart;
    }

    
    void Update()
    {
        
    }
}
