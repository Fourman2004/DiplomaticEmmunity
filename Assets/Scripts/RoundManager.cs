using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundManager : MonoBehaviour
{
    [NonReorderable]
    public Round[] rounds;
    public bool roundRunning = true;
    public int currentRound = 0;
    private WaveSpawner waveSpawner;
    private Moneymanager moneymanager;
    public float timeBetweenRounds = 10f;
    public GameObject roundBanner;
    public Text roundText;
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
        moneymanager = GetComponent<Moneymanager>();
        waveSpawner.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (currentRound != rounds.Length)
        {
            if (roundRunning == true)
            {
                Debug.Log("Round is running");
                // sends wave spawner parameters to spawn emus
                waveSpawner.currentRound = currentRound;
                waveSpawner.enabled = true;
                waveSpawner.emuPrefab = rounds[currentRound].emuType;
                waveSpawner.emuNumber = rounds[currentRound].numberOfEmus;
                waveSpawner.numberOfWaves = rounds[currentRound].numberOfWaves;
                //sets the round manager to active and changes the text to the round number plus 1
                roundBanner.SetActive(true);
                roundText.text = ("round " + (currentRound + 1));
                timer += Time.deltaTime;
                roundBanner.SetActive(false);
            }
            else if (roundRunning == false)
            {
                // disables wave spawner
                waveSpawner.enabled = false;
                
                // delay set before renabling wave spawner
                timer += Time.deltaTime;
                //for that time sets the round banners to inactive when round is working
                //roundBanner.SetActive(false);
                if (timer >= timeBetweenRounds)
                {
                    roundRunning = true;
                    waveSpawner.enabled = true;
                    currentRound++;
                    moneymanager.Roundcash();
                    Debug.Log("Wave spawner should be reactivated on round " + currentRound);
                    timer = 0;
                }
            }
        }
        else if (currentRound == rounds.Length)
        {
            Debug.Log("no more rounds to run");
            waveSpawner.enabled = false;
        }
    }
}
