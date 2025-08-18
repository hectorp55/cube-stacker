using UnityEngine;

public class BlockController : MonoBehaviour
{
    public GameObject leftCube;
    public GameObject middleCube;
    public GameObject rightCube;


    private BlockStepper blockStepper;
    private BlockPlacer blockPlacer;

    void Awake()
    {
        blockStepper = GetComponent<BlockStepper>();
        blockPlacer = GetComponent<BlockPlacer>();

        // Set current blocks
        blockStepper.SetBlocks(leftCube, middleCube, rightCube);
        blockPlacer.SetBlocks(leftCube, middleCube, rightCube);
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

    // ===========================================================
    // Private Methods
    // ===========================================================
}
