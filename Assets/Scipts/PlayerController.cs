using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

    // Limites de la route
    public float leftBoundary = -2.5f;
    public float rightBoundary = 2.5f;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;

        // Limiter la position du joueur à la route
        position.x = Mathf.Clamp(position.x, leftBoundary, rightBoundary);

        transform.position = position;
    }
}