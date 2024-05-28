using UnityEngine;

namespace Catch
{
    public class GameManager : MonoBehaviour
    {

        [Header("Config")] 
        [SerializeField] private int startLevel;
        [SerializeField] private int health;
        [SerializeField] private float playerSpeed;
        [SerializeField] private float minSpawnTime,
            maxSpawnTime;
    
        [Header("Controllers")]
        [SerializeField] private PlayerController playerController;
        [SerializeField] private LevelController levelController;

        [Header("Managers")]
        [SerializeField] private AudioManager audioManager;

        [Header("Systems")] 
        [SerializeField] private SpawnSystem spawnSystem;
        [SerializeField] private ScoreSystem scoreSystem;
        [SerializeField] private HealthSystem healthSystem;
    

        private PlayerInputActions _playerInputActions;
    
    
        private void Start()
        {
            _playerInputActions = new PlayerInputActions();
            _playerInputActions.Player.Enable();
        
            InitAll();
            SignUpToAllEvents();
        }

        private void InitAll()
        {
            levelController.Init(spawnSystem, scoreSystem, startLevel);
            playerController.Init(_playerInputActions, playerSpeed);
            spawnSystem.Init(healthSystem, scoreSystem);
            healthSystem.Init(health);
        }

        private void SignUpToAllEvents()
        {
            healthSystem.OnNoHPLeft += OnRanOutOfHealth;
            spawnSystem.OnAllObjectsSpawned += OnAllObjectsSpawned;
            scoreSystem.OnLevelCleared += OnLevelCleared;
            scoreSystem.OnLevelFailed += OnLevelFailed;
        }

        private void OnAllObjectsSpawned()
        {
            scoreSystem.StartSLRCoroutine();
        }

        private void OnRanOutOfHealth()
        {
            spawnSystem.gameOver = true;
            playerController.EndGamePhase();
            //Show lose panel
        }

        private void OnLevelCleared()
        {
            Debug.Log("Yeeeey");
        }

        private void OnLevelFailed()
        {
            Debug.Log("Fuck");
        }
    
    }
}

