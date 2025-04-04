using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreZone : MonoBehaviour
{
    private bool scored = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!scored && other.CompareTag("Player"))
        {
            ScoreManager.Instance.AddScore(1);
            scored = true; // Prevent double scoring on same obstacle
        }
    }
}
