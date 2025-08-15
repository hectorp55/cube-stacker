using UnityEngine;

public class HangingBlockCheck : MonoBehaviour
{
    // How far to check downwards
    public float checkDistance = 1.5f; // TODO: match with step constants
    public LayerMask layerMask = Physics.DefaultRaycastLayers;

    private GameManager gameManager;

    void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    void Start()
    {
        if (!isBlockUnderneath())
        {
            gameManager.BlockMissed();
            // TODO: hide the placer block
        }
    }

    // ===========================================================
    // Public Methods
    // ===========================================================


    // ===========================================================
    // Private Methods
    // ===========================================================

    bool isBlockUnderneath()
    {
        // Create a ray starting from the object's position going down
        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hit;

        // Perform the raycast
        if (Physics.Raycast(ray, out hit, checkDistance, layerMask))
        {
            Debug.Log("Object below: " + hit.collider.name);
            return true;
        }
        else
        {
            Debug.Log("No object detected below.");
            return false;
        }
    }

}

