using UnityEngine;

public class SaveProperties
{
    public const string HighScore = "HighScore";
    public const string BlocksPlaced = "BlocksPlaced";
    public const string TripleBlocksPlaced = "TripleBlocksPlaced";
    public const string DoubleBlocksPlaced = "DoubleBlocksPlaced";
    public const string SingleBlocksPlaced = "SingleBlocksPlaced";
    public const string GamesPlayed = "GamesPlayed";
    public const string ShootingStarsSeen = "ShootingStarsSeen";
}

public class Save
{
    // ===========================================================
    // Public Methods
    // ===========================================================

    public static void TryUpdateHighScore(int currentScore)
    {
        if (GetHighScore() < currentScore)
        {
            SaveIntProperty(SaveProperties.HighScore, currentScore);
        }
    }

    public static int GetHighScore()
    {
        return GetIntProperty(SaveProperties.HighScore);
    }

    public static int GetIntProperty(string property)
    {
        return PlayerPrefs.GetInt(property);
    }

    public static void IncrementStat(string property)
    {
        int value = GetIntProperty(property);
        SaveIntProperty(property, value + 1);
    }

    // ===========================================================
    // Private Methods
    // ===========================================================

    private static void SaveIntProperty(string property, int value)
    {
        PlayerPrefs.SetInt(property, value);
    }
}
