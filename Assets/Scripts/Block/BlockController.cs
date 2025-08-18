using UnityEngine;

public class BlockController : Singleton
{
    public GameObject leftCube;
    public GameObject middleCube;
    public GameObject rightCube;

    private GameManager gameManager;
    private BlockStepper blockStepper;
    private BlockPlacer blockPlacer;

    void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
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
        print("STOP");
        blockStepper.StopStepping();
    }

    // ===========================================================
    // Private Methods
    // ===========================================================
}
