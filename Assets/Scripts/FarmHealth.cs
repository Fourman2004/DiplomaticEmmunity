using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FarmHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100;
    [SerializeField] private float currentHealth = 0;
    public Slider slider;
    public GameObject sliderCanvas;
    public GameObject endText;
    private void Start()
    {
        currentHealth = maxHealth;
    }
    public void setMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
    public void DammageFarm(int damage) {
        currentHealth -= damage;
        SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            EndGame();
        }
    }
    public void SetHealth(float health)
    {
        slider.value = health;
    }

    public void EndGame() {
        endText.SetActive(true);
        sliderCanvas.SetActive(false);
        // currently stops slider bar and appears text
        //to do :emus stop along with time clock
    }


}
