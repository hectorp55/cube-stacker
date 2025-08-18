using System.Collections;
using UnityEngine;

public class BlockDropper : MonoBehaviour
{
    private GameManager gameManager;
    private HangingBlockCheck hangingBlockCheck;

    // ===========================================================
    // Mono Methods
    // ===========================================================

    void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        hangingBlockCheck = GetComponent<HangingBlockCheck>();
    }

    // ===========================================================
    // Public Methods
    // ===========================================================

    public void DropBlock()
    {
        StartCoroutine(dropWithDelay());
        // Alert when block leaves the screen or hits something
    }

    // ===========================================================
    // Private Methods
    // ===========================================================

    private void doDrop()
    {
        dropBlockPosition();
    }

    // Steps the blocks forward with a delay
    private IEnumerator dropWithDelay()
    {
        doDrop();

        // Wait for 1 seconds
        yield return new WaitForSeconds(Constants.DROPPING_TIME_BETWEEN_STEPS);

        if (!isBlockOnBottom())
        {
            // Step down again
            StartCoroutine(dropWithDelay());
        }
        else
        {
            // TODO: play negative sounds effect
            // Notify game manager there was a drop
            gameManager.BlockDropped();
            // Destroy the block
            Destroy(gameObject);
        }
    }

    private void dropBlockPosition()
    {
        // Adjust transform position downward
        float step = Constants.STEP_SIZE * -1;
        transform.position = transform.position + new Vector3(0, step, 0);
    }

    private bool isBlockOnBottom()
    {
        return hangingBlockCheck.IsBlockUnderneath();
    }
}
