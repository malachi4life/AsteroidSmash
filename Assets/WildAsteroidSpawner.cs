using UnityEngine;

public class WildAsteroidSpawner : MonoBehaviour
{
    public GameObject wildAsteroidPrefab;  // Assign in Inspector
    public int maxAsteroids = 10;
    public float spawnRadius = 50f;
    public float minDistance = 10f;

    void Start()
    {
        SpawnAsteroids();
    }

    void SpawnAsteroids()
    {
        for (int i = 0; i < maxAsteroids; i++)
        {
            Vector2 spawnPosition = GetRandomPosition();
            Instantiate(wildAsteroidPrefab, spawnPosition, Quaternion.identity);
        }
    }

    Vector2 GetRandomPosition()
    {
        Vector2 spawnPos;
        int attempts = 0;

        do
        {
            spawnPos = (Vector2)transform.position + Random.insideUnitCircle * spawnRadius;
            attempts++;
        }
        while (IsTooCloseToOtherObjects(spawnPos) && attempts < 10);

        return spawnPos;
    }

    bool IsTooCloseToOtherObjects(Vector2 position)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, minDistance);
        return colliders.Length > 0;
    }
}
