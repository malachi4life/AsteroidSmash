using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    // Public variable for health
    public int currentHealth = 10;
    public int maxHealth = 10;

    // Property to access current health
    public int CurrentHealth => currentHealth; // This will expose currentHealth as a property

    // Method to take damage
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        Debug.Log("Health: " + currentHealth);
    }

    // Method to gain health
    public void GainHealth(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        Debug.Log("Health: " + currentHealth);
    }

    // Check if the entity is dead
    public bool IsDead()
    {
        return currentHealth <= 0;
    }
}
