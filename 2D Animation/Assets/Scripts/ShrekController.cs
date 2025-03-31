using UnityEngine;

public class ShrekController : MonoBehaviour
{
    public float flapForce = 5f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = Vector2.up * flapForce;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("SHREK IS DEAD 💀");
        Time.timeScale = 0f; // Freezes game
    }
}
