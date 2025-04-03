using UnityEngine;

public class WildAsteroidMovement : MonoBehaviour
{
    public float speed = 2f;
    public Vector2 direction;

    void Start()
    {
        direction = Random.insideUnitCircle.normalized; // Random movement direction
    }

    void Update()
    {
        transform.position += (Vector3)direction * speed * Time.deltaTime;
    }
}
