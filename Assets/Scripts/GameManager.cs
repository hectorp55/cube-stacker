using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton
{
    public GameObject Blocks;
    public GameObject[] uiElements;
    public TouchInput startTouchInput;
    public bool IsGameActive { get; private set; } = false;
    public int Score { get; private set; } = 0;
    public SoundEffects SoundEffectsPlayer { get; private set; }

    private BlockController blockController;
    private int remainingLives = Constants.START_LIVES_COUNT;
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
}
