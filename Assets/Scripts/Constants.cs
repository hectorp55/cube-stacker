using UnityEngine;

public class Constants
{
    // Position distance between block locations
    public const float STEP_SIZE = 1.5f;
    // Starting from the middle how many steps untill we hit the edge of the screen
    public const int STEPS_TO_EDGE = 5;
    // Middle starting position
    public const int STARTING_BLOCK_POSITION = 0;
    // Position of block when it should turn around on edge
    public const int RIGHT_EDGE_BLOCK_POSITION = STEPS_TO_EDGE;
    // Position of block when it should turn around on edge
    public const int LEFT_EDGE_BLOCK_POSITION = RIGHT_EDGE_BLOCK_POSITION * -1;
    // Middle transform.position.x for a block
    public const float STARTING_X_POSITION = 0f;
    // The starting speed between steps on a new life in seconds
    public const float STARTING_TIME_BETWEEN_STEPS = 0.3f;
    // Placing pause effect time in seconds
    public const float PLACING_PAUSE_EFFECT = 0.5f;
}
