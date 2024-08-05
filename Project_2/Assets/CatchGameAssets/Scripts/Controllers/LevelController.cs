using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Catch
{
    public class LevelController
    {
        private List<LevelSettings> _levelSettings;

        private LevelSettings _currentLevelSettings;
        
        private SpawnSystem _spawnSystem;
        private ScoreSystem _scoreSystem;
        
        private int _currentLevel;

        private int _eatableToSpawn;

        private float _minCatchPercentage,
            _minSpawnTime,
            _maxSpawnTime;

        public LevelController(List<LevelSettings> levelSettings, SpawnSystem spawnSystem, ScoreSystem scoreSystem)
        {
            _levelSettings = levelSettings;
            _scoreSystem = scoreSystem;
            _spawnSystem = spawnSystem;
        }
        
        public void Init(int currentLevel)
        {
            _currentLevel = currentLevel;

            SetLevelParameters();
        }

        public void LevelUpAndStart()
        {
            _currentLevel++;
            
            SetLevelParameters();
            
            Debug.Log("Welcome to level " + _currentLevel);
        }

        public void RestartLevel()
        {
            SetLevelParameters();
            
            Debug.Log("Try again");
        }

        private void SetLevelParameters()
        {
            _currentLevelSettings = _levelSettings[_currentLevel - 1]; //Adjusting int for proper index usage
            
            _eatableToSpawn = _currentLevelSettings.FoodToSpawn;
            _minSpawnTime = _currentLevelSettings.MinSpawnTime;
            _maxSpawnTime = _currentLevelSettings.MaxSpawnTime;
            _minCatchPercentage = _currentLevelSettings.MinCatchPercentage;
            Physics.gravity = _currentLevelSettings.Gravity;
            
            _spawnSystem.SetParameters(_minSpawnTime, _maxSpawnTime, _eatableToSpawn);
            _scoreSystem.SetParameters(_eatableToSpawn, _minCatchPercentage);
        }
    }
}

