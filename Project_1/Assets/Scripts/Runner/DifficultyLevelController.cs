using System;
using UnityEngine;

namespace Runner
{
    public class DifficultyLevelController : MonoBehaviour
    {
        public Action OnDifficultyIncrease;
        
        private SpawnSystem _spawnSystem;

        private float _gameDifficultyCap;

        public int score;
        private float _gameSpeed;

        public void Init(int maxDifficultyScore)
        {
            _gameDifficultyCap = maxDifficultyScore;
        }
        
        public void IncreaseGameSpeed()
        {
            if (score <= _gameDifficultyCap)
            {
                OnDifficultyIncrease?.Invoke();
            }
        }
    }
}

