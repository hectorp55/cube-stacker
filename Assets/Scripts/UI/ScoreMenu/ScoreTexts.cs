using UnityEngine;
using TMPro;

public class ScoreTexts : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI medalText; // TODO: make this an image
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
        DefineMedal();
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

    private void DefineMedal()
    {
        // get score and calculate medal
        string medalType = GetMedalType();
        medalText.text = medalType;
    }

    private string GetMedalType()
    {
        int score = gameManager?.Score ?? 0;

        if (score > 100)
        {
            return "Gold";
        }
        else if (score > 70)
        {
            return "Silver";
        }
        else if (score > 30)
        {
            return "Bronze";
        }
        else
        {
            return "None";
        }
    }
}
