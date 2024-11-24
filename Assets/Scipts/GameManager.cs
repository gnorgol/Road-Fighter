using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public float initialGameSpeed = 5f;
    public float gameSpeedIncrease = 0.1f;
    public float spawnInterval = 2f;
    private float spawnTimer = 0f;
    public float gameSpeed { get; private set; }

    public bool isGameStarted { get; private set; }

    public Button startButton;

    public EnemySpawner enemySpawner;

    void Awake()
    {
        if (Instance != null)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    private void Start()
    {
        startButton.onClick.AddListener(StartGame);
        gameSpeed = initialGameSpeed;
    }
    void Update()
    {
        if (isGameStarted)
        {
            gameSpeed += gameSpeedIncrease * Time.deltaTime;

            spawnTimer += Time.deltaTime;
            if (spawnTimer >= spawnInterval)
            {
                enemySpawner.SpawnEnemy();
                spawnTimer = 0f;
            }
        }
    }
    private void StartGame()
    {
        isGameStarted = true;
        startButton.gameObject.SetActive(false);
    }
}