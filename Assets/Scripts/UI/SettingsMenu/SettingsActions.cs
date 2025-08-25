using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsActions : MonoBehaviour
{
    // ===========================================================
    // Public Methods
    // ===========================================================

    public void NavigateBack()
    {
        SceneManager.LoadScene(Scenes.MAIN_SCENE);
    }
}
