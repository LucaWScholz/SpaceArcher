using UnityEngine;

public class CameraUnlock : MonoBehaviour
{
    private void Start()
    {
        UnlockCursor();
    }
    // erklärt sich selber
    private void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}