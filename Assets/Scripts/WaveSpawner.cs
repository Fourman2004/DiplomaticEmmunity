using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Wave[] waves;
    public static int emusAlive = 0;
    public GameObject emuPrefab;
    private RoundManager roundManager;
    public Transform[] spawnPoints;

    public float timeBetweenWaves = 5f;
    private float countdown = 5f;

    public int emuNumber = 3;
    public int numberOfWaves = 5;
    private int currentWave = 0;
    public float timeBetweenEmuSpawn = 0.5f;
    public int currentRound = -1;
    private void Start()
    {
        roundManager = GetComponent<RoundManager>();
    }
    // Update is called once per frame
    void Update()
    {
        // countdown before a new round starts
        if (countdown <= 0f && numberOfWaves != currentWave)
        {
            StartCoroutine(SpawnWave());
            currentWave++;
            countdown = timeBetweenWaves;
        }
        // ends the round when all emus have spawned
        else if (numberOfWaves == currentWave)
        {
            roundManager.roundRunning = false;
            this.enabled = false;
        }
        
        countdown -= Time.deltaTime;
    }

    // spawns waves
    IEnumerator SpawnWave()
    {
        Debug.Log("Wave Incoming!");
        for (int i = 0; i < emuNumber; i++)
        {
            SpawnEmu();
            yield return new WaitForSeconds(timeBetweenEmuSpawn);
        }
    }

    // Spawns an emu at a random spawn point
    private void SpawnEmu()
    {
        int spawnIndex = UnityEngine.Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[spawnIndex];

        Instantiate(emuPrefab, spawnPoint.position, spawnPoint.rotation);
        emusAlive++;
    }
}
