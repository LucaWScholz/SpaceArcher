using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistentSceneLoader : MonoBehaviour
{
    // Gibt an, ob die persistent geladene Szene bereits geladen wurde
    private static bool persistentSceneLoaded = false;

    private void Start()
    {
        // Lädt die persistent geladene Szene, wenn sie noch nicht geladen wurde
        if (!persistentSceneLoaded)
        {
            SceneManager.LoadScene("PersistentScene", LoadSceneMode.Additive);
            persistentSceneLoaded = true;
        }
    }
}