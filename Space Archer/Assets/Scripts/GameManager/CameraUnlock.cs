using UnityEngine;

public class CameraUnlock : MonoBehaviour
{
    private void Start()
    {
        UnlockCursor();
    }
    // erkl�rt sich selber
    private void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}