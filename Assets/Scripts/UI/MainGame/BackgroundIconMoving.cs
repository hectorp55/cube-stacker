using UnityEngine;

public class BackgroundIconMoving : MonoBehaviour
{
    // ===========================================================
    // Mono Methods
    // ===========================================================

    // ===========================================================
    // Public Methods
    // ===========================================================

    public void MoveBackgroundIconsUp()
    {
        // transform up at a different speed
        Vector3 currentPosition = transform.position;
        float iconStepSize = Constants.STEP_SIZE / 2f;
        transform.position = new Vector3(currentPosition.x, currentPosition.y + iconStepSize, currentPosition.z);
    }
}
