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
        


        public void SetCurrentScore(int currentScore)
        {
            _score = currentScore;
            scoreText.text = "score: " + _score;
        }
        
        public void ShowScoreBoard()
        {
            maxScoreInGameOver.text = $"Max score: {ScoreSystem.Instance.currentRecord}";
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

