using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float spawnRate = 2f;
    public float verticalRange = 3f;
    public float spawnXPosition = 15f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            SpawnObstacle();
            timer = 0f;
        }
    }

    void SpawnObstacle()
    {
        float yOffset = Random.Range(-verticalRange, verticalRange);
        Vector3 spawnPosition = new Vector3(spawnXPosition, yOffset, 0f);
        Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
    }
}
