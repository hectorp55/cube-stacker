using UnityEngine;

public class BackgroundImagePlacer : MonoBehaviour
{
    public int PositionLevel;
    private float bottomOfScreen = -10.5f;

    // ===========================================================
    // Mono Methods
    // ===========================================================

    void Start()
    {
        transform.position = getStartingPosition();
    }

    // ===========================================================
    // Private Methods
    // ===========================================================

    private Vector3 getStartingPosition() {
        // starting position - (step to get to you - starting steps + half step)
        float startingHeight = Constants.STEP_SIZE * PositionLevel + bottomOfScreen;
        float assignedHeight = startingHeight - (PositionLevel * (Constants.STEP_SIZE / 2));
        return new Vector3(transform.position.x, assignedHeight, transform.position.z);
    }
}
