using UnityEngine;

public class StatsRecorder
{
    // ===========================================================
    // Public Methods
    // ===========================================================

    public static void RecordBlockerPlace(GameObject leftBlock, GameObject middleBlock, GameObject rightBlock)
    {
        // Increment general blocks placed stat
        Save.IncrementStat(SaveProperties.BlocksPlaced);
        // Increment the specific place count stat
        incrementBlockerPlaceType(getBlockCount(leftBlock, middleBlock, rightBlock));
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
}
