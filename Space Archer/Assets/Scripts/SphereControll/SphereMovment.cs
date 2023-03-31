using UnityEngine;

public class SphereMovment : MonoBehaviour
{
    public float maxHeight = 1.0f; // maximale Höhe der Bewegung
    public float minHeight = -1.0f; // minimale Höhe der Bewegung
    public float speed = 1.0f; // Geschwindigkeit der Bewegung

    private Vector3[] originalVertices; // Array mit den ursprünglichen Vertices des Meshes
    private Mesh mesh; // das Mesh, das bewegt wird

    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh; // das Mesh des Objekts holen
        originalVertices = mesh.vertices; // die ursprünglichen Vertices des Meshes speichern
    }

    void Update()
    {
        Vector3[] vertices = new Vector3[originalVertices.Length]; // Array für die neuen Vertices

        for (int i = 0; i < vertices.Length; i++)
        {
            Vector3 vertex = transform.TransformPoint(originalVertices[i]); // die Position des aktuellen Vertex im Weltkoordinatensystem holen
            vertex += transform.up * Mathf.Sin(Time.time * speed + i) * (maxHeight - minHeight) / 2.0f; // die neue Höhe des Vertex berechnen
            vertex = transform.InverseTransformPoint(vertex); // die Position des Vertex wieder in das lokale Koordinatensystem des Objekts umrechnen
            vertices[i] = vertex; // den neuen Vertex im Array speichern
        }

        mesh.vertices = vertices; // das Mesh mit den neuen Vertices aktualisieren
        mesh.RecalculateNormals(); // die Normals des Meshes neu berechnen, um eine glatte Oberfläche zu erhalten
    }
}