using UnityEngine;

public class SnowflakeSpawner : MonoBehaviour
{
    public GameObject snowflakePrefab;
    public float spawnInterval = 1f;
    public float minX = -9f; 
    public float maxX = 10f;
    public float spawnY = 7f; 

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnSnowflake();
            timer = 0f;
        }
    }

    void SpawnSnowflake()
    {
        float randomX = Random.Range(minX, maxX);
        Vector3 spawnPosition = new Vector3(randomX, spawnY, 0);
        Instantiate(snowflakePrefab, spawnPosition, Quaternion.identity);
    }
}
