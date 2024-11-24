using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

    // Limites de la route
    public float leftBoundary = -2.5f;
    public float rightBoundary = 2.5f;
    public ScoreManager scoreManager;
    public InputActionReference MoveAction;
    private void OnEnable()
    {
        MoveAction.action.Enable();
    }

    private void OnDisable()
    {
        MoveAction.action.Disable();
    }
    void Update()
    {
        Vector2 inputVector = MoveAction.action.ReadValue<Vector2>();
        Debug.Log(inputVector);

        Vector3 position = transform.position;
        position.x += inputVector.x * speed * Time.deltaTime;

        // Limiter la position du joueur � la route
        position.x = Mathf.Clamp(position.x, leftBoundary, rightBoundary);

        transform.position = position;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision!");
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // R�initialiser le score
            scoreManager.ResetScore();
            // Recharger la sc�ne
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}