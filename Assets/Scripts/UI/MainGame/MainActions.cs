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
}