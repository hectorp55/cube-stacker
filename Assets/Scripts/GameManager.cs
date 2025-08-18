using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject Blocks;
    public bool IsGameActive { get; private set; } = false;

    private BlockController blockController;
    private int missedBlocksCount = 0;

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
        missedBlocksCount += 1;
    }

    public void BlockDropped()
    {
        // TODO: calculate whether the game should keep going or end
        missedBlocksCount -= 1;
        if (missedBlocksCount <= 0)
        {
            print("GAMEOVER");
            gameOver();   
        }
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
