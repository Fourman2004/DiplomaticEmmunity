using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyDisplay : MonoBehaviour
{
    public Text Money;
    public Moneymanager Moneymanager;
    // Start is called before the first frame update
    void Start()
    {
        Money = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Money.text = "Money:" + Moneymanager.currentCash;
    }
}
