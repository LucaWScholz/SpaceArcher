using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Prüfen Sie, ob das kollidierte Objekt den richtigen Tag hat
        if (other.CompareTag("Border"))
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        // Ladet die GameOver Scene.
        SceneManager.LoadScene("GameOver");
    }
}