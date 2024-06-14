using UnityEngine;
using UnityEngine.SceneManagement;

namespace Catch
{
    public class GameManager : MonoBehaviour
    {

        [Header("Config")] 
        [SerializeField] private float goodItemSpawnChance;
        [SerializeField] private float badItemSpawnChance;
        [SerializeField] private int startLevel;
        [SerializeField] private int health;
        [SerializeField] private float playerSpeed;
    
        [Header("Controllers")]
        [SerializeField] private PlayerController playerController;
        [SerializeField] private LevelController levelController;
        [SerializeField] private BackgroundController backgroundController;

        [Header("Managers")]
        [SerializeField] private AudioManager audioManager;
        [SerializeField] private ShopManager shopManager;
        [SerializeField] private UIManager uIManager;

        [Header("Systems")] 
        [SerializeField] private SpawnSystem spawnSystem;
        [SerializeField] private ScoreSystem scoreSystem;
        [SerializeField] private HealthSystem healthSystem;
        [SerializeField] private CashSystem cashSystem;
    

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
            healthSystem.Init(health);
            shopManager.Init(cashSystem);
            playerController.Init(_playerInputActions, playerSpeed);
            spawnSystem.Init(healthSystem, scoreSystem, goodItemSpawnChance, badItemSpawnChance);
            levelController.Init(spawnSystem, scoreSystem, startLevel);
            
            backgroundController.ChangeBackground();
        }

        private void SignUpToAllEvents()
        {
            healthSystem.OnNoHPLeft += OnRanOutOfHealth;
            spawnSystem.OnAllSpawnedObjectsGone += OnAllObjectsSpawned;
            scoreSystem.OnLevelCleared += OnLevelCleared;
            scoreSystem.OnLevelFailed += OnLevelFailed;

            uIManager.OnNextLevelRequest += OnNextLevelEnterRequest;
            uIManager.OnOpenShopRequest += OnOpenShopRequest;
            uIManager.OnRestartRequest += OnRestartRequest;
            uIManager.OnMenuExitRequest += OnMenuExitRequest;
        }

        private void OnAllObjectsSpawned()
        {
            scoreSystem.ShowLevelResults();
        }

        private void OnRanOutOfHealth()
        {
            spawnSystem.gameOver = true;
            playerController.EndGamePhase();
            uIManager.ShowOnLosePanel();
        }

        private void OnLevelCleared()
        {
            playerController.EndGamePhase();
            cashSystem.AddMoney((int)scoreSystem.PercentageOfCatchFood * 100);
            uIManager.SetCurrentMoneyAmount(cashSystem.CurrentMoneyAmount);
            uIManager.ShowOnWinPanel();
        }

        private void OnRestartRequest()
        {
            uIManager.HideOnLosePanel();
            uIManager.HideOnWinPanel();
            playerController.StartGamePhase();
            levelController.RestartLevel();
        }

        private void OnMenuExitRequest()
        {
            SceneManager.LoadScene("CatchGameMenu");
        }

        private void OnOpenShopRequest()
        {
            Debug.Log("Shop is closed for technical purpose");
        }

        private void OnNextLevelEnterRequest()
        {
            uIManager.HideOnWinPanel();
            playerController.StartGamePhase();
            levelController.LevelUpAndStart();
            backgroundController.ChangeBackground();
        }

        private void OnLevelFailed()
        {
            playerController.EndGamePhase();
            uIManager.ShowOnLosePanel();
        }
    
    }
}

