using System;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    private static Singleton instance;

    void Awake()
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

            // Error: another instance already exists
            Debug.LogError($"Multiple instances of {parentType} detected in the scene!");
            throw new System.Exception($"Multiple instances of {parentType} detected!");
        }
    }
}
