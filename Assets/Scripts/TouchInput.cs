using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

public class TouchInput : MonoBehaviour
{
    private BlockController blockController;

    // ===========================================================
    // Mono Methods
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
        OnTouchDetected();
    }

    private void OnTouchDetected()
    {
        // TODO: block inputs untill the block starts moving again. Dont allow multiple touches in one spot.
        blockController.PlaceBlock();
    }
}
