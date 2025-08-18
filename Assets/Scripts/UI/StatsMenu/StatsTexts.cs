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

    // TODO: return button to main menu

    // ===========================================================
    // Mono Methods
    // ===========================================================

    void Start()
    {
        DefinePlacedText();
        DefineGamePlayedText();
        DefineHighScoreText();
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
}
