using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject targetPrefab; // Das Ziel-Prefab
    public Transform sphereTransform; // Die Transform-Komponente der Kugel
    public float minHeight; // Die minimale H�he, ab der Targets spawnen sollen

    private float sphereRadius;

    void Start()
    {
        sphereRadius = 50.0f;

        // Spawnt 3 Targets am Anfang
        for (int i = 0; i < 3; i++)
        {
            SpawnRandomTarget();
        }
    }

    public void SpawnRandomTarget()
    {
        Vector3 spawnPosition = GetRandomPosition();
        GameObject spawnedTarget = Instantiate(targetPrefab, spawnPosition, Quaternion.identity); // Erstellt das Ziel an der berechneten Position
    }

    public Vector3 GetRandomPosition()
    {
        Vector3 randomDirection = Random.insideUnitSphere * sphereRadius; // Generiert eine zuf�llige Position innerhalb der Kugel
        Vector3 spawnPosition = sphereTransform.position + randomDirection; // Addiert die zuf�llige Position zur Position der Kugel

        // �berpr�ft, ob die H�he (Y-Position) unter der minHeight liegt
        spawnPosition.y = spawnPosition.y += 50f;
        // Die Targets sollen am Start nicht sofort im schwarzen Loch spawnen
        if (spawnPosition.y < minHeight)
        {
            // Ruft die Methode f�r eine neu Positionierung auf
            GetRandomPosition();
        }

        return spawnPosition;
    }
}