using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreTexts : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI scoreText;
    public GameObject emptyMedal;
    public GameObject goldMedal;
    public GameObject silverMedal;
    public GameObject bronzeMedal;
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
        int score = gameManager?.Score ?? 50;

        if (score > 100)
        {
            goldMedal.SetActive(true);
        }
        else if (score > 70)
        {
            silverMedal.SetActive(true);
        }
        else if (score > 30)
        {
            bronzeMedal.SetActive(true);
        }
        else
        {
            emptyMedal.SetActive(true);
        }
    }
}
