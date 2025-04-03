using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    public float acceleration = 2f;  // Speed increase per input
    public float maxSpeed = 5f;      // The max movement speed
    public float friction = 0.98f;   // Slowdown when no input
    private Rigidbody2D rb;
    private Vector2 moveDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get movement input
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        // Normalize movement direction
        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    void FixedUpdate()
    {
        // Apply acceleration while staying under max speed
        if (moveDirection != Vector2.zero)
        {
            rb.linearVelocity += moveDirection * acceleration * Time.fixedDeltaTime;
            rb.linearVelocity = Vector2.ClampMagnitude(rb.linearVelocity, maxSpeed);
        }
        else
        {
            // Apply friction when no input is given
            rb.linearVelocity *= friction;
        }
    }
}
