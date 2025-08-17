using System.Collections;
using UnityEngine;

public class BlockStepper : MonoBehaviour
{
    private bool isStepping = false;
    private int stepDirection = 1;
    private int currentPosition = Constants.STARTING_BLOCK_POSITION;
    private SpriteRenderer spriteRenderer;
    private float currentStepSpeed = Constants.STARTING_TIME_BETWEEN_STEPS;

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
        // Choose a random starting point for block before starting
        moveToRandomStartingPositionOnRow();

        // TODO: only restart if game is still active

        // Make stepper visible
        spriteRenderer.enabled = true;
        // Start stepping
        isStepping = true;
        StartCoroutine(stepWithDelay());
    }

    public void StopStepping()
    {
        // Make stepper invisible
        spriteRenderer.enabled = false;
        // Stop stepping
        isStepping = false;
        // Pick up speed after a stop
        currentStepSpeed = getNewTimeBetweenSteps(currentStepSpeed);
        print(currentStepSpeed);
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
        yield return new WaitForSeconds(currentStepSpeed);

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
        // TODO: should not flip right on edge should flip a little off screen
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
        stepDirection = currentPosition <= 0 ? 1 : -1;
    }

    private (float startingXPosition, int startingPosition) getRandomStartingXPosition()
    {
        // Get a random integer between -4 and 4
        int randomInt = Random.Range(-4, 5); // upper bound is exclusive for ints

        return (Constants.STARTING_X_POSITION + (randomInt * Constants.STEP_SIZE), randomInt);
    }

    private float getNewTimeBetweenSteps(float previousTimeBetweenSteps)
    {
        // TODO: lock in this formula for the top speed
        if (previousTimeBetweenSteps <= 0.05f)
        {
            return 0.05f;
        }
        else
        {
            return previousTimeBetweenSteps - 0.01f;   
        }
    }
}
