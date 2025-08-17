using System.Collections;
using UnityEngine;

public class BlockDropper : MonoBehaviour
{
    private HangingBlockCheck hangingBlockCheck;

    // ===========================================================
    // Mono Methods
    // ===========================================================

    void Awake()
    {
        hangingBlockCheck = GetComponent<HangingBlockCheck>();
    }

    // ===========================================================
    // Public Methods
    // ===========================================================

    public void DropBlock()
    {
        print("DROP");
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
        yield return new WaitForSeconds(1f);
        
        if (!isBlockOnBottom())
        {
            // Step down again
            StartCoroutine(dropWithDelay());
        }
        else
        {
            // TODO: blink as we fall
            // TODO: play negative sounds effect
            // Alert that the block has fallen to the bottom
            print("BOTTOM");
            Destroy(gameObject);
            // Destroy the block
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
