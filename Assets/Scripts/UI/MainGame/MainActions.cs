using UnityEngine;
using UnityEngine.SceneManagement;

public class MainActions : MonoBehaviour
{
    // ===========================================================
    // Public Methods
    // ===========================================================

    public void NavigateToStats()
    {
        SceneManager.LoadScene(Scenes.STATS_SCENE);
    }

    public void NavigateToSettings()
    {
        SceneManager.LoadScene(Scenes.SETTINGS_SCENE);
    }
}