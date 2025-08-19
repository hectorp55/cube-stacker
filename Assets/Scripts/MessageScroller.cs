using System.Collections;
using UnityEngine;

public class MessageScroller : MonoBehaviour
{
    private const float OFF_SCREEN_HEIGHT_Y = 84f;
    private Vector3 startingPosition;
    private bool isMoving = true;

    // ===========================================================
    // Mono Methods
    // ===========================================================

    void Awake()
    {
        startingPosition = transform.position;
    }

    void Start()
    {
        StartCoroutine(stepMessageUp());
    }

    // ===========================================================
    // Public Methods
    // ===========================================================

    void StopMessage()
    {
        // Stop moving
        isMoving = false;
        // Hide message
        gameObject.SetActive(false);
    }

    // ===========================================================
    // Private Methods
    // ===========================================================

    private IEnumerator stepMessageUp() {
        if (isMoving)
        {
            // If we hit the top then move to bottom
            if (transform.position.y > OFF_SCREEN_HEIGHT_Y)
            {
                restartMessage();
            }
            else
            {
                // Move gameobject up
                doStep();
            }
            yield return new WaitForSeconds(Constants.DROPPING_TIME_BETWEEN_STEPS);

            StartCoroutine(stepMessageUp());
        }
    }

    private void doStep()
    {
        transform.position = transform.position + new Vector3(0, Constants.STEP_SIZE, 0);
    }

    private void restartMessage()
    {
        transform.position = startingPosition;
        // Go back to starting position
    }
}
