using UnityEngine;

public class ShootStar : MonoBehaviour
{
    private Vector3 pointA;      // Start point
    private Vector3 pointB;      // End point
    private float duration = 0.5f;   // Time in seconds to move from A to B

    private float minYEndPosition = -15f;
    private float maxYEndPosition = 15f;

    private float xEndPosition = 13f;
    private float zEndPosition = 0f;

    private float elapsedTime = 0f;
    private bool isMoving = false;

    // ===========================================================
    // Mono Methods
    // ===========================================================
    void Start()
    {
        // Determine start and end points
        pointA = transform.position;
        pointB = GetEndPosition();

        // Rotate star in the direction its going to move
        RotateTowardsEndPosition();

        // Shoot star
        StartMove();
    }

    void Update()
    {
        if (!isMoving)
        {
            return;
        }

        elapsedTime += Time.deltaTime;
        float t = Mathf.Clamp01(elapsedTime / duration); // normalized 0 to 1

        transform.position = Vector3.Lerp(pointA, pointB, t);

        // destroy when finished
        if (t >= 1f)
        {
            isMoving = false;
            Destroy(gameObject);
        }
    }

    // ===========================================================
    // Private Methods
    // ===========================================================

    // Call this to start the movement
    private void StartMove()
    {
        elapsedTime = 0f;
        isMoving = true;
    }

    // Generate an end position
    private Vector3 GetEndPosition()
    {
        // Random Y position
        float ySpawnPosition = Random.Range(minYEndPosition, maxYEndPosition);

        return new Vector3(xEndPosition, ySpawnPosition, zEndPosition);
    }

    private void RotateTowardsEndPosition()
    {
        Vector3 direction = pointB - pointA;
        if (direction != Vector3.zero)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}
