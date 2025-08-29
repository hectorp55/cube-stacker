using UnityEngine;

public class StarCreator : MonoBehaviour
{
    public GameObject startPrefab;

    private float minSpawnInterval = 1f;
    private float maxSpawnInterval = 3f;

    private float minYSpawnPosition = -15f;
    private float maxYSpawnPosition = 15f;

    private float xSpawnPosition = -13.5f;
    private float zSpawnPosition = 0f;

    private float nextSpawnTime;

    // ===========================================================
    // Mono Methods
    // ===========================================================

    void Start()
    {
        ScheduleNextSpawn();
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnPrefab();
            ScheduleNextSpawn();
        }
    }

    // ===========================================================
    // Private Methods
    // ===========================================================

    void ScheduleNextSpawn()
    {
        // Determine the next spawn time randomly within the interval
        nextSpawnTime = Time.time + Random.Range(minSpawnInterval, maxSpawnInterval);
    }

    void SpawnPrefab()
    {
        // Random Y position
        float ySpawnPosition = Random.Range(minYSpawnPosition, maxYSpawnPosition);

        // Create the prefab at the specified X, random Y, and Z
        Vector3 spawnPosition = new Vector3(xSpawnPosition, ySpawnPosition, zSpawnPosition);

        // Instiate under parent
        GameObject newStar = Instantiate(startPrefab, transform);
        // Adjust location relative to parent
        newStar.transform.localPosition = spawnPosition;
    }
}
