using UnityEngine;

public class TeleporterManager : MonoBehaviour
{
    public int targetsToDestroy = 3; // Anzahl der Ziele, die zerstört werden müssen, um den Teleporter zu aktivieren
    public GameObject teleporter; // Referenz auf das GameObject des Teleporters

    private int destroyedTargets = 0; // Zähler für zerstörte Ziele

    void Start()
    {
        teleporter.SetActive(false); // Deaktiviert den Teleporter beim Start des Spiels
    }

    // Wird aufgerufen, wenn ein Ziel zerstört wurde
    public void TargetDestroyed()
    {
        destroyedTargets++; // Erhöht der Anzahl der zerstörten Targets

        // Aktiviert den Teleporter, wenn genug Ziele zerstört wurden
        if (destroyedTargets >= targetsToDestroy)
        {
            teleporter.SetActive(true);
        }
    }
}