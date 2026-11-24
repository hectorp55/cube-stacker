using System;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    // One instance per subclass (AdsManager, GameCenterManager, ...), so
    // different managers don't treat each other as duplicates.
    private static readonly Dictionary<Type, Singleton> instances = new Dictionary<Type, Singleton>();

    // True on a copy that is being destroyed, so its Start can bail out before
    // Unity finishes destroying it at the end of the frame
    protected bool IsDuplicate { get; private set; }

    // ===========================================================
    // Mono Methods
    // ===========================================================

    public void Awake()
    {
        checkForDuplicateInstances();
    }

    // ===========================================================
    // Private Methods
    // ===========================================================

    private void checkForDuplicateInstances()
    {
        Type type = GetType();

        // Unity's == treats a destroyed object as null, so a stale entry gets replaced
        if (!instances.TryGetValue(type, out Singleton instance) || instance == null)
        {
            instances[type] = this;
        }
        else if (instance != this)
        {
            // Another instance already exists remove this one
            Debug.Log($"Multiple instances of {type} detected in the scene!");
            IsDuplicate = true;
            Destroy(gameObject);
        }
    }
}
