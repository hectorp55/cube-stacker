using UnityEngine;
using UnityEngine.SceneManagement;

public class UndoDoNotDestroy : MonoBehaviour
{
    void Start()
    {
        GameObject gameManager = GameObject.FindGameObjectWithTag("GameManager");
        if (gameManager)
        {
            Scene currentScene = SceneManager.GetActiveScene();

            // Move gamemanager back to active scene so it is destroyed as normal
            SceneManager.MoveGameObjectToScene(gameManager, currentScene);   
        }
    }
}
