using UnityEngine;

public class StatsRecorder
{
    // ===========================================================
    // Public Methods
    // ===========================================================

    public static void RecordBlockerPlace(GameObject leftBlock, GameObject middleBlock, GameObject rightBlock)
    {
        int blocksPlaced = getBlockCount(leftBlock, middleBlock, rightBlock);
        // increment blocks climbed
        Save.IncrementStat(SaveProperties.BlocksClimbed);
        // Increment general blocks placed stat
        Save.IncrementStatBy(SaveProperties.BlocksPlaced, blocksPlaced);
        // Increment the specific place count stat
        incrementBlockerPlaceType(blocksPlaced);
    }

    public static void RecordBlockerMiss(int roundStartingLives, int roundEndingLives)
    {
        int blockedMissed = getLivesLost(roundStartingLives, roundEndingLives);
        // Increment general blocks missed stat
        Save.IncrementStatBy(SaveProperties.BlocksMissed, blockedMissed);
        // Increment the specific missed count stat
        incrementBlockerMissType(blockedMissed);
    }

    public static void RecordNewGame()
    {
        // Increment general blocks placed stat
        Save.IncrementStat(SaveProperties.GamesPlayed);
    }

    public static void RecordShootingStarSeen()
    {
        // Increment shooting star stat
        Save.IncrementStat(SaveProperties.ShootingStarsSeen);
    }

    // ===========================================================
    // Private Methods
    // ===========================================================

    private static void incrementBlockerPlaceType(int placeCount)
    {
        if (placeCount == 3)
        {
            // Triple block increment
            Save.IncrementStat(SaveProperties.TripleBlocksPlaced);
        }
        else if (placeCount == 2)
        {
            // Double block increment
            Save.IncrementStat(SaveProperties.DoubleBlocksPlaced);
        }
        else if (placeCount == 1)
        {
            // Single block increment
            Save.IncrementStat(SaveProperties.SingleBlocksPlaced);
        }
    }

    private static void incrementBlockerMissType(int missCount)
    {
        if (missCount == 3)
        {
            // Triple block miss increment
            Save.IncrementStat(SaveProperties.TripleBlocksMissed);
        }
        else if (missCount == 2)
        {
            // Double block miss increment
            Save.IncrementStat(SaveProperties.DoubleBlocksMissed);
        }
        else if (missCount == 1)
        {
            // Single block miss increment
            Save.IncrementStat(SaveProperties.SingleBlocksMissed);
        }
    }

    private static int getBlockCount(GameObject leftBlock, GameObject middleBlock, GameObject rightBlock)
    {
        int blockCount = 0;
        if (leftBlock.activeSelf)
        {
            blockCount += 1;
        }
        if (middleBlock.activeSelf)
        {
            blockCount += 1;
        }
        if (rightBlock.activeSelf)
        {
            blockCount += 1;
        }
        return blockCount;
    }

    private static int getLivesLost(int roundStartingLives, int roundEndingLives)
    {
        return roundStartingLives - roundEndingLives;
    }
}
