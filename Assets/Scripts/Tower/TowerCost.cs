using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerCost : MonoBehaviour
{
    public int cost;
    private Moneymanager moneymanager;
    private bool bought = false;
    // Start is called before the first frame update
    void Start()
    {
        GameObject gameManager = GameObject.Find("Game Manager");
        moneymanager = gameManager.GetComponent<Moneymanager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bought == false)
        {
            Debug.Log("tower bought");
            moneymanager.TowerBought(cost);
            bought = true;
        }
        Debug.Log(bought);
    }
}
