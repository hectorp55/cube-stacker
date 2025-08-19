using System.Collections;
using UnityEngine;

public class BlockPlacer : MonoBehaviour
{
    public GameObject blockPrefab;

    private GameManager gameManager;
    private BlockController blockController;

    private GameObject leftCube;
    private GameObject middleCube;
    private GameObject rightCube;
    private bool isPlacingBlock = false;

    // ===========================================================
    // Mono Methods
    // ===========================================================

    void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        blockController = GetComponent<BlockController>();
    }

    // ===========================================================
    // Public Methods
    // ===========================================================

    // Sets the blocks to be moved
    public void SetBlocks(GameObject leftCube, GameObject middleCube, GameObject rightCube)
    {
        this.leftCube = leftCube;
        this.middleCube = middleCube;
        this.rightCube = rightCube;
    }

    public void PlaceBlock()
    {
        // Only allow a place if the previous place routine is done
        if (!isPlacingBlock)
        {
            isPlacingBlock = true;
            // Place block
            StartCoroutine(placeBlock());
        }
    }

    // ===========================================================
    // Private Methods
    // ===========================================================

    // Places the current block down
    private IEnumerator placeBlock()
    {
        // Increment score
        gameManager.Scored();

        // Place a block in my spot if the gameobject is active
        instantiateBlocksIfActive();
        // Records stats on this place
        StatsRecorder.RecordBlockerPlace(leftCube, middleCube, rightCube);

        // Stop Stepping
        blockController.StopStepping();

        // Move stepping block up
        moveBlockPositionUp(leftCube);
        moveBlockPositionUp(middleCube);
        moveBlockPositionUp(rightCube);
        moveBlockPositionUp(gameObject);

        // Pause for effects of placement
        yield return new WaitForSeconds(Constants.PLACING_PAUSE_EFFECT);

        // Start Stepping
        if (gameManager.IsGameActive)
        {
            blockController.StartStepping();
        }
        isPlacingBlock = false;
        // TODO: add particle explosion or like star explosion for feeling good about hitting
    }

    // Create a block in the place of the given gameobject unless it is currently inactive
    private void instantiateBlocksIfActive()
    {
        if (leftCube.activeSelf)
        {
            instantiateBlockInPlace(leftCube);
        }
        if (middleCube.activeSelf)
        {
            instantiateBlockInPlace(middleCube);
        }
        if (rightCube.activeSelf)
        {
            instantiateBlockInPlace(rightCube);
        }
    }

    private void instantiateBlockInPlace(GameObject block)
    {
        Instantiate(blockPrefab, block.transform.position, block.transform.rotation);
    }

    private void moveBlockPositionUp(GameObject block)
    {
        float lift = Constants.STEP_SIZE;
        block.transform.position = block.transform.position + new Vector3(0, lift, 0);
    }
}
