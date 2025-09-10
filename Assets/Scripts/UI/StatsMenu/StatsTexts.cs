using UnityEngine;
using TMPro;

public class StatsTexts : MonoBehaviour
{
    public TextMeshProUGUI blockedClimbedText;
    public TextMeshProUGUI blockedPlacedText;
    public TextMeshProUGUI tripleBlockedPlacedText;
    public TextMeshProUGUI doubleBlockedPlacedText;
    public TextMeshProUGUI singleBlockedPlacedText;
    public TextMeshProUGUI blockedMissedText;
    public TextMeshProUGUI tripleBlockedMissedText;
    public TextMeshProUGUI doubleBlockedMissedText;
    public TextMeshProUGUI singleBlockedMissedText;
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
        DefineBlocksClimbed();
        DefinePlacedText();
        DefineMissedText();
        DefineGamePlayedText();
        DefineHighScoreText();
        DefineAverageScoreText();
        DefineShootingStarText();
    }

    // ===========================================================
    // Private Methods
    // ===========================================================

    private void DefineBlocksClimbed()
    {
        int blocksClimbed = Save.GetIntProperty(SaveProperties.BlocksClimbed);

        blockedClimbedText.text = $"{blocksClimbed}";
    }

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

    private void DefineMissedText()
    {
        int blocksMissed = Save.GetIntProperty(SaveProperties.BlocksMissed);
        int singleBlocksMissed = Save.GetIntProperty(SaveProperties.SingleBlocksMissed);
        int doubleBlocksMissed = Save.GetIntProperty(SaveProperties.DoubleBlocksMissed);
        int tripleBlocksMissed = Save.GetIntProperty(SaveProperties.TripleBlocksMissed);

        blockedMissedText.text = $"{blocksMissed}";
        singleBlockedMissedText.text = $"{singleBlocksMissed}";
        doubleBlockedMissedText.text = $"{doubleBlocksMissed}";
        tripleBlockedMissedText.text = $"{tripleBlocksMissed}";
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
        int blocksPlaced = Save.GetIntProperty(SaveProperties.BlocksClimbed);
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
