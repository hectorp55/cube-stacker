using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.Events;

public class TouchInput : MonoBehaviour
{
    public UnityEvent onTouchEvent;

    private BlockController blockController;
    private GameManager gameManager;

    // ===========================================================
    // Mono Methods
    // ===========================================================

    void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        blockController = GetComponent<BlockController>();
    }

    // ===========================================================
    // Private Methods
    // ===========================================================

    private void OnEnable()
    {
        // Enable the Enhanced Touch system
        EnhancedTouchSupport.Enable();

        // TouchSimulation.Enable();
        // Subscribe to touch events
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
        triggerTouchEvent();
    }

    private void triggerTouchEvent()
    {
        onTouchEvent.Invoke();
    }
}
