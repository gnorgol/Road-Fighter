using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 3f;

    void Update()
    {
        if (GameManager.Instance.isGameStarted)
        {
            float gameSpeed = GameManager.Instance.gameSpeed;
            // Increase speed based on game speed in km/h
            transform.Translate(Vector3.down * speed * gameSpeed * Time.deltaTime);
            if (transform.position.y < -5f)
            {
                Destroy(gameObject);
            }
        }
    }
}