using UnityEngine;

public class BlockDestroyer : MonoBehaviour
{
    // The object to measure distance from
    private GameObject target;

    // The max allowed distance before destroying this object
    private float maxDistance = 25f;

    // ===========================================================
    // Mono Methods
    // ===========================================================

    void Awake()
    {
        // Target is always main camera
        target = Camera.main.gameObject;
    }

    void Update()
    {
        if (target == null) return;

        float distance = Vector3.Distance(transform.position, target.transform.position);

        if (distance > maxDistance)
        {
            Destroy(gameObject);
        }
    }
}
