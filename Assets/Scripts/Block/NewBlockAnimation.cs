using UnityEngine;

public class NewBlockAnimation : MonoBehaviour
{
    // Reference to the Animator component
    private Animator animator;
    private HangingBlockCheck hangingBlockCheck;


    // ===========================================================
    // Mono Methods
    // ===========================================================

    void Awake()
    {
        animator = GetComponent<Animator>();
        hangingBlockCheck = GetComponent<HangingBlockCheck>();
    }

    void Start()
    {
        // if block was placed well play animation
        if (hangingBlockCheck.IsBlockUnderneath())
        {
            playStartUpAnimation();
        }
    }

    // ===========================================================
    // Private Methods
    // ===========================================================

    // Method you can call to play the animation
    public void playStartUpAnimation()
    {
        if (animator != null)
        {
            animator.SetTrigger(AnimationNames.PLACED);
        }
        else
        {
            Debug.LogWarning("Animator component not found on " + gameObject.name);
        }
    }
}
