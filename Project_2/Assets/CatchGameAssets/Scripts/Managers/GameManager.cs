using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;

namespace Catch
{
    public class GameManager : MonoBehaviour
    {

        [Header("Config")] 
        [SerializeField] private int health;
        [SerializeField] private float playerSpeed;
        [SerializeField] private float minSpawnTime,
            maxSpawnTime;
    
        [Header("Controllers")]
        [SerializeField] private PlayerController playerController;
        [SerializeField] private DifficultyController difficultyController;

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
            playerController.Init(_playerInputActions, playerSpeed);
            spawnSystem.Init(difficultyController, healthSystem, scoreSystem, minSpawnTime, maxSpawnTime);
            scoreSystem.Init();
            healthSystem.Init(health);
        }

        private void SignUpToAllEvents()
        {
            healthSystem.OnRanOutOfHealth += OnRanOutOfHealth;
        }

        private void OnRanOutOfHealth()
        {
            spawnSystem.gameOver = true;
            playerController.gameOver = true;
        }
    
    }
}

