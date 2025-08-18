using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton
{
    public GameObject Blocks;
    public bool IsGameActive { get; private set; } = false;
    public int Score { get; private set; } = 0;

    private BlockController blockController;
    private int remainingLives = Constants.START_LIVES_COUNT;
    private int blocksDropping = 0;

    // TODO: Record stats
    // TODO: scrolling press start on board
    // TODO: allow access to the stats screen by button press
    // TODO: once game starts set menu buttons inactive

    // ===========================================================
    // Mono Methods
    // ===========================================================

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        blockController = Blocks.GetComponent<BlockController>();
    }

    void Start()
    {
        startGame();
    }

    // ===========================================================
    // Public Methods
    // ===========================================================

    public void BlockMissed()
    {
        IsGameActive = false;
        blocksDropping += 1;
        remainingLives -= 1;
        // Sets fallen blocks as inactive in controller
        setInactiveBlocksAfterMiss();
    }

    public void BlockDropped()
    {
        blocksDropping -= 1;
        // Make sure no more blocks are still dropping
        if (blocksDropping <= 0)
        {
            // If we still have lives keep playing otherwise gameover
            if (remainingLives <= 0)
            {
                gameOver();
            }
            else
            {
                startGame();
            }
        }
    }

    public void Scored()
    {
        Score += 1;
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
        // Try to update the highscore
        Save.TryUpdateHighScore(Score);
        // Navigate to retry screen
        SceneManager.LoadScene(Scenes.SCORE_SCENE);
    }

    private void setInactiveBlocksAfterMiss()
    {
        if (remainingLives == 2)
        {
            blockController.leftCube.SetActive(false);
        }
        else if (remainingLives == 1)
        {
            blockController.rightCube.SetActive(false);
        }
    }
}
