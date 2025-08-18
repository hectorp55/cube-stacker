using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuActions : MonoBehaviour
{
    // ===========================================================
    // Public Methods
    // ===========================================================

    public void StartGame()
    {
        SceneManager.LoadScene(Scenes.MAIN_SCENE);
    }
}
