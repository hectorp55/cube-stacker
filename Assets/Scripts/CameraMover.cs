using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public GameObject blockController;

    private Vector3 startingPosition;
    private float yDistanceBetweenCameraAndTower = 0;

    // ===========================================================
    // Mono Methods
    // ===========================================================

    void Update()
    {
        // if blocks are over certain position then my position equal that position - distance at that time.
        if (blockController.transform.position.y == Constants.Y_POSITION_TO_START_MOVIING)
        {
            startingPosition = transform.position;
            yDistanceBetweenCameraAndTower = blockController.transform.position.y - startingPosition.y;
        }
        if (blockController.transform.position.y > Constants.Y_POSITION_TO_START_MOVIING)
        {
            transform.position = calculateMyNewPosition();
        }
    }


    // ===========================================================
    // Public Methods
    // ===========================================================


    // ===========================================================
    // Private Methods
    // ===========================================================

    public Vector3 calculateMyNewPosition()
    {
        return new Vector3(
            startingPosition.x,
            blockController.transform.position.y - Constants.DISTANCE_BETWEEN_CAMERA_AND_TOWER,
            startingPosition.z
        );
    }
}
