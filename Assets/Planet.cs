using UnityEngine;

public class Planet : MonoBehaviour
{
    public int health = 3;
    public float requiredSpeed = 5f;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            float speed = rb.linearVelocity.magnitude;

            if (speed >= requiredSpeed)
            {
                Destroy(gameObject); // Destroy planet
                rb.linearVelocity *= 0.7f; // Slow asteroid down
            }
            else
            {
                rb.linearVelocity *= -0.5f; // Bounce off
                health--;
                if (health <= 0)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}

