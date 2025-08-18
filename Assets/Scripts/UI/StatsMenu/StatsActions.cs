using UnityEngine;
using UnityEngine.SceneManagement;

public class StatsActions : MonoBehaviour
{
    // ===========================================================
    // Public Methods
    // ===========================================================

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(Scenes.MAIN_SCENE);
    }
}
