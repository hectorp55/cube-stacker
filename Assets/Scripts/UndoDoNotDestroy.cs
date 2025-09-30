using UnityEngine;
using UnityEngine.SceneManagement;

public class UndoDoNotDestroy : MonoBehaviour
{
    void Start()
    {
        // GameManager
        GameObject gameManager = GameObject.FindGameObjectWithTag(Tags.GAME_MANAGER);
        if (gameManager)
        {
            Scene currentScene = SceneManager.GetActiveScene();

            // Move gamemanager back to active scene so it is destroyed as normal
            SceneManager.MoveGameObjectToScene(gameManager, currentScene);
        }
        
        // GameCenter Manager
        GameObject gameCenter = GameObject.FindGameObjectWithTag(Tags.GAMECENTER_MANAGER);
        if (gameCenter)
        {
            Scene currentScene = SceneManager.GetActiveScene();

            // Move gamecenter back to active scene so it is destroyed as normal
            SceneManager.MoveGameObjectToScene(gameCenter, currentScene);   
        }
    }
}
