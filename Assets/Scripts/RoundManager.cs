using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    [NonReorderable]
    public Round[] rounds;
    public bool roundRunning = true;
    public int currentRound = 0;
    private WaveSpawner waveSpawner;
    public float timeBetweenRounds = 10f;
    float timer;
    // Start is called before the first frame update
    void Awake()
    {
        int temp = 0;
        foreach (Round r in rounds)
        {
            r.roundNumber = temp++;
        }
    }
    private void Start()
    {
        waveSpawner = GetComponent<WaveSpawner>();
        waveSpawner.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (roundRunning == true)
        {
            Debug.Log("Round is running");
            waveSpawner.currentRound = currentRound;
            waveSpawner.enabled = true;
            waveSpawner.emuPrefab = rounds[currentRound].emuType;
            waveSpawner.emuNumber = rounds[currentRound].numberOfEmus;
            waveSpawner.numberOfWaves = rounds[currentRound].numberOfWaves;
        }
        else if (roundRunning == false)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenRounds)
            {
                roundRunning = true;
                waveSpawner.enabled = true;
                currentRound++;
                Debug.Log("Wave spawner should be reactivated on round " + currentRound);
                timer = 0;
            }

        }

    }
}
