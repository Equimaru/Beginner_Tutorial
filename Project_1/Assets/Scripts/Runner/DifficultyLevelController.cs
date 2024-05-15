using System;
using UnityEngine;

namespace Runner
{
    public class DifficultyLevelController : MonoBehaviour
    {
        public Action OnDifficultyIncrease;
        
        private SpawnSystem _spawnSystem;

        [SerializeField] private float gameDifficultyCap;

        public int score;
        private float _gameSpeed;

        public void IncreaseGameSpeed()
        {
            if (score <= gameDifficultyCap)
            {
                OnDifficultyIncrease?.Invoke();
            }
        }
    }
}

