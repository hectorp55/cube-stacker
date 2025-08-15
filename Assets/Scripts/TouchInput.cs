using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

public class TouchInput : MonoBehaviour
{
    private BlockController blockController;

    // ===========================================================
    // Public Methods
    // ===========================================================

    void Awake()
    {
        blockController = GetComponent<BlockController>();
    }

    // ===========================================================
    // Private Methods
    // ===========================================================

    private void OnEnable()
    {
        // Enable the Enhanced Touch system
        EnhancedTouchSupport.Enable();

        // Subscribe to touch events
        TouchSimulation.Enable();
        UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerDown += HandleFingerDown;
    }

    private void OnDisable()
    {
        // Disable the Enhanced Touch system
        UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerDown -= HandleFingerDown;
        EnhancedTouchSupport.Disable();
        TouchSimulation.Disable();
    }

    private void HandleFingerDown(Finger finger)
    {
        Debug.Log("Touch detected at: " + finger.screenPosition);
        OnTouchDetected();
    }

    // Your custom method that runs on touch
    private void OnTouchDetected()
    {
        // TODO: the block stop function should be called here instead
    }
}
