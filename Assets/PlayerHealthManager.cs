using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    // Public variables for health system
    public int currentHealth = 10;  // Starting health
    public int maxHealth = 10;      // Max health limit

    // Public method to gain health
    public void GainHealth(int amount)
    {
        currentHealth += amount;

        // Prevent health from exceeding max health
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        Debug.Log("Player Health: " + currentHealth); // Log for debugging
    }

    // Public method to take damage (if you need to handle damage for the player)
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        // Prevent health from going below 0
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        Debug.Log("Player Health: " + currentHealth); // Log for debugging
    }

    // Method to check if the player is dead (optional)
    public bool IsDead()
    {
        return currentHealth <= 0;
    }
}
