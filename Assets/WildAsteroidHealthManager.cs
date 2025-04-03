using UnityEngine;

public class WildAsteroidHealthManager : MonoBehaviour
{
    public int maxHealth = 3; // Set the maximum health for wild asteroids
    private HealthSystem healthSystem;

    void Start()
    {
        // Initialize health system
        healthSystem = new HealthSystem(maxHealth);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))  // Assuming "Asteroid" is the player
        {
            // Apply damage to the wild asteroid on collision
            healthSystem.Damage(1);
            Debug.Log("Wild Asteroid took damage! Current Health: " + healthSystem.CurrentHealth);

            // If health is 0, destroy the wild asteroid and reward the player
            if (healthSystem.CurrentHealth <= 0)
            {
                // Give the player health for collecting the asteroid
                // Assuming there's a PlayerHealthManager that handles the player's health
                PlayerHealthManager playerHealthManager = collision.gameObject.GetComponent<PlayerHealthManager>();
                if (playerHealthManager != null)
                {
                    playerHealthManager.GainHealth(1);  // You can adjust the amount of health gained
                    Debug.Log("Player gained health!");
                }

                Destroy(gameObject); // Destroy the wild asteroid
                Debug.Log("Wild Asteroid destroyed!");
            }
        }
    }
}
