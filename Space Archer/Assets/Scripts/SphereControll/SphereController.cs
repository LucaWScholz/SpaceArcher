
using UnityEngine;

public class SphereController : MonoBehaviour
{
    public float maxHeight = 1.0f; // maximale Höhe der Ecken
    public float minHeight = -1.0f; // minimale Höhe der Ecken
    public float speed = 1.0f; // Geschwindigkeit der Bewegung

    private Vector3[] originalVertices; // Original-Ecken der Kugel
    private Mesh mesh; // Mesh-Komponente der Kugel

    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh; // Zugriff auf Mesh-Komponente der Kugel
        originalVertices = mesh.vertices; // Speichern der Original-Ecken der Kugel
    }

    void Update()
    {
        Vector3[] vertices = new Vector3[originalVertices.Length]; // Array zum Speichern der veränderten Ecken

        for (int i = 0; i < vertices.Length; i++)
        {
            Vector3 vertex = transform.TransformPoint(originalVertices[i]); // Transformation der Ecke ins Weltkoordinatensystem
            vertex += transform.up * Mathf.Sin(Time.time * speed + i) * (maxHeight - minHeight) / 2.0f; // Bewegung der Ecke im lokalen Koordinatensystem
            vertex = transform.InverseTransformPoint(vertex); // Transformation der Ecke zurück ins lokale Koordinatensystem
            vertices[i] = vertex;
        }

        mesh.vertices = vertices; // Aktualisieren der Ecken im Mesh
        mesh.RecalculateNormals(); // Neu berechnen der Normalen
    }
}