using OpenCover.Framework.Model;
using UnityEngine;


public class CrossbowController : MonoBehaviour
{
    public GameObject arrowPrefab; // Das Prefab des Pfeils
    public Transform spawnPoint; // Der Transform, an dem der Pfeil gespawnt werden soll
    public float shotPower = 0.0005f; // Die Kraft, mit der der Pfeil abgeschossen wird

    // Wird einmal pro Frame aufgerufen
    void Update()
    {
        // Prüft, ob die linke Maustaste gedrückt wurde
        if (Input.GetMouseButtonDown(0))
        {
            
            // Erstellt ein neues Pfeil-Objekt aus dem Prefab an der Position des Spawn-Points
            GameObject arrow = Instantiate(arrowPrefab, spawnPoint.position, spawnPoint.rotation);
            // Fügt eine Kraft in Richtung der Vorwärtsachse des Pfeils hinzu
            arrow.GetComponent<Rigidbody>().AddForce(arrow.transform.forward * shotPower);
            arrow.GetComponent<Rigidbody>().useGravity = false;
        }
    }
}

