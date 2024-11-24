using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyCarPrefab;


    // Limites de la route
    public float leftBoundary = -2.5f;
    public float rightBoundary = 2.5f;
    public void SpawnEnemy()
    {
        float randomX = Random.Range(leftBoundary, rightBoundary);
        Vector3 spawnPosition = new Vector3(randomX, transform.position.y, 0);
        Instantiate(enemyCarPrefab, spawnPosition, Quaternion.identity);
    }
}