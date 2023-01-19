using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class UIMoneyDisplay : MonoBehaviour
{
    int Internalmoney;
    Text Moneydisplay;
    public int StartMoney;
    // Integer's will be used for money


    // Start is called before the first frame update
    void Start()
    {
        Internalmoney = StartMoney;
        Moneydisplay = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Moneydisplay.text = Internalmoney.ToString();
    }
}
