using UnityEngine;

public class PlanetHealthManager : MonoBehaviour
{
    private HealthSystem healthSystem;

    void Start()
    {
        // Get the HealthSystem component attached to the Planet
        healthSystem = GetComponent<HealthSystem>();

        if (healthSystem == null)
        {
            Debug.LogError("HealthSystem component not found on Planet.");
        }
    }

    // Method to apply damage to the planet
    public void TakeDamage(int damage)
    {
        if (healthSystem != null)
        {
            healthSystem.TakeDamage(damage); // Apply damage using the HealthSystem

            if (healthSystem.IsDead())
            {
                // Handle the planet's destruction
                Debug.Log("Planet has been destroyed.");
                Destroy(gameObject); // Destroy the planet GameObject
            }
        }
    }

    // Method to heal the planet (if needed)
    public void Heal(int health)
    {
        if (healthSystem != null)
        {
            healthSystem.GainHealth(health); // Heal the planet using the HealthSystem
        }
    }

    // Handle collision with objects (such as the player asteroid)
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Asteroid"))
        {
            // Example: Damage the planet when colliding with the asteroid
            TakeDamage(10); // Adjust damage value as needed
        }
    }
}
