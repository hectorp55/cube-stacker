using System;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    private static Singleton instance;

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
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Type parentType = this.GetType().BaseType;

            // Another instance already exists remove this one
            Debug.Log($"Multiple instances of {parentType} detected in the scene!");
            Destroy(gameObject);
        }
    }
}
