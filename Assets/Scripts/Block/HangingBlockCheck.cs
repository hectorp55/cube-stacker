using UnityEngine;

public class HangingBlockCheck : MonoBehaviour
{
    // How far to check downwards
    private float checkDistance = Constants.STEP_SIZE;
    private LayerMask layerMask = Physics.DefaultRaycastLayers;

    private GameManager gameManager;
    private BlockDropper blockDropper;

    void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        blockDropper = GetComponent<BlockDropper>();
    }

    void Start()
    {
        if (!IsBlockUnderneath())
        {
            // Notify there was a block miss
            gameManager.BlockMissed();
            // Drop the block off the screen   
            blockDropper.DropBlock();
        }
    }

    // ===========================================================
    // Public Methods
    // ===========================================================

    public bool IsBlockUnderneath()
    {
        // Create a ray starting from the object's position going down
        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hit;

        // Perform the raycast
        if (Physics.Raycast(ray, out hit, checkDistance, layerMask))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // ===========================================================
    // Private Methods
    // ===========================================================
}

