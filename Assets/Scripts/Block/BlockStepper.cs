using System.Collections;
using UnityEngine;

public class BlockStepper : MonoBehaviour
{
    private bool isStepping = false;
    private int stepDirection = 1;
    private int currentPosition = Constants.STARTING_BLOCK_POSITION;
    private float currentStepSpeed = Constants.STARTING_TIME_BETWEEN_STEPS;


    private GameObject leftCube;
    private GameObject middleCube;
    private GameObject rightCube;

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

    public void StartStepping()
    {
        // Choose a random starting point for block before starting
        moveToRandomStartingPositionOnRow();

        // TODO: only restart if game is still active

        // Make stepper visible
        editBlockVisibility(true);
        // Start stepping
        isStepping = true;
        StartCoroutine(stepWithDelay());
    }

    public void StopStepping()
    {
        print("STOP");
        // Make stepper invisible
        editBlockVisibility(false);
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

        // Adjust transform position of each block
        float step = Constants.STEP_SIZE * stepDirection;
        transformBlockPosition(leftCube, step);
        transformBlockPosition(middleCube, step);
        transformBlockPosition(rightCube, step);
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
        // Get random starting position
        (float startingXPosition, int startingPosition) = getRandomStartingXPosition();
        currentPosition = startingPosition;
        Vector3 middlePosition = new Vector3(0, transform.position.y, transform.position.z);

        // move left block
        leftCube.transform.position = middlePosition + new Vector3(startingXPosition - Constants.STEP_SIZE, 0, 0);
        // move middle block
        middleCube.transform.position = middlePosition + new Vector3(startingXPosition, 0, 0);
        // move right cube
        rightCube.transform.position = middlePosition + new Vector3(startingXPosition + Constants.STEP_SIZE, 0, 0);

        // always move towards the middle on start
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

    private void editBlockVisibility(bool visibility)
    {
        leftCube.GetComponent<SpriteRenderer>().enabled = visibility;
        middleCube.GetComponent<SpriteRenderer>().enabled = visibility;
        rightCube.GetComponent<SpriteRenderer>().enabled = visibility;
    }

    private void transformBlockPosition(GameObject block, float step)
    {
        block.transform.position = block.transform.position + new Vector3(step, 0, 0);
    }
}
