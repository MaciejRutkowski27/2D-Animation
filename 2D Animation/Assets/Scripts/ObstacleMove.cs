using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    public float speed = 2f;

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        // Destroy if off screen
        if (transform.position.x < -15f)
        {
            Destroy(gameObject);
        }
    }
}
