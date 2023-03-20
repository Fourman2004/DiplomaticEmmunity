using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class UIMoneyDisplay : MonoBehaviour
{
    public int Internalmoney;
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
        Moneydisplay.text =(Internalmoney.ToString());
    }
    public void emuIncrement()
    {
        Internalmoney = Internalmoney + 10;
        Moneydisplay.text = ("Money :" + Internalmoney);
    }

    // script to remove money for towers and if not enough money then it does not purchase the towers
    public void towerDecrement(int price)
    {
        Internalmoney = Internalmoney - price;
        if (Internalmoney >= 0)
        {
            Moneydisplay.text = ("Money :" + Internalmoney);
        }
        else
        {
            Internalmoney = Internalmoney + price;
            Debug.Log("Not enough money");
        }
    }

    //script to add money for the govenrment given round - might merge this and the emu increment if it ends up being the same by just getting it to pass in a value
    public void roundIncrement()
    {
        Internalmoney = Internalmoney + 100;
        Moneydisplay.text = ("Money :" + Internalmoney);
    }
}
