using UnityEngine;

namespace Catch
{
    public class LevelController : MonoBehaviour
    {
        private SpawnSystem _spawnSystem;
        private ScoreSystem _scoreSystem;
        
        private int _currentLevel;

        private int _objectsToSpawn;

        private float _minCatchPercentage,
            _minSpawnTime,
            _maxSpawnTime;

        private Level _level;
        
        private enum Level
        {
            First = 1,
            Second,
            Third,
            Fourth,
            Fifth
        }
        
        public void Init(SpawnSystem spawnSystem, ScoreSystem scoreSystem, int currentLevel)
        {
            _spawnSystem = spawnSystem;
            _scoreSystem = scoreSystem;
            _currentLevel = currentLevel;

            _level = (Level)_currentLevel;
            
            SetLevelParameters();
            
            
        }

        public void LevelUpAndStart()
        {
            _currentLevel++;
            _level = (Level) _currentLevel;
            
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
            switch (_level)
            {
                case Level.First:
                    _objectsToSpawn = 15;
                    _minSpawnTime = 2f;
                    _maxSpawnTime = 2f;
                    _minCatchPercentage = 0.50f;
                    Physics.gravity = new Vector3(0, -5, 0);
                    break;
                case Level.Second:
                    _objectsToSpawn = 20;
                    _minSpawnTime = 1.5f;
                    _maxSpawnTime = 2f;
                    _minCatchPercentage = 0.60f;
                    Physics.gravity = new Vector3(0, -7, 0);
                    break;
                case Level.Third:
                    _objectsToSpawn = 25;
                    _minSpawnTime = 1f;
                    _maxSpawnTime = 2f;
                    _minCatchPercentage = 0.65f;
                    Physics.gravity = new Vector3(0, -9, 0);
                    break;
                case Level.Fourth:
                    _objectsToSpawn = 30;
                    _minSpawnTime = 1f;
                    _maxSpawnTime = 2f;
                    _minCatchPercentage = 0.70f;
                    Physics.gravity = new Vector3(0, -11, 0);
                    break;
                case Level.Fifth:
                    _objectsToSpawn = 30;
                    _minSpawnTime = 0.5f;
                    _maxSpawnTime = 1.5f;
                    _minCatchPercentage = 0.70f;
                    Physics.gravity = new Vector3(0, -11, 0);
                    break;
                default:
                    Debug.LogError("You are trying to load non existent level.");
                    break;
            }
            
            _spawnSystem.SetParameters(_minSpawnTime, _maxSpawnTime, _objectsToSpawn);
            _scoreSystem.SetParameters(_minCatchPercentage);
        }
    }
}

