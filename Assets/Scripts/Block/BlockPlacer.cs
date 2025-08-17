using System.Collections;
using UnityEngine;

public class BlockPlacer : MonoBehaviour
{
    public GameObject blockPrefab;

    private GameManager gameManager;
    private BlockController blockController;

    void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        blockController = GetComponent<BlockController>();
    }

    // ===========================================================
    // Public Methods
    // ===========================================================

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
        // Place a block in my spot
        Instantiate(blockPrefab, transform.position, transform.rotation);

        // Stop Stepping
        blockController.StopStepping();

        // Pause for effects of placement
        yield return new WaitForSeconds(1f);

        // Move stepping block up
        float lift = 1.5f;
        transform.position = transform.position + new Vector3(0, lift, 0);

        // Start Stepping
        blockController.StartStepping();
        // TODO: add particle explosion or like star explosion for feeling good about hitting
        // TODO: only place the block if the game is still active
    }
}
