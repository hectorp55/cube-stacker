using UnityEngine;
using TMPro;

public class ScoreTexts : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI scoreText;
    private GameManager gameManager;

    // ===========================================================
    // Mono Methods
    // ===========================================================

    void Awake()
    {
        // Keep in mind this can be null
        gameManager = GameObject.FindGameObjectWithTag("GameManager")?.GetComponent<GameManager>();
    }

    void Start()
    {
        DefineScoreText();
        DefineHighScoreText();
    }

    // ===========================================================
    // Private Methods
    // ===========================================================

    private void DefineScoreText()
    {
        scoreText.text = $"Score: {gameManager?.Score ?? 0}";
    }

    private void DefineHighScoreText()
    {
        int highScore = Save.GetHighScore();

        highScoreText.text = $"Highscore: {highScore}";
    }
}
