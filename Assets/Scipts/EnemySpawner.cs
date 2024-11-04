using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    public GameObject enemyCarPrefab;
    public float spawnInterval = 2f;

    // Limites de la route
    public float leftBoundary = -2.5f;
    public float rightBoundary = 2.5f;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", spawnInterval, spawnInterval);
    }

    void SpawnEnemy()
    {
        float randomX = Random.Range(leftBoundary, rightBoundary);
        Vector3 spawnPosition = new Vector3(randomX, transform.position.y, 0);
        Instantiate(enemyCarPrefab, spawnPosition, Quaternion.identity);
    }
}