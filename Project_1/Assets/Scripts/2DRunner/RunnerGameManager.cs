using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RunnerGameManager : MonoBehaviour
{
    public static RunnerGameManager Instance;

    [SerializeField] private GameObject gameOverPanel;

    [SerializeField] private TextMeshProUGUI scoreText;
    private int _score = 0;

    private Button _menuButton;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void GameOver()
    {
        ObstacleSpawner.Instance.gameOver = true;
        StopScrolling();
        gameOverPanel.SetActive(true);
    }
    
    private void StopScrolling()
    {
        TextureScrolling[] scrollingObjects = FindObjectsOfType<TextureScrolling>();

        foreach (TextureScrolling i in scrollingObjects)
        {
            i.isScrolling = false;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("2DRunner");
    }

    public void Menu()
    {
        SceneManager.LoadScene("2DRunnerMenu");
    }

    public void IncrementScore()
    {
        _score++;
        scoreText.text = _score.ToString();
    }
}
