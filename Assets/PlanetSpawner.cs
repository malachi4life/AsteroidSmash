using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawner : MonoBehaviour
{
    public GameObject planetPrefab;
    public GameObject sun;  // The Sun object
    public int maxPlanets = 8;  // Number of planets to spawn
    public float minDistance = 50f;  // Closest orbit to the sun
    public float maxDistance = 250f; // Farthest orbit from the sun
    public float orbitVariation = 5f; // Random offset for more natural spacing

    private List<Vector2> planetPositions = new List<Vector2>();

    void Start()
    {
        SpawnPlanets();
    }

    void SpawnPlanets()
    {
        float currentDistance = minDistance;

        for (int i = 0; i < maxPlanets; i++)
        {
            // Get a random angle for the planet's orbit
            float angle = Random.Range(0f, 360f);
            Vector2 spawnPosition = GetOrbitPosition(angle, currentDistance);

            GameObject newPlanet = Instantiate(planetPrefab, spawnPosition, Quaternion.identity);
            planetPositions.Add(spawnPosition);

            // Adjust distance for the next planet (with variation)
            currentDistance += Random.Range(orbitVariation, (maxDistance - minDistance) / maxPlanets);
        }
    }

    Vector2 GetOrbitPosition(float angle, float distance)
    {
        float radians = angle * Mathf.Deg2Rad;
        Vector2 sunPosition = sun.transform.position;

        return new Vector2(
            sunPosition.x + Mathf.Cos(radians) * distance,
            sunPosition.y + Mathf.Sin(radians) * distance
        );
    }
}
