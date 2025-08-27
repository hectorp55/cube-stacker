using UnityEngine;

public class BlockAnimator : MonoBehaviour
{
    private Animator animator;

    // ===========================================================
    // Mono Methods
    // ===========================================================

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // ===========================================================
    // Public Methods
    // ===========================================================

    public void PlayStartUpAnimation()
    {
        PlayAnimation(AnimationNames.PLACED);
    }

    public void PlayDestroyAnimation()
    {
        PlayAnimation(AnimationNames.DESTROYED);
    }

    // ===========================================================
    // Private Methods
    // ===========================================================

    private void PlayAnimation(string animationName)
    {
        if (animator != null)
        {
            animator.SetTrigger(animationName);
        }
        else
        {
            Debug.LogWarning("Animator component not found on " + gameObject.name);
        }
    }
}
