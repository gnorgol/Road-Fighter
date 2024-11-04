using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 3f;

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
}