using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    // Start is called before the first frame update
    // initialises the values for the time incrememnt per second
    // pausestate refers to the condition that if a pause button is added then the timer stops
    public Text textClock;
    float cooldown;
    public int minutes = 0;
    public int seconds = 1;
    public static bool pauseState = false;
    public GameObject canvasClock;
    public GameObject winUI;
    public GameObject lossUI;
    public RoundManager roundManager;
    void Start()
    {
        textClock.text = ("00:00");
        pauseState = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (pauseState == false)
        {
            cooldown += Time.deltaTime;
            if (cooldown > 1)//per second
            {
                cooldown = 0;
                if (seconds >= 60)
                {
                    seconds = 0;
                    minutes++;
                }
                if (seconds < 10)
                {
                    textClock.text = ("0" + minutes + ":0" + seconds);
                }
                else
                {
                    textClock.text = ("0" + minutes + ":" + seconds);
                }
                seconds++;
                checkEnd();
            }
        }
    }

    public string checkEnd() {
        string hasWon = "idk";
        if (GameObject.FindWithTag("Emu")==null && roundManager.currentRound == roundManager.rounds.Length) {
            pauseState = true;
            canvasClock.SetActive(false);
            winUI.SetActive(true);
            hasWon = "won";
        }
        else if (GameObject.FindWithTag("Wall") == null || GameObject.FindGameObjectWithTag("Player") == null)
        {
            pauseState = true;
            canvasClock.SetActive(false);
            lossUI.SetActive(true);
            hasWon = "lose";
        }
        return hasWon;
    }
}
