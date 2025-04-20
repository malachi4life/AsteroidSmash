using UnityEngine;

public class PlanetFinder : MonoBehaviour
{
    public Transform pointer; // Assign the arrow/pointer in the Inspector (child of asteroid)
    private Transform nearestPlanet;

    void FixedUpdate()
    {
        if (pointer == null)
        {
            Debug.LogWarning("Pointer reference not set in PlanetFinder!");
            return;
        }

        FindNearestPlanet();

        if (nearestPlanet != null)
        {
            Vector2 direction = (nearestPlanet.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Adjust angle depending on how your pointer sprite is oriented
            pointer.rotation = Quaternion.Euler(0, 0, angle - 90f);

            Debug.DrawLine(transform.position, nearestPlanet.position, Color.green);
        }
    }

    void FindNearestPlanet()
    {
        GameObject[] planets = GameObject.FindGameObjectsWithTag("Planet");

        if (planets.Length == 0)
        {
            nearestPlanet = null;
            return;
        }

        float closestDistance = Mathf.Infinity;
        Transform closestPlanet = null;

        foreach (GameObject planet in planets)
        {
            float distance = Vector2.Distance(transform.position, planet.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestPlanet = planet.transform;
            }
        }

        nearestPlanet = closestPlanet;
    }
}
