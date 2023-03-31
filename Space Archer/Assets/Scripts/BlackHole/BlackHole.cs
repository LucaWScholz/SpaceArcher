using UnityEngine;

public class BlackHole : MonoBehaviour
{
    public float mass; // Mass des Schwarzen Lochs
    public float growthRate; // Wachstumsrate des Schwarzen Lochs
    public float attractionForce; // Anziehungskraft des Schwarzen Lochs

    private Vector3 originalScale;
    private float originalMass;

    void Start()
    {
        // Speichert die ursprüngliche Skalierung und Masse des Schwarzen Lochs
        originalScale = transform.localScale;
        originalMass = mass;
    }

    void Update()
    {
        // Vergrößert das Schwarze Loch und zieht nahegelegene Objekte an
        Grow();
        AttractNearbyObjects();
    }

    // Vergrößert das Schwarze Loch
    void Grow()
    {
        mass += growthRate * Time.deltaTime;
        float scaleFactor = mass / originalMass;
        transform.localScale = originalScale * scaleFactor;
    }

    // Zieht nahegelegene Objekte an
    void AttractNearbyObjects()
    {
        // Sammelt alle Objekte innerhalb des Radius des Schwarzen Lochs
        Collider[] nearbyObjects = Physics.OverlapSphere(transform.position, mass);
        foreach (Collider nearbyObject in nearbyObjects)
        {
            // Falls das Objekt ein Rigidbody hat, wird es angezogen
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // Berechnet die Richtung und Entfernung zum Schwarzen Loch
                Vector3 direction = transform.position - rb.position;
                float distance = direction.magnitude;
                // Berechnet die Anziehungskraft basierend auf der Masse und Entfernung
                float forceMagnitude = mass * rb.mass * attractionForce / Mathf.Pow(distance, 2);
                Vector3 force = direction.normalized * forceMagnitude;
                // Zieht den Rigidbody an
                rb.AddForce(force);
            }
        }
    }
}