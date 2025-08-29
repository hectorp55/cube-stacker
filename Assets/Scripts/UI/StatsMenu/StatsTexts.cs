using UnityEngine;
using TMPro;

public class StatsTexts : MonoBehaviour
{
    public TextMeshProUGUI blockedPlacedText;
    public TextMeshProUGUI tripleBlockedPlacedText;
    public TextMeshProUGUI doubleBlockedPlacedText;
    public TextMeshProUGUI singleBlockedPlacedText;
    public TextMeshProUGUI gamesPlayedText;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI averageScoreText;
    public TextMeshProUGUI shootingStarsSeenText;

    // TODO: return button to main menu

    // ===========================================================
    // Mono Methods
    // ===========================================================

    void Start()
    {
        DefinePlacedText();
        DefineGamePlayedText();
        DefineHighScoreText();
        DefineAverageScoreText();
        DefineShootingStarText();
    }

    // ===========================================================
    // Private Methods
    // ===========================================================

    private void DefinePlacedText()
    {
        int blocksPlaced = Save.GetIntProperty(SaveProperties.BlocksPlaced);
        int singleBlocksPlaced = Save.GetIntProperty(SaveProperties.SingleBlocksPlaced);
        int doubleBlocksPlaced = Save.GetIntProperty(SaveProperties.DoubleBlocksPlaced);
        int tripleBlocksPlaced = Save.GetIntProperty(SaveProperties.TripleBlocksPlaced);

        blockedPlacedText.text = $"{blocksPlaced}";
        singleBlockedPlacedText.text = $"{singleBlocksPlaced}";
        doubleBlockedPlacedText.text = $"{doubleBlocksPlaced}";
        tripleBlockedPlacedText.text = $"{tripleBlocksPlaced}";
    }

    private void DefineGamePlayedText()
    {
        int gamesPlayed = Save.GetIntProperty(SaveProperties.GamesPlayed);

        gamesPlayedText.text = $"{gamesPlayed}";
    }

    private void DefineHighScoreText()
    {
        int highScore = Save.GetHighScore();

        highScoreText.text = $"{highScore}";
    }

    private void DefineAverageScoreText()
    {
        int blocksPlaced = Save.GetIntProperty(SaveProperties.BlocksPlaced);
        int gamesPlayed = Save.GetIntProperty(SaveProperties.GamesPlayed);
        int averageScore = blocksPlaced / gamesPlayed;

        averageScoreText.text = $"{averageScore}";
    }

    private void DefineShootingStarText()
    {
        int shootingStarsSeen = Save.GetIntProperty(SaveProperties.ShootingStarsSeen);

        shootingStarsSeenText.text = $"{shootingStarsSeen}";
    }
}
