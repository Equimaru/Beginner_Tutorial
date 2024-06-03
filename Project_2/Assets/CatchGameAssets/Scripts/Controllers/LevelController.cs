using UnityEngine;

namespace Catch
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] private LevelSettings lvl_1;
        [SerializeField] private LevelSettings lvl_2;
        [SerializeField] private LevelSettings lvl_3;
        [SerializeField] private LevelSettings lvl_4;
        [SerializeField] private LevelSettings lvl_5;

        private LevelSettings _currentLevelSettings;
        
        private SpawnSystem _spawnSystem;
        private ScoreSystem _scoreSystem;
        
        private int _currentLevel;

        private int _eatableToSpawn;

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
                    _currentLevelSettings = lvl_1;
                    break;
                case Level.Second:
                    _currentLevelSettings = lvl_2;
                    break;
                case Level.Third:
                    _currentLevelSettings = lvl_3;
                    break;
                case Level.Fourth:
                    _currentLevelSettings = lvl_4;
                    break;
                case Level.Fifth:
                    _currentLevelSettings = lvl_5;
                    break;
                default:
                    Debug.LogError("You are trying to load non existent level.");
                    break;
            }
            
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

