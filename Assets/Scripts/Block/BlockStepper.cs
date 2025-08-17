using System.Collections;
using UnityEngine;

public class BlockStepper : MonoBehaviour
{
    private bool isStepping = false;
    private int stepDirection = 1;
    private int currentPosition = Constants.STARTING_BLOCK_POSITION;
    private int endPosition = Constants.EDGE_BLOCK_POSITION;

    // ===========================================================
    // Public Methods
    // ===========================================================

    public void StartStepping()
    {
        isStepping = true;
        StartCoroutine(stepWithDelay());
    }

    public void StopStepping()
    {
        isStepping = false;
        print("STOP");
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
        if (currentPosition >= endPosition || currentPosition <= 1)
        {
            stepDirection = stepDirection * -1;
        }
    }
}
