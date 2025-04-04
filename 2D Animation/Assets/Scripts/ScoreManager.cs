using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public int score = 0;
    public int highscore = 0;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText; 

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            LoadHighscore();
            UpdateUI();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int value)
    {
        score += value;
        UpdateUI();
    }

    void UpdateUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;

        if (highscoreText != null)
            highscoreText.text = "Highscore: " + highscore;

        if (score > highscore)
        {
            highscore = score;
            SaveHighscore();
        }
    }


    void SaveHighscore()
    {
        PlayerPrefs.SetInt("Highscore", highscore);
        PlayerPrefs.Save();
    }

    void LoadHighscore()
    {
        highscore = PlayerPrefs.GetInt("Highscore", 0);
    }
}
