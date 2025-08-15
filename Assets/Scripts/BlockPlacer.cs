using UnityEngine;

public class BlockPlacer : MonoBehaviour
{
    public GameObject blockPrefab;

    // ===========================================================
    // Public Methods
    // ===========================================================

    public void PlaceBlock()
    {
        // Place a block in my spot
        Instantiate(blockPrefab, transform.position, transform.rotation);
        // Move stepping block up
        float lift = 1.5f;
        transform.position = transform.position + new Vector3(0, lift, 0);
        // TODO: add particle explosion or like star explosion for feeling good about hitting
        // TODO: only place the block if the game is still active
    }

    // ===========================================================
    // Private Methods
    // ===========================================================
}
