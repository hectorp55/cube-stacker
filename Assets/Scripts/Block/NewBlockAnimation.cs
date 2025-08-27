using UnityEngine;

public class NewBlockAnimation : MonoBehaviour
{
    private HangingBlockCheck hangingBlockCheck;
    private BlockAnimator blockAnimator;

    // ===========================================================
    // Mono Methods
    // ===========================================================

    void Awake()
    {
        hangingBlockCheck = GetComponent<HangingBlockCheck>();
        blockAnimator = GetComponent<BlockAnimator>();
    }

    void Start()
    {
        // if block was placed well play animation
        if (hangingBlockCheck.IsBlockUnderneath())
        {
            blockAnimator.PlayStartUpAnimation();
        }
    }
    
}
