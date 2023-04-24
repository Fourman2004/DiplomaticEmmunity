using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class FarmHealth : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth;
    public Slider slider;
    public GameObject sliderCanvas;
    public GameObject endText;
    public GameManager gameManager;


    private void Start()
    {
        currentHealth = maxHealth;
        slider.maxValue = currentHealth;
        slider.value = currentHealth;
    }

    public void DamageFarm(int damage)
    {
        currentHealth -= damage;
        slider.value = currentHealth;

        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
            EndGame();
        }
    }

    public void EndGame()
    {
        endText.SetActive(true);
        sliderCanvas.SetActive(false);
        
        // currently stops slider bar and appears text
        //to do :emus stop along with time clock
    }
}
