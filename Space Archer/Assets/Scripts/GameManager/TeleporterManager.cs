using UnityEngine;

public class TeleporterManager : MonoBehaviour
{
    public int targetsToDestroy = 3; // Anzahl der Ziele, die zerst�rt werden m�ssen, um den Teleporter zu aktivieren
    public GameObject teleporter; // Referenz auf das GameObject des Teleporters

    private int destroyedTargets = 0; // Z�hler f�r zerst�rte Ziele

    void Start()
    {
        teleporter.SetActive(false); // Deaktiviert den Teleporter beim Start des Spiels
    }

    // Wird aufgerufen, wenn ein Ziel zerst�rt wurde
    public void TargetDestroyed()
    {
        destroyedTargets++; // Erh�ht der Anzahl der zerst�rten Targets

        // Aktiviert den Teleporter, wenn genug Ziele zerst�rt wurden
        if (destroyedTargets >= targetsToDestroy)
        {
            teleporter.SetActive(true);
        }
    }
}