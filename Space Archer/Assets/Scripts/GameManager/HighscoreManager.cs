using UnityEngine;

public class HighscoreManager : MonoBehaviour
{
    public static HighscoreManager Instance;

    private int score;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ResetHighscore()
    {
        score = 0;
        PlayerPrefs.SetInt("Highscore", score);
        PlayerPrefs.Save();
    }

    public void IncrementHighscore()
    {
        score++;
        PlayerPrefs.SetInt("Highscore", score);
        PlayerPrefs.Save();
    }

    public int GetHighscore()
    {
        return score;
    }
}