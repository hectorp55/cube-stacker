using UnityEngine;

public class BlockController : MonoBehaviour
{
    private BlockStepper blockStepper;
    private BlockPlacer blockPlacer;

    void Awake()
    {
        blockStepper = GetComponent<BlockStepper>();
        blockPlacer = GetComponent<BlockPlacer>();
    }

    // ===========================================================
    // Public Methods
    // ===========================================================

    // Controls a step of the block
    public void StartStepping()
    {
        blockStepper.StartStepping();
    }

    public void PlaceBlock()
    {
        blockPlacer.PlaceBlock();
    }

    public void StopStepping()
    {
        blockStepper.StopStepping();
    }

    // ===========================================================
    // Private Methods
    // ===========================================================
}
