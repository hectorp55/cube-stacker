using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Blocks;

    private BlockController blockController;

    void Awake()
    {
        blockController = Blocks.GetComponent<BlockController>();
    }

    void Start()
    {
        StartGame();
    }

    void Update()
    {
        
    }

    // ===========================================================
    // Public Methods
    // ===========================================================


    // ===========================================================
    // Private Methods
    // ===========================================================

    private void StartGame()
    {
        blockController.StartStepping();
    }
}
