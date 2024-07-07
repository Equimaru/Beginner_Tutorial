using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Catch
{
    public class GameManager : MonoBehaviour
    {
        [Header("Custom Settings")] 
        [SerializeField] private bool useCustomSettings;
        [SerializeField] private int customLevel;
        [SerializeField] private int customCurrency;

        #region Config

        [Header("Config")] 
        [SerializeField] private float goodItemSpawnChance;
        [SerializeField] private float badItemSpawnChance;
        [SerializeField] private float playerSpeed;
        [SerializeField] private int health;
        [SerializeField] private int amuletPrice;
        [SerializeField] private int moneyGainFromAdd;

        #endregion

        #region Controllers

        [Header("Controllers")]
        [Inject] private PlayerController _playerController;
        [Inject] private LevelController _levelController;
        [Inject] private BackgroundController _backgroundController;

        #endregion

        #region Managers

        [Header("Managers")]
        [Inject] private AudioManager _audioManager;
        [Inject] private ShopManager _shopManager;
        [Inject] private UIManager _uIManager;
        [Inject] private AdManager _adManager;
        [Inject] private LevelPlayAdsManager _levelPlayAdsManager;

        #endregion

        #region Systems

        [Header("Systems")] 
        [Inject] private SpawnSystem _spawnSystem;
        [Inject] private ScoreSystem _scoreSystem;
        [Inject] private HealthSystem _healthSystem;

        private PlayerSaveSystem _playerSaveSystem;

        #endregion

        private PlayerInputActions _playerInputActions;
        
        private void Start()
        {
            _playerInputActions = new PlayerInputActions();
            _playerInputActions.Player.Enable();

            _playerSaveSystem = new PlayerSaveSystem();
            _playerSaveSystem.Init(useCustomSettings, customLevel, customCurrency);
        
            InitAll();
            SignUpToAllEvents();
        }

        private void StopGamePhase()
        {
            _healthSystem.ClearHealthBar();
            _playerController.EndGamePhase();
            _spawnSystem.gameOver = true;
        }
        
        private void StartGamePhase()
        {
            _healthSystem.SetHP();
            _playerController.StartGamePhase();
            _spawnSystem.gameOver = false;
        }

        private void InitAll()
        {
            _healthSystem.Init(health);
            _playerController.Init(_playerInputActions, playerSpeed);
            _spawnSystem.Init(goodItemSpawnChance, badItemSpawnChance);
            _levelController.Init(_playerSaveSystem.GetCurrentLevel());
            
            _backgroundController.ChangeBackground();
        }

        private void SignUpToAllEvents()
        {
            _healthSystem.OnNoHPLeft += OnRanOutOfHealth;
            
            _spawnSystem.OnAllSpawnedObjectsGone += OnAllObjectsSpawned;
            
            _scoreSystem.OnLevelCleared += OnLevelCleared;
            _scoreSystem.OnLevelFailed += OnLevelFailed;

            _uIManager.winPanel.OnNextLevelEnterRequest += NextLevelEnterFromWinPanel;
            _uIManager.winPanel.OnShopVisitRequest += ShopVisitFromWinPanel;
            _uIManager.winPanel.OnRestartRequest += RestartFromWinPanel;
            _uIManager.winPanel.OnMenuExitRequest += MenuExitFromWinPanel;

            _uIManager.losePanel.OnShopVisitRequest += ShopVisitFromLosePanel;
            _uIManager.losePanel.OnRestartRequest += RestartFromLosePanel;
            _uIManager.losePanel.OnMenuExitRequest += MenuExitFromLosePanel;

            _shopManager.OnItemBuyRequest += OnItemBuyRequest;
            
            _adManager.OnAdWatched += OnAdWatched;
        }

        #region GameLoop

        private void OnAllObjectsSpawned()
        {
            _scoreSystem.ShowLevelResults();
        }
        
        private void OnLevelCleared()
        {
            StopGamePhase();
            _playerSaveSystem.AddMoneyAmount((int)(_scoreSystem.PercentageOfCatchFood * 100));
            _uIManager.winPanel.SetMoneyAmount(_playerSaveSystem.GetMoneyAmount());
            _uIManager.winPanel.Show();
        }
        
        private void OnRanOutOfHealth()
        {
            if (_playerSaveSystem.TryUseAmuletFromPocket())
            {
                _healthSystem.SetHP();
                Debug.Log("Amulet was used!");
            }
            else
            {
                StopGamePhase();
                _uIManager.losePanel.Show();
            }
        }
        
        private void OnLevelFailed()
        {
            StopGamePhase();
            _uIManager.losePanel.Show();
        }
        
        #endregion

        #region UIInteraction

        #region WinPanel

        private void NextLevelEnterFromWinPanel()
        {
            _uIManager.winPanel.Hide();
            StartGamePhase();
            _levelController.LevelUpAndStart();
            _backgroundController.ChangeBackground();
            
            _playerSaveSystem.IncreaseCurrentLevel();
        }
        
        private async void ShopVisitFromWinPanel()
        {
            _uIManager.winPanel.Hide();
            _shopManager.RefreshShopPanel(_playerSaveSystem.GetMoneyAmount(), _playerSaveSystem.HasAmulet);
            await _shopManager.VisitShop();
            _uIManager.winPanel.Show();
        }
        
        private void RestartFromWinPanel()
        {
            _uIManager.winPanel.Hide();
            StartGamePhase();
            _levelController.RestartLevel();
        }

        private void MenuExitFromWinPanel()
        {
            _playerSaveSystem.OnMenuExit();
            
            SceneManager.LoadScene("CatchGameMenu");
        }
        
        #endregion

        #region LosePanel

        private async void ShopVisitFromLosePanel()
        {
            _uIManager.losePanel.Hide();
            _shopManager.RefreshShopPanel(_playerSaveSystem.GetMoneyAmount(), _playerSaveSystem.HasAmulet);
            await _shopManager.VisitShop();
            _uIManager.losePanel.Show();
        }
        
        private void RestartFromLosePanel()
        {
            _uIManager.losePanel.Hide();
            StartGamePhase();
            _levelController.RestartLevel();
        }

        private void MenuExitFromLosePanel()
        {
            _playerSaveSystem.OnMenuExit();
            
            SceneManager.LoadScene("CatchGameMenu");
        }

        #endregion

        #endregion

        #region Shop

        private void OnItemBuyRequest(ShopItemType item) //Rework to ID system
        {
            switch (item)
            {
                case ShopItemType.Amulet:
                    AmuletPurchaseAttempt();
                    break;
            }
        }
        
        private void AmuletPurchaseAttempt()
        {
            if (_playerSaveSystem.CheckForEnoughMoneyAmount(amuletPrice))
            {
                _playerSaveSystem.TryAddAmuletToPocket();
                _shopManager.RefreshShopPanel(_playerSaveSystem.GetMoneyAmount(), _playerSaveSystem.HasAmulet);
            }
            else
            {
                _adManager.OpenAdOfferPanel();
            }
        }

        #endregion

        #region Ads

        private void OnAdWatched()
        {
            _playerSaveSystem.AddMoneyAmount(moneyGainFromAdd);
            _shopManager.RefreshShopPanel(_playerSaveSystem.GetMoneyAmount(), _playerSaveSystem.HasAmulet);
        }

        #endregion
    }
}