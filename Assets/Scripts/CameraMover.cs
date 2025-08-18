using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public GameObject blockController;

    private Vector3 startingPosition;
    private float distanceBetweenTowerAndCamera = 0;

    // ===========================================================
    // Mono Methods
    // ===========================================================

    void Awake()
    {
        startingPosition = transform.position;
    }

    void Update()
    {
        // if blocks are over certain position then my position equal that position - distance at that time.
        if (blockController.transform.position.y == Constants.Y_POSITION_TO_START_MOVING_CAMERA)
        {
            distanceBetweenTowerAndCamera = blockController.transform.position.y - transform.position.y;
        }
        if (blockController.transform.position.y > Constants.Y_POSITION_TO_START_MOVING_CAMERA)
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
            blockController.transform.position.y - distanceBetweenTowerAndCamera,
            startingPosition.z
        );
    }
}
