using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System.Linq;

public class BlockStepper : MonoBehaviour
{
    private bool isStepping = false;
    private int stepDirection = 1;
    private int currentPosition = Constants.STARTING_BLOCK_POSITION;
    private float currentStepSpeed = Constants.STARTING_TIME_BETWEEN_STEPS;
    private int towerLeft = Constants.STARTING_BLOCK_POSITION - 1;
    private int towerMiddle = Constants.STARTING_BLOCK_POSITION;
    private int towerRight = Constants.STARTING_BLOCK_POSITION + 1;


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
        // mark new tower positions
        towerLeft = currentPosition - 1;
        towerMiddle = currentPosition;
        towerRight = currentPosition + 1;
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
        // Wait for n seconds
        yield return new WaitForSeconds(currentStepSpeed);

        doStep();

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
        stepDirection = currentPosition <= towerMiddle ? 1 : -1;
    }

    private (float startingXPosition, int startingPosition) getRandomStartingXPosition()
    {
        // Generate a random number that is not on top of tower
        HashSet<int> currentActivePositions = new HashSet<int>(Constants.ACTIVE_STARTING_BLOCK_POSITIONS);
        currentActivePositions.Remove(towerLeft - 1);
        currentActivePositions.Remove(towerLeft);
        currentActivePositions.Remove(towerMiddle);
        currentActivePositions.Remove(towerRight);
        currentActivePositions.Remove(towerRight + 1);

        List<int> activePositions = currentActivePositions.ToList();
        int randomIndex = Random.Range(0, activePositions.Count);
        int randomElement = activePositions[randomIndex];

        return (Constants.STARTING_X_POSITION + (randomElement * Constants.STEP_SIZE), randomElement);
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
