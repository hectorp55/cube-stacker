using System.Collections;
using UnityEngine;

public class BlockStepper : MonoBehaviour
{
    private bool isStepping = false;

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
        print("Step");
        const float step = 1.5f; // TODO: make this a constant
        Vector3 currentPosition = transform.position;
        transform.position = currentPosition + new Vector3(step, 0, 0);
    }
}
