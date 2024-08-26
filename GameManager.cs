using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject startPanel;
    public GameObject gameOverPanel;
    public Text finalScoreText;
    public Text scoreText;
    
    private int score;

    private void Awake()
    {
        instance = this;
        ShowStartScreen();
    }

    public void StartGame()
    {
        score = 0;
        UpdateScore();
        startPanel.SetActive(false);
        gameOverPanel.SetActive(false);
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        finalScoreText.text = "Final Score: " + score.ToString();
    }

    public void IncreaseScore()
    {
        score++;
        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void ShowStartScreen()
    {
        startPanel.SetActive(true);
        gameOverPanel.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
