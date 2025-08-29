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
        float assignedHeight = Constants.STEP_SIZE * PositionLevel + bottomOfScreen;
        return new Vector3(transform.position.x, assignedHeight, transform.position.z);
    }
}
