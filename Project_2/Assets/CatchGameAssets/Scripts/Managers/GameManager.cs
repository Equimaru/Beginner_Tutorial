using UnityEngine;
using UnityEngine.SceneManagement;

namespace Catch
{
    public class GameManager : MonoBehaviour
    {
        [Header("Custom Settings")] 
        [SerializeField] private bool useCustomSettings;
        [SerializeField] private int customLevel;

        #region Config

        [Header("Config")] 
        [SerializeField] private float goodItemSpawnChance;
        [SerializeField] private float badItemSpawnChance;
        [SerializeField] private int health;
        [SerializeField] private float playerSpeed;
        [SerializeField] private int amuletPrice;

        #endregion

        #region Controllers

        [Header("Controllers")]
        [SerializeField] private PlayerController playerController;
        [SerializeField] private LevelController levelController;
        [SerializeField] private BackgroundController backgroundController;

        #endregion

        #region Managers

        [Header("Managers")]
        [SerializeField] private AudioManager audioManager;
        [SerializeField] private ShopManager shopManager;
        [SerializeField] private UIManager uIManager;

        #endregion

        #region Systems

        [Header("Systems")] 
        [SerializeField] private SpawnSystem spawnSystem;
        [SerializeField] private ScoreSystem scoreSystem;
        [SerializeField] private HealthSystem healthSystem;

        private PlayerSaveSystem _playerSaveSystem;

        #endregion


        private PlayerInputActions _playerInputActions;
    
        private void Start()
        {
            _playerInputActions = new PlayerInputActions();
            _playerInputActions.Player.Enable();

            _playerSaveSystem = new PlayerSaveSystem();
            _playerSaveSystem.Init(useCustomSettings, customLevel);
        
            InitAll();
            SignUpToAllEvents();
        }

        private void StopGamePhase()
        {
            healthSystem.ClearHealthBar();
            playerController.EndGamePhase();
            spawnSystem.gameOver = true;
        }
        
        private void StartGamePhase()
        {
            healthSystem.SetHP();
            playerController.StartGamePhase();
            spawnSystem.gameOver = false;
        }

        private void InitAll()
        {
            healthSystem.Init(health);
            playerController.Init(_playerInputActions, playerSpeed);
            spawnSystem.Init(healthSystem, scoreSystem, goodItemSpawnChance, badItemSpawnChance);
            levelController.Init(spawnSystem, scoreSystem, _playerSaveSystem.GetCurrentLevel());
            
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
            
            shopManager.OnAmuletBuyRequest += OnAmuletBuyRequest;
            shopManager.OnCloseShopPanelRequest += OnCloseShopPanelRequest;
        }

        private void OnCloseShopPanelRequest()
        {
            shopManager.CloseShop();
            
            uIManager.ShowOnWinPanel();
        }

        private void OnAmuletBuyRequest()
        {
            if (_playerSaveSystem.CheckForEnoughMoneyAmount(amuletPrice))
            {
                _playerSaveSystem.TryAddAmuletToPocket();
                shopManager.SetMoneyAmountText(_playerSaveSystem.GetMoneyAmount());
            }
        }

        private void OnAllObjectsSpawned()
        {
            scoreSystem.ShowLevelResults();
        }

        private void OnRanOutOfHealth()
        {
            if (_playerSaveSystem.TryUseAmuletFromPocket())
            {
                healthSystem.SetHP();
                Debug.Log("Amulet was used!");
            }
            else
            {
                StopGamePhase();
                uIManager.ShowOnLosePanel();
            }
        }

        private void OnLevelCleared()
        {
            StopGamePhase();
            _playerSaveSystem.AddMoneyAmount((int)scoreSystem.PercentageOfCatchFood * 100);
            uIManager.SetCurrentMoneyAmount(_playerSaveSystem.GetMoneyAmount());
            uIManager.ShowOnWinPanel();
        }

        private void OnRestartRequest()
        {
            uIManager.HideOnLosePanel();
            uIManager.HideOnWinPanel();
            StartGamePhase();
            levelController.RestartLevel();
        }

        private void OnMenuExitRequest()
        {
            _playerSaveSystem.OnMenuExit();
            
            SceneManager.LoadScene("CatchGameMenu");
        }

        private void OnOpenShopRequest()
        {
            uIManager.HideOnWinPanel();
            
            shopManager.SetMoneyAmountText(_playerSaveSystem.GetMoneyAmount());
            shopManager.OpenShop();
        }

        private void OnNextLevelEnterRequest()
        {
            uIManager.HideOnWinPanel();
            StartGamePhase();
            levelController.LevelUpAndStart();
            backgroundController.ChangeBackground();
            
            _playerSaveSystem.IncreaseCurrentLevel();
        }

        private void OnLevelFailed()
        {
            StopGamePhase();
            uIManager.ShowOnLosePanel();
        }
    }
}

