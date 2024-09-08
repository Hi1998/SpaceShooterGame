using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    /// <summary>
    /// Reference for the Slider object to adjust the slider
    /// </summary>
    public Slider spaceshipHelathBar;

    /// <summary>
    /// Reference to the Health
    /// </summary>
    public Health health;
    // Start is called before the first frame update
    void Start()
    {
        health = FindAnyObjectByType<Health>();
        spaceshipHelathBar = GetComponent<Slider>();
        spaceshipHelathBar.maxValue = health.maxHealth;
        spaceshipHelathBar.value = health.maxHealth;
    }
    
    /// <summary>
    /// Method to create the health initially and update according to the hit of bullets or current health
    /// </summary>
    /// <param name="healthPower"></param>
    public void SetHealth(int healthPower)
    {
        spaceshipHelathBar.value = healthPower;
    }
}
