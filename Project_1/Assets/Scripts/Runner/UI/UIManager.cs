using System;
using TMPro;
using UnityEngine;

namespace Runner
{
    public class UIManager : MonoBehaviour
    {
        public Action OnMenuExitRequest;
        public Action OnRestartRequest;
        
        
        [SerializeField] private TextMeshProUGUI scoreText;
        private int _score = 0;

        [SerializeField] private TextMeshProUGUI playerScoreInGameOver;
        [SerializeField] private TextMeshProUGUI maxScoreInGameOver;
        [SerializeField] private GameObject gameOverPanel;


        public void GetCurrentScore(int currentScore)
        {
            _score = currentScore;
        }
        
        public void ShowScoreBoard()
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

        public void ShowGameOverPanel()
        {
            gameOverPanel.SetActive(true);
        }

        public void RequestMenuExit()
        {
            OnMenuExitRequest?.Invoke();
        }

        public void RequestRestart()
        {
            OnRestartRequest?.Invoke();
        }
    }
}

