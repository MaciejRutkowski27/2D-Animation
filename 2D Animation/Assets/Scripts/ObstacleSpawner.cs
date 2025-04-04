using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float spawnRate = 2f;
    public float verticalRange = 3f;
    public float gapSize = 8f; // Distance between top and bottom gingerbreads

    private float timer;
    private Camera mainCam;

    void Start()
    {
        mainCam = Camera.main;
    }

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
        float camRightEdge = mainCam.transform.position.x + mainCam.orthographicSize * mainCam.aspect;

        float yOffset = Random.Range(-verticalRange, verticalRange);
        Vector3 spawnPosition = new Vector3(camRightEdge + 2f, yOffset, 0f);

        GameObject obstacle = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);

        // Optional: auto-adjust spacing if your prefab doesn't already space Top/Bottom
        Transform top = obstacle.transform.Find("GingerTop");
        Transform bottom = obstacle.transform.Find("GingerBottom");
        Transform scoreZone = obstacle.transform.Find("ScoreZone");

        if (top != null && bottom != null)
        {
            top.localPosition = new Vector3(0f, gapSize / 2f, 0f);
            bottom.localPosition = new Vector3(0f, -gapSize / 2f, 0f);
            scoreZone.localPosition = new Vector3(0f , 0f, 0f);
        }
    }
}
