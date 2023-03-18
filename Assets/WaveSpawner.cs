using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform emuPrefab;

    public float timeBetweenWaves = 5f;
    private float countdown = 5f;

    public int waveNumber = 3;
    public float timeBetweenEmuSpawn = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime;
    }
    IEnumerator SpawnWave()
    {
        Debug.Log("Wave Incoming!");
        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEmu();
            yield return new WaitForSeconds(timeBetweenEmuSpawn);
        }
    }

    private void SpawnEmu()
    {
        Instantiate(emuPrefab);
    }
}
