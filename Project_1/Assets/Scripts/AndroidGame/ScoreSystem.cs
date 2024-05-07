using System;
using UnityEngine;

namespace AndroidGame
{
    public class ScoreSystem : MonoBehaviour
    {
        public Action OnFinishScoreReached;
        
        private int _score,
            _scoreToWin;

        public void Init(int scoreToWin)
        {
            _scoreToWin = scoreToWin;
        }
        
        public void IncrementScore()
        {
            _score++;

            if (_score >= _scoreToWin)
            {
                OnFinishScoreReached?.Invoke();
            }
        }
    }
}
