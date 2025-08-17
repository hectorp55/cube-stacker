using System.Collections;
using UnityEngine;

public class BlockStepper : MonoBehaviour
{
    private bool isStepping = false;
    private int stepDirection = 1;
    private int currentPosition = Constants.STARTING_BLOCK_POSITION;
    private SpriteRenderer spriteRenderer;

    // ===========================================================
    // Mono Methods
    // ===========================================================

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // ===========================================================
    // Public Methods
    // ===========================================================

    public void StartStepping()
    {
        // TODO: choose a random starting point for block before starting
        moveToRandomStartingPositionOnRow();

        isStepping = true;
        spriteRenderer.enabled = true;
        StartCoroutine(stepWithDelay());
    }

    public void StopStepping()
    {
        isStepping = false;
        spriteRenderer.enabled = false;
        print("Stop");
        // TODO: pick up speed after a stop
    }


    // ===========================================================
    // Private Methods
    // ===========================================================

    private void doStep()
    {
        moveBlockPosition();
    }

    // Steps the blocks forward with a delay
    private IEnumerator stepWithDelay()
    {
        doStep();

        // Wait for 2 seconds
        yield return new WaitForSeconds(1f);

        if (isStepping)
        {
            StartCoroutine(stepWithDelay());
        }
    }

    private void moveBlockPosition()
    {
        // Check to see if the flip needs to happen
        checkForFlip();

        // Adjust position in class
        currentPosition += stepDirection;

        // Adjust transform position
        float step = Constants.STEP_SIZE * stepDirection;
        transform.position = transform.position + new Vector3(step, 0, 0);
    }

    private void checkForFlip()
    {
        if (currentPosition >= Constants.RIGHT_EDGE_BLOCK_POSITION ||
        currentPosition <= Constants.LEFT_EDGE_BLOCK_POSITION)
        {
            stepDirection = stepDirection * -1;
        }
    }

    private void moveToRandomStartingPositionOnRow()
    {
        (float startingXPosition, int startingPosition) = getRandomStartingXPosition();
        currentPosition = startingPosition;
        Vector3 middlePosition = new Vector3(0, transform.position.y, transform.position.z);
        transform.position = middlePosition + new Vector3(startingXPosition, 0, 0);
    }

    private (float startingXPosition, int startingPosition) getRandomStartingXPosition()
    {
        // Get a random integer between -5 and 5 (inclusive of -5, exclusive of 5)
        int randomInt = Random.Range(-5, 6); // upper bound is exclusive for ints

        return (Constants.STARTING_X_POSITION + (randomInt * Constants.STEP_SIZE), randomInt);
    }
}
