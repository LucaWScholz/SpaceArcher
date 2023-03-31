using UnityEngine.Events;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int hitCount = 3;
    private int currentHitCount = 0;

    public UnityEvent onTargetDestroyed; // Das Event, das bei Zerstörung des Ziels ausgelöst wird

    private TeleporterManager teleporterManager; // Referenz zum TeleporterManager

    private void Start()
    {
        teleporterManager = FindObjectOfType<TeleporterManager>(); // Finde den TeleporterManager in der Szene
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LaserBeam"))
        {
            currentHitCount++;

            if (currentHitCount >= hitCount)
            {
                gameObject.SetActive(false);
                onTargetDestroyed.Invoke(); // Löse das onTargetDestroyed-Event aus
                teleporterManager.TargetDestroyed(); // Informiere den TeleporterManager über die Zerstörung des Ziels
            }
        }
    }
}