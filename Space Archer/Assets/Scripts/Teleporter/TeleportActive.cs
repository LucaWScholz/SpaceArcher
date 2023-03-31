using UnityEngine;

public class TeleportActive : MonoBehaviour
{
    public void OnTargetsDestroyed()
    {
        // Code zum Aktivieren des Teleporters
        gameObject.SetActive(true);
    }
}