using UnityEngine;
using System.Collections.Generic;

public class SaveProperties
{
    public const string HighScore = "HighScore";
    public const string BlocksClimbed = "BlocksClimbed";
    public const string BlocksPlaced = "BlocksPlaced";
    public const string TripleBlocksPlaced = "TripleBlocksPlaced";
    public const string DoubleBlocksPlaced = "DoubleBlocksPlaced";
    public const string SingleBlocksPlaced = "SingleBlocksPlaced";
    public const string BlocksMissed = "BlocksMissed";
    public const string TripleBlocksMissed = "TripleBlocksMissed";
    public const string DoubleBlocksMissed = "DoubleBlocksMissed";
    public const string SingleBlocksMissed = "SingleBlocksMissed";
    public const string GamesPlayed = "GamesPlayed";
    public const string ShootingStarsSeen = "ShootingStarsSeen";
    public const string MasterVolume = "MasterVolume";
    public const string SoundFxVolume = "SoundFxVolume";
    public const string MusicVolume = "MusicVolume";
}

public class Save
{
    public static readonly Dictionary<string, int> DefaultSaveValues = new Dictionary<string, int>
    {
        { SaveProperties.HighScore, 0 },
        { SaveProperties.BlocksPlaced, 0 },
        { SaveProperties.BlocksClimbed, 0 },
        { SaveProperties.TripleBlocksPlaced, 0 },
        { SaveProperties.DoubleBlocksPlaced, 0 },
        { SaveProperties.SingleBlocksPlaced, 0 },
        { SaveProperties.BlocksMissed, 0 },
        { SaveProperties.TripleBlocksMissed, 0 },
        { SaveProperties.DoubleBlocksMissed, 0 },
        { SaveProperties.SingleBlocksMissed, 0 },
        { SaveProperties.GamesPlayed, 0 },
        { SaveProperties.ShootingStarsSeen, 0 },
        { SaveProperties.MasterVolume, 100 },
        { SaveProperties.SoundFxVolume, 100 },
        { SaveProperties.MusicVolume, 100 },
    };

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
        if (PlayerPrefs.HasKey(property))
        {
            return PlayerPrefs.GetInt(property);
        }
        else
        {
            return DefaultSaveValues[property];
        }
    }

    public static void IncrementStat(string property)
    {
        IncrementStatBy(property, 1);
    }

    public static void IncrementStatBy(string property, int by)
    {
        int value = GetIntProperty(property);
        SaveIntProperty(property, value + by);
    }

    public static void SaveIntProperty(string property, int value)
    {
        PlayerPrefs.SetInt(property, value);
    }

    // ===========================================================
    // Private Methods
    // ===========================================================


}
