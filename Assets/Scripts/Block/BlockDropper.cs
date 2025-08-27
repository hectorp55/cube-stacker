using System.Collections;
using UnityEngine;

public class BlockDropper : MonoBehaviour
{
    private GameManager gameManager;
    private HangingBlockCheck hangingBlockCheck;
    private BlockAnimator blockAnimator;

    // ===========================================================
    // Mono Methods
    // ===========================================================

    void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        hangingBlockCheck = GetComponent<HangingBlockCheck>();
        blockAnimator = GetComponent<BlockAnimator>();
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

        // Wait for n seconds
        yield return new WaitForSeconds(Constants.DROPPING_TIME_BETWEEN_STEPS);

        if (!isBlockOnBottom())
        {
            // Step down again
            StartCoroutine(dropWithDelay());
        }
        else
        {
            // TODO: play negative sounds effect
            // Play destroy animation
            blockAnimator.PlayDestroyAnimation();
            // Wait for one more cycle at the bottom for effect
            yield return new WaitForSeconds(Constants.BOTTOM_SITTING_TIME);
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
