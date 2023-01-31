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
    int minutes = 0;
    int seconds = 1;
    public static bool pauseState = false;
    void Start()
    {
        textClock.text = ("00:00");
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
            }
        }
    }
}
