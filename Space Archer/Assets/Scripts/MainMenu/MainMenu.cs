using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void RestartGame()
    {
        Debug.Log("Level is loading");
        SceneManager.LoadScene("Level");
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void StartGame()
    {
        HighscoreManager.Instance.ResetHighscore();
        SceneManager.LoadScene("Level");
    }
}
