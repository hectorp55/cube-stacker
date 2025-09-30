using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton
{
    public GameObject Blocks;
    public GameObject[] uiElements;
    public TouchInput startTouchInput;
    public bool IsGameActive { get; private set; } = false;
    public int Score { get; private set; } = 0;
    public int TriplePlace { get; private set; } = 0;
    public int SinglePlace { get; private set; } = 0;
    public SoundEffects SoundEffectsPlayer { get; private set; }

    private BlockController blockController;
    private int remainingLives = Constants.START_LIVES_COUNT;
    private int roundStartingLives = Constants.START_LIVES_COUNT;
    private int blocksDropping = 0;

    // ===========================================================
    // Mono Methods
    // ===========================================================

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        blockController = Blocks.GetComponent<BlockController>();
        SoundEffectsPlayer = GetComponent<SoundEffects>();
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
            // Record drop stats
            StatsRecorder.RecordBlockerMiss(roundStartingLives, remainingLives);

            // If we still have lives keep playing otherwise gameover
            if (remainingLives <= 0)
            {
                gameOver();
            }
            else
            {
                continueGame();
            }
        }
    }

    public void Scored()
    {
        Score += 1;

        int blocksPlaced = getActiveBlockCount();
        if (blocksPlaced == 3)
        {
            TriplePlace += 1;
        }
        else if (blocksPlaced == 1)
        {
            SinglePlace += 1;   
        }
    }

    public void StartGame()
    {
        startGame();
    }


    // ===========================================================
    // Private Methods
    // ===========================================================

    private void startGame()
    {
        // Remove the start touch listener
        Destroy(startTouchInput);
        // Set contoller to active state so its visible
        blockController.gameObject.SetActive(true);
        // Record stats of this new game
        StatsRecorder.RecordNewGame();
        // Hide all UI buttons so they dont accidetally get pressed
        disableUiElements();
        // set active game state
        IsGameActive = true;
        // start the actual game movement
        blockController.StartStepping();
    }

    private void gameOver()
    {
        // Try to update the highscore
        Save.TryUpdateHighScore(Score);
        // Navigate to retry screen
        SceneManager.LoadScene(Scenes.SCORE_SCENE);
    }

    private void continueGame()
    {
        // Remember how many lives I had at start of round
        roundStartingLives = remainingLives;
        // set active game state
        IsGameActive = true;
        // start the actual game movement
        blockController.StartStepping();
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

    private void disableUiElements()
    {
        foreach (GameObject element in uiElements)
        {
            element.SetActive(false);
        }

    }

    private int getActiveBlockCount()
    {
        int count = 0;
        if (blockController.leftCube.activeSelf)
        {
            count += 1;
        }
        if (blockController.middleCube.activeSelf)
        {
            count += 1;
        }
        if (blockController.rightCube.activeSelf)
        {
            count += 1;
        }
        return count;
    }
}
