using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

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
        gameManager = GameObject.FindGameObjectWithTag("GameManager")?.GetComponent<GameManager>();
        blockController = GetComponent<BlockController>();
    }

    void Update()
    {
        // Check if space bar is pressed down for debugging touches
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            triggerTouchEvent();
        }
    }

    // ===========================================================
    // Private Methods
    // ===========================================================

    private void OnEnable()
    {
        // Enable the Enhanced Touch system
        EnhancedTouchSupport.Enable();

        // Subscribe to touch events
        UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerDown += HandleFingerDown;

        TouchSimulation.Enable();
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
        // Block touches if UI is being pressed
        if (IsOverUI(finger.screenPosition))
        {
            return;
        }
        else
        {
            triggerTouchEvent();
        }
    }

    private void triggerTouchEvent()
    {
        onTouchEvent.Invoke();
    }
    
    private bool IsOverUI(Vector2 screenPos)
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = screenPos;

        var results = new System.Collections.Generic.List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);

        return results.Count > 0; // true if we hit any UI element
    }
}
