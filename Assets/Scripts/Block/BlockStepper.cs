using System.Collections;
using UnityEngine;

public class BlockStepper : MonoBehaviour
{
    private bool isStepping = false;
    private int stepDirection = 1;
    private int currentPosition = Constants.STARTING_BLOCK_POSITION;
    private float currentStepSpeed = Constants.STARTING_TIME_BETWEEN_STEPS;
    private int? towerMiddle = null;


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
        // Cant start stepping if already stepping
        if (!isStepping)
        {
            // mark us stepping
            isStepping = true;
            // Choose a random starting point for block before starting
            moveToRandomStartingPositionOnRow();

            // Make stepper visible
            editBlockVisibility(true);
            // Start stepping
            StartCoroutine(stepWithDelay());
        }
    }

    public void StopStepping()
    {
        // Stop stepping
        isStepping = false;
        // First time we stop mark this as the tower middle
        if (!towerMiddle.HasValue)
        {
            towerMiddle = currentPosition;
        }
        // Make stepper invisible
        editBlockVisibility(false);
        // Pick up speed after a stop
        currentStepSpeed = getNewTimeBetweenSteps(currentStepSpeed);
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

        // Wait for n seconds
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
        if (currentPosition >= Constants.RIGHT_EDGE_BLOCK_POSITION) {
            stepDirection = -1;
        } else if (currentPosition <= Constants.LEFT_EDGE_BLOCK_POSITION) {
            stepDirection = 1;
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
        int towerPos = towerMiddle ?? 0;
        stepDirection = currentPosition <= towerPos ? 1 : -1;
    }

    private (float startingXPosition, int startingPosition) getRandomStartingXPosition()
    {
        // Get a random integer between -5 and 5
        int randomInt = Random.Range(-5, 6); // upper bound is exclusive for ints

        print(randomInt);
        return (Constants.STARTING_X_POSITION + (randomInt * Constants.STEP_SIZE), randomInt);
    }

    private float getNewTimeBetweenSteps(float previousTimeBetweenSteps)
    {
        if (previousTimeBetweenSteps <= Constants.MIN_TIME_BETWEEN_STEPS)
        {
            return Constants.MIN_TIME_BETWEEN_STEPS;
        }
        else
        {
            return previousTimeBetweenSteps - Constants.SPEED_DIFFERENCE_PER_ROW;
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

    private int calculateStepDirection()
    {
        int? middle = towerMiddle;
        if (!middle.HasValue)
        {
            middle = 0;
        }
        return currentPosition <= middle ? 1 : -1;
    }
}
