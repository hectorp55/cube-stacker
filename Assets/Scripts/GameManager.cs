using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject Blocks;

    private BlockController blockController;
    public bool IsGameActive { get; private set; } = false;

    void Awake()
    {
        blockController = Blocks.GetComponent<BlockController>();
    }

    void Start()
    {
        startGame();
    }

    void Update()
    {

    }

    // ===========================================================
    // Public Methods
    // ===========================================================

    public void BlockMissed()
    {
        print("MISSED");
        IsGameActive = false;
    }

    public void BlockDropped()
    {
        // TODO: calculate whether the game should keep going or end
        print("GAMEOVER");
        gameOver();
    }


    // ===========================================================
    // Private Methods
    // ===========================================================

    private void startGame()
    {
        IsGameActive = true;
        blockController.StartStepping();
    }

    private void gameOver()
    {
        SceneManager.LoadScene(Scenes.SCORE_SCENE);
    }
}
