using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Runner
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        private int _score = 0;

        [SerializeField] private TextMeshProUGUI playerScoreInGameOver;
        [SerializeField] private TextMeshProUGUI maxScoreInGameOver;

        
        
        
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
        
        /*public void IncrementScore()
        {
            _score++;
            difficultyLevelController.score = _score;
            difficultyLevelController.IncreaseGameSpeed();
            scoreText.text = _score.ToString();
        }*/
    }
}

