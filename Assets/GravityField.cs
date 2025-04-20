using UnityEngine;

public class GravityField : MonoBehaviour
{
    [SerializeField] private float gravityStrength = 15f; // Adjustable in Inspector

    void OnTriggerEnter2D(Collider2D other)
{
    if (other.CompareTag("Asteroid")) // Only affect player asteroid
    {
        string parentName = transform.parent != null ? transform.parent.name : "Unknown Parent";
        Debug.Log(other.name + " entered gravity field of: " + parentName);
    }
}


    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Asteroid")) // Ignore WildAsteroid
        {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb == null) return;

            Vector2 direction = (transform.position - other.transform.position).normalized;
            float distance = Vector2.Distance(transform.position, other.transform.position);

            if (distance < 0.1f) return; // Prevent divide-by-zero errors

            // Apply gravity force based on distance
            float gravityEffect = gravityStrength / Mathf.Pow(distance, 1.5f);
            rb.linearVelocity += direction * gravityEffect * Time.deltaTime;

            // **Cap Maximum Speed**
            float maxSpeed = 10f;  // Adjust as needed
            if (rb.linearVelocity.magnitude > maxSpeed)
            {
                rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
            }
        }
    }
}
