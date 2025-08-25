using UnityEngine;
using TMPro;

public class ScoreUpdater : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private GameManager gameManager;

    // ===========================================================
    // Mono Methods
    // ===========================================================

    void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    void Start()
    {
        UpdateScoreText(Save.GetHighScore());
    }

    void Update()
    {
        if (gameManager.IsGameActive)
        {
            UpdateScoreText(gameManager.Score);
        }
    }

    // ===========================================================
    // Private Methods
    // ===========================================================

    private void UpdateScoreText(int score)
    {
        scoreText.text = $"{score}";
    }
}
