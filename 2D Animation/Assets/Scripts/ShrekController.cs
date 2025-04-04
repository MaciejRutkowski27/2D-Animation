using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ShrekController : MonoBehaviour
{
    public float flapForce = 5f;
    public GameObject gameOverText;
    public AudioClip jumpSound;

    private Rigidbody2D rb;
    private AudioSource audioSource;
    public bool isDead { get; private set; } = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();

        if (gameOverText != null)
            gameOverText.SetActive(false);
    }

    void Update()
    {
        if (!isDead && Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = Vector2.up * flapForce;

            audioSource.PlayOneShot(jumpSound);
            
        }

        if (isDead && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1f;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Shrek just got dunked 💀");
        isDead = true;
        Time.timeScale = 0f;

        if (gameOverText != null)
            gameOverText.SetActive(true);
    }
}
