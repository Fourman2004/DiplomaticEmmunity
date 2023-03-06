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

    public int round;
    void Start()
    {
        isRoundOngoing = false;
        isIntermission = false;
        isStartOfRound = true;

        timeVariable = Time.time + timeBeforeRoundStart;
    }

    // One big loop to constantly change the round state from start to ongoing to intermission.
    void Update()
    {
        if (isStartOfRound)
        {
            if(Time.time >= timeVariable)
            {
                isRoundOngoing = true;
                isStartOfRound =false;
            }
            else if (isIntermission)
            {
                if(Time.time >= timeVariable)
                {
                    isIntermission = false;
                    isRoundOngoing = true;
                }
            }
            else if (isRoundOngoing)
            {
                if (1 > 2)
                {

                }
                else
                {
                    isIntermission = true;
                    isRoundOngoing = false;

                    timeVariable += Time.time + timeBetweenWaves;
                    round++;
                }
            }
        }
    }
}
