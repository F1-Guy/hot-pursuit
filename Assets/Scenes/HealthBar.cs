using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public void SetHealth(float health)
        {
            GetComponent<RectTransform>().sizeDelta = new Vector2(health, GetComponent<RectTransform>().sizeDelta.y);
        }

    public HealthBar healthBar;

    public Image healthBar;

    // Replace "CalculateHealth()" with a function that calculates the current health value of your player or object.
    private float CalculateHealth()
    {
        // Example: Get current health value from a player or object's health component.
        float currentHealth = GetComponent<Health>().GetCurrentHealth();

        // Return the current health value.
        return currentHealth;
    }

    void Update()
    {
        // Calculate the current health value.
        float currentHealth = CalculateHealth();

        // Update the health bar's fill amount based on the current health value.
        healthBar.fillAmount = currentHealth / 100f;
    }


    
}
