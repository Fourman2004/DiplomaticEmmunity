using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Wave[] waves; // does nothing for now
    public static int emusAlive = 0;
    public GameObject emuPrefab;
    public RoundManager roundManager;
    public Transform[] spawnPoints;

    public float timeBetweenWaves = 5f;
    private float countdown = 5f;

    public int emuNumber = 3;
    public int numberOfWaves = 5;
    private int currentWave = 0;
    public float timeBetweenEmuSpawn = 0.5f;
    public int currentRound = -1;

    private int temp = 0;
    private void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (roundManager.roundRunning == true)
        {
            if (currentWave != numberOfWaves)
            {
                Debug.Log("Round " + currentRound + " should be running");
                StartCoroutine(SpawnWave());
                currentWave++;
            }
            else
            {
                countdown -= Time.deltaTime;
                StopCoroutine(SpawnWave());
                if (countdown <= 0)
                {
                    roundManager.roundRunning = false;
                    countdown = 5f;
                    currentWave = 0;
                }
            }
        }
    }

    // spawns waves
     public IEnumerator SpawnWave()
    {
        for (int i = 0; i < emuNumber; i++)
        {
            SpawnEmu();
            yield return new WaitForSeconds(timeBetweenEmuSpawn);
        }
        roundManager.roundRunning = true;
        //yield return new WaitForSeconds(roundManager.timeBetweenRounds);
        //StartCoroutine(SpawnWave()); // repeats wave
    }

    // Spawns an emu at a random spawn point
    private void SpawnEmu()
    {
        // randomly chooses a place for the emu to spawn
        int spawnIndex = UnityEngine.Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[spawnIndex];
        var emu = (GameObject) Instantiate(emuPrefab, spawnPoint.position, spawnPoint.rotation);
        emu.name = emuPrefab.name + " " + temp;
        temp++;
        emusAlive++;
    }
}
