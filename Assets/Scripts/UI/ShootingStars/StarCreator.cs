using UnityEngine;

public class StarCreator : MonoBehaviour
{
    public GameObject startPrefab;

    private float minSpawnInterval = 10f;
    private float maxSpawnInterval = 30f;

    private float minYSpawnPosition = -15f;
    private float maxYSpawnPosition = 15f;

    private float xSpawnPosition = -13.5f;
    private float zSpawnPosition = 0f;

    private float nextSpawnTime;
    private GameCenterManager gameCenter;

    // ===========================================================
    // Mono Methods
    // ===========================================================

    void Start()
    {
        gameCenter = GameObject.FindGameObjectWithTag(Tags.GAMECENTER_MANAGER)?.GetComponent<GameCenterManager>();

        scheduleNextSpawn();
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            if (isShootingStarGenerated())
            {
                spawnPrefab();
                // Count stat of stars
                StatsRecorder.RecordShootingStarSeen();
                // Check acheviement
                int shootingStarCount = Save.GetIntProperty(SaveProperties.ShootingStarsSeen);
                gameCenter.ReportAchievement(Achievements.HundredShootingStars, shootingStarCount/Achievements.ShootingStarsCompleteCount);
            }
            scheduleNextSpawn();
        }
    }

    // ===========================================================
    // Private Methods
    // ===========================================================

    private void scheduleNextSpawn()
    {
        // Determine the next spawn time randomly within the interval
        nextSpawnTime = Time.time + Random.Range(minSpawnInterval, maxSpawnInterval);
    }

    private void spawnPrefab()
    {
        // Random Y position
        float ySpawnPosition = Random.Range(minYSpawnPosition, maxYSpawnPosition);

        // Create the prefab at the specified X, random Y, and Z
        Vector3 spawnPosition = new Vector3(xSpawnPosition, ySpawnPosition, zSpawnPosition);

        // Instiate under parent
        GameObject newStar = Instantiate(startPrefab, transform);
        // Adjust location relative to parent
        newStar.transform.localPosition = spawnPosition;
        newStar.transform.rotation = Quaternion.identity;
    }

    // Only want shooting star to be generated 5% of the time. Want them to be rare.
    private bool isShootingStarGenerated() {
        // Clamp percent to valid range
        float percent = Mathf.Clamp(Constants.PERCENTAGE_CHANCE_OF_SHOOTING_STAR, 0f, 100f);

        float roll = Random.value * 100f; // Random between 0 and 100
        return roll < percent;
    }
}
