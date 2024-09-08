using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    /// <summary>
    /// Current Health of the Spaceship after any bullets hits the spaceship.
    /// </summary>
    public int currentHealth = 0;


    /// <summary>
    /// Maximum Health of the Spaceship
    /// </summary>
    public int maxHealth = 100;

    /// <summary>
    /// Reference to the HealthBard
    /// </summary>
    public PlayerHealthBar playerHealthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void DamageSpaceShip(int damage)
    {
        currentHealth -= damage;
        playerHealthBar.SetHealth(currentHealth);
    }
}
