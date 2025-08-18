using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton
{
    public GameObject Blocks;
    public bool IsGameActive { get; private set; } = false;

    private BlockController blockController;
    private int remainingLives = Constants.START_LIVES_COUNT;
    private int blocksDropping = 0;

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
