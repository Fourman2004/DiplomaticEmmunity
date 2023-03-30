using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneymanager : MonoBehaviour
{
    // Start is called before the first frame update
    public int startCash;
    public int currentCash;
    public int roundCash;
    //public int emuDeathCash;
    public TimerScript tim;
    void Start()
    {
        currentCash += startCash;
    }

    // Update is called once per frame
    void Update()
    {
        Roundcash();
    }

    public void Roundcash()
    {
        if (tim.seconds == 0 && tim.minutes != 0)
        {
            currentCash += roundCash;
            Debug.Log(currentCash);
        }
    }
    
}
