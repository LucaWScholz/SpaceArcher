using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Bibliothek für das Laden von Szenen
using TMPro; // Bibliothek für TextMeshPro

public class TeleportPlayer : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Referenz auf das TextMeshProUGUI-Objekt, das die Highscore-Anzeige darstellt

    private void Start()
    {
        UpdateScoreText(); // Aktualisiere die Highscore-Anzeige
        HighscoreManager.Instance.IncrementHighscore(); // Erhöhe den Highscore
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Teleport"))
        {
            RestartScene(); // Ruft Methode auf, um die Scene neu zu starten.
        }
    }

    private void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Lade die aktuelle Szene erneut
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Highscore: " + HighscoreManager.Instance.GetHighscore().ToString(); // Aktualisiere den Highscore-Text
    }
}