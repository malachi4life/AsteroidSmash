using UnityEngine;

public class PlanetFinder : MonoBehaviour
{
    public Transform player; // Assign the player in the Inspector
    private Transform nearestPlanet;

    void Update()
    {
        FindNearestPlanet();  // Find the nearest planet each frame

        if (nearestPlanet != null)
        {
            Vector2 direction = (nearestPlanet.position - player.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);  // Rotate arrow to face the planet
        }
    }

    void FindNearestPlanet()
    {
        // Find all GameObjects with the "Planet" tag (which we will assign when we instantiate them)
        GameObject[] planets = GameObject.FindGameObjectsWithTag("Planet");

        // If no planets are found, skip the rotation
        if (planets.Length == 0)
        {
            nearestPlanet = null;
            return;
        }

        float closestDistance = Mathf.Infinity;
        Transform closestPlanet = null;

        foreach (GameObject planet in planets)
        {
            // Find the distance to the player
            float distance = Vector2.Distance(player.position, planet.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestPlanet = planet.transform;  // Set the closest planet
            }
        }

        if (closestPlanet != null)
        {
            nearestPlanet = closestPlanet;  // Assign the closest planet
        }
    }
}
