using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int lives;
    public int score;

    public Text livesText;
    public Text scoreText;

    public bool gameOver; // false durumda

    [SerializeField]
    GameObject gameOverPanel;

    private void Start()
    {
        livesText.text = "Lives: " + lives.ToString();
        scoreText.text = "Score: " + score.ToString();  

        gameOverPanel.GetComponent<RectTransform>().localScale = Vector3.zero;
        gameOverPanel.GetComponent<CanvasGroup>().alpha = 0;
    }

    public void UpdateLives(int countLive)
    {
        lives += countLive;
        
        if (lives <= 0)
        {
            lives = 0;
            GameOver();
        }

        livesText.text = "Lives: " + lives.ToString();
    }

    public void UpdateScore(int _score)
    {
        this.score += _score;
        scoreText.text = "Score: " + score.ToString();
    }

    void GameOver()
    {
        gameOver = true;

        gameOverPanel.GetComponent<CanvasGroup>().DOFade(1, 0.2f); // DOFade => alphasını değiştirmek demek.
        gameOverPanel.GetComponent<RectTransform>().DOScale(1, 0.2f); // Scale ayarlarını değiştirir.

    }

    public void ReStart()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void QuitApp()
    {
        Application.Quit();
    }

}
