using UnityEngine;

public class WildAsteroid : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform asteroid; // Reference to the player asteroid
    public float attractionSpeed = 3f;
    private bool attracted = false;
    private bool attached = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        asteroid = GameObject.FindGameObjectWithTag("Asteroid").transform; // Finds the player asteroid
    }

    void Update()
    {
        if (attracted && !attached)
        {
            MoveTowardsAsteroid();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Asteroid") && !attached) // Checks if it's colliding with the player asteroid
        {
            AttachToAsteroid(other.transform);
        }
    }

    public void AttractToAsteroid()
    {
        attracted = true;
    }

    private void MoveTowardsAsteroid()
    {
        Vector2 direction = (asteroid.position - transform.position).normalized;
        rb.linearVelocity = direction * attractionSpeed;
    }

    private void AttachToAsteroid(Transform asteroid)
    {
        attached = true;
        rb.bodyType = RigidbodyType2D.Kinematic; // Stops movement
        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;
        transform.SetParent(asteroid); // Stick to the player's asteroid
    }
}
