using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private static BackgroundMusic instance;

    // ===========================================================
    // Mono Methods
    // ===========================================================

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            // Another instance exists, destroy this one
            Destroy(gameObject);
            return;
        }

        // This is the first instance
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
