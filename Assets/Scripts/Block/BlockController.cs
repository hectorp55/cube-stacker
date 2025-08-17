using UnityEngine;

public class BlockController : MonoBehaviour
{
    private BlockStepper blockStepper;
    private BlockPlacer blockPlacer;
    private BlockDropper blockDropper;

    void Awake()
    {
        blockStepper = GetComponent<BlockStepper>();
        blockPlacer = GetComponent<BlockPlacer>();
        blockDropper = GetComponent<BlockDropper>();
    }

    // ===========================================================
    // Public Methods
    // ===========================================================

    // Starts the block moving
    public void StartStepping()
    {
        blockStepper.StartStepping();
    }

    // Places a new block in the current location
    public void PlaceBlock()
    {
        blockPlacer.PlaceBlock();
    }

    // Stops the block moving
    public void StopStepping()
    {
        blockStepper.StopStepping();
    }

    // Drops the block off screen
    public void DropBlock()
    {
        blockDropper.DropBlock();
    }

    // ===========================================================
    // Private Methods
    // ===========================================================
}
