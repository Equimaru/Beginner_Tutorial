using System;
using TMPro;
using UnityEngine;

namespace Runner
{
    public class ScoreSystem : MonoBehaviour
    {
        public Action OnRecordBreak;

        private int _score;
        [SerializeField] private TextMeshProUGUI scoreText;
        
        public void IncrementScore()
        {
            _score++;
            scoreText.text = "score: " + _score;
        }
    }
}

