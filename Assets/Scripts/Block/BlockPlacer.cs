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
        // Place block
        StartCoroutine(placeBlock());
    }

    // ===========================================================
    // Private Methods
    // ===========================================================

    // Places the current block down
    private IEnumerator placeBlock()
    {
        // Place a block in my spot if the gameobject is active
        instantiateBlocksIfActive();

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
        // TODO: only continue stepping if the game is still active
        if (gameManager.IsGameActive)
        {
            blockController.StartStepping();
        }
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
