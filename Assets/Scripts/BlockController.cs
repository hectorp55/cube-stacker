using UnityEngine;

public class BlockController : MonoBehaviour
{
    private BlockStepper blockStepper;

    void Awake()
    {
        blockStepper = GetComponent<BlockStepper>();
    }

    void Start()
    {

    }

    void Update()
    {

    }

    // ===========================================================
    // Public Methods
    // ===========================================================

    // Controls a step of the block
    public void StartStepping()
    {
        blockStepper.StartStepping();
    }

    public void StopStepping()
    {
        // TODO: stop moving the block. It was placed.
    }

    // ===========================================================
    // Private Methods
    // ===========================================================
}
