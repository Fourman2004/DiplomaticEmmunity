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

    }

    public void Roundcash()
    {
        currentCash = currentCash + roundCash;
    }
    public void EmuCash(int cashEarned)
    {
        currentCash = currentCash + cashEarned;
    }
    public void TowerBought(int cost)
    {
        currentCash = currentCash - cost;
        Debug.Log("a tower has been bought");
    }
}
