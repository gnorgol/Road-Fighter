using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;       // Texte UI pour le score
    public TMP_Text highScoreText;   // Texte UI pour le high score
    public TMP_Text SpeedText;       // Texte UI pour la vitesse

    private float score = 0f;
    private float highScore = 0f;
    private float InitialSpeed = 3f;

    void Start()
    {
        // Charger le high score sauvegardé
        highScore = PlayerPrefs.GetFloat("HighScore", 0);
        UpdateHighScoreText();
    }

    void Update()
    {
        if (GameManager.Instance.isGameStarted)
        {
            // Augmenter le score au fil du temps
            score += Time.deltaTime * 10;  // Multipliez par 10 pour accélérer l'incrémentation
            UpdateScoreText();
            UpdateSpeedText();

            // Mettre à jour le high score si nécessaire
            if (score > highScore)
            {
                highScore = score;
                UpdateHighScoreText();
                PlayerPrefs.SetFloat("HighScore", highScore);
            }
        }
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + Mathf.RoundToInt(score).ToString();
    }

    void UpdateHighScoreText()
    {
        highScoreText.text = "High Score: " + Mathf.RoundToInt(highScore).ToString();
    }
    //update speed with the initial speed * by the game speed in km/h
    void UpdateSpeedText()
    {
        SpeedText.text = "Speed: " + Mathf.RoundToInt((InitialSpeed + 47) * GameManager.Instance.gameSpeed).ToString() + " km/h";
    }

    public void ResetScore()
    {
        score = 0f;
        UpdateScoreText();
    }
}