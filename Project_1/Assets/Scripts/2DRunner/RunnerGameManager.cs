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

    [SerializeField] private TextMeshProUGUI playerScoreInGameOver;
    [SerializeField] private TextMeshProUGUI maxScoreInGameOver;

    private CameraControl _cameraControl;
    
    private ButtonScalingUI _menuButtonScalingUI;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        _cameraControl = Camera.main.GetComponent<CameraControl>();
    }

    public void EndPlayPhase()
    {
        Time.timeScale = 1f;
        ObstacleSpawner.Instance.gameOver = true;
        StopScrolling();
        ShowScoreBoard();
        _cameraControl.DoCameraShake();
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

    public void OpenMenu()
    {
        SceneManager.LoadScene("2DRunnerMenu");
    }

    public void IncrementScore()
    {
        _score++;
        DifficultyLevelController.Instance.score = _score;
        DifficultyLevelController.Instance.IncreaseGameSpeed();
        scoreText.text = _score.ToString();
    }

    private void ShowScoreBoard()
    {
        if (PlayerPrefs.HasKey("maxScore"))
        {
            int maxScore = PlayerPrefs.GetInt("maxScore");
            if (maxScore < _score)
            {
                PlayerPrefs.SetInt("maxScore", _score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("maxScore", _score);
        }

        maxScoreInGameOver.text = $"Max score: {PlayerPrefs.GetInt("maxScore")}";
        playerScoreInGameOver.text = $"Your score: {_score}";
    }

    public int GetScore()
    {
        return _score;
    }
}
