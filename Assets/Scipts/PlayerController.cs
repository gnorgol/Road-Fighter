using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

    // Limites de la route
    public float leftBoundary = -2.5f;
    public float rightBoundary = 2.5f;
    public ScoreManager scoreManager;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;

        // Limiter la position du joueur à la route
        position.x = Mathf.Clamp(position.x, leftBoundary, rightBoundary);

        transform.position = position;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision!");
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Réinitialiser le score
            scoreManager.ResetScore();

            // Optionnel : recharger la scène pour redémarrer le jeu
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}