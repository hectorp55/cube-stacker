using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreActions : MonoBehaviour
{
    // ===========================================================
    // Public Methods
    // ===========================================================

    public void RetryGame()
    {
        SceneManager.LoadScene(Scenes.MAIN_SCENE);
    }
}
