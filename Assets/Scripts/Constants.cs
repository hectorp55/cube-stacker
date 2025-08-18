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
    // The amount of rows necessary to climb before you hit top speed
    public const int ROWS_UNITLL_TOP_SPEED = 50;
    // Determines the fastest time that can occur between steps
    public const float MIN_TIME_BETWEEN_STEPS = 0.05f;
    // The starting speed between steps on a new life in seconds
    public const float STARTING_TIME_BETWEEN_STEPS = 0.3f;
    // The speed up time between rows
    public const float SPEED_DIFFERENCE_PER_ROW = (STARTING_TIME_BETWEEN_STEPS - 0.05f) / ROWS_UNITLL_TOP_SPEED;
    // Placing pause effect time in seconds
    public const float PLACING_PAUSE_EFFECT = 0.5f;
    // Starting amount of lives. Corresponds to the number of starting blocks. 
    public const int START_LIVES_COUNT = 3;
    // The speed between steps on dropping block
    public const float DROPPING_TIME_BETWEEN_STEPS = 0.2f;
    // Y position for the top of tower when the camera should start moving upwards
    public const float Y_POSITION_TO_START_MOVING_CAMERA = 1.5f;
}

public class Scenes
{
    public const string MAIN_SCENE = "MainScene";
    public const string MENU_SCENE = "MenuScene";
    public const string SCORE_SCENE = "ScoreScene";
    public const string STATS_SCENE = "StatsScene";
}
