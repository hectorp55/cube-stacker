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

    void Update()
    {
        UpdateScoreText();
    }

    // ===========================================================
    // Private Methods
    // ===========================================================

    private void UpdateScoreText()
    {
        scoreText.text = $"{gameManager.Score}";
    }
}
