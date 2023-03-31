using UnityEngine;

public class TargetMover : MonoBehaviour
{
    private Vector3 startPosition; // Ausgangsposition des Targets
    private RandomSpawner randomSpawner;

    void Start()
    {
        randomSpawner = FindObjectOfType<RandomSpawner>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Border")) // Wenn der Trigger des Targets vom Spieler-Objekt betreten wird
        {
            startPosition = transform.position; // Speichere die Ausgangsposition des Targets
            ResetCurrentTarget(); // Setze das Target an eine neue Position
        }
    }

    void ResetCurrentTarget()
    {
        randomSpawner = FindObjectOfType<RandomSpawner>();
        Vector3 newPosition = randomSpawner.GetRandomPosition(); // Ruft Methode aus RandomSpawner auf

        transform.position = newPosition;
    }
}