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
        [SerializeField] private int moneyAmountInPremiumShop;

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
        [Inject] private InGameMenuManager _inGameMenuManager;
        [Inject] private InGameAdsManager _inGameAdsManager;
        [Inject] private LevelPlayAds _levelPlayAds;

        #endregion

        #region Systems

        [Header("Systems")] 
        [Inject] private SpawnSystem _spawnSystem;
        [Inject] private ScoreSystem _scoreSystem;
        [Inject] private HealthSystem _healthSystem;

        private PlayerSaveSystem _playerSaveSystem;

        #endregion

        private PlayerInputActions _playerInputActions;

        private bool _isNoAdsActive;
        
        private LevelStateType _currentLevelStateType; // Make state change
        
        private void Start()
        {
            _playerInputActions = new PlayerInputActions();
            _playerInputActions.Player.Enable();

            _playerSaveSystem = new PlayerSaveSystem();
            _playerSaveSystem.Init(useCustomSettings, customLevel, customCurrency);
        
            _inGameMenuManager.InitButtons();
            
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

            _inGameMenuManager.OnNextLevelEnterRequest += NextLevelEnterFromWinPanel;
            _inGameMenuManager.OnShopVisitRequest += VisitShop;
            _inGameMenuManager.OnRestartRequest += RestartFromWinPanel;
            _inGameMenuManager.OnMenuExitRequest += MenuExitFromWinPanel;

            _shopManager.OnShopCloseRequest += OnShopCloseRequest;
            
            _shopManager.coinShop.OnItemBuyRequest += OnItemBuyRequest;
            
            _shopManager.premiumShop.OnCoinsPurchased += OnCoinsPurchased;
            _shopManager.premiumShop.OnNoAdsPurchased += OnNoAdsPurchased;
            _shopManager.premiumShop.OnNoAdsIsActive += OnNoAdsIsActive;
            _shopManager.premiumShop.OnVipPassPurchased += OnVipPassPurchased;
            
            _inGameAdsManager.OnAdWatched += OnAdWatched;
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
            _inGameMenuManager.SetMoneyAmount(_playerSaveSystem.GetMoneyAmount());
            _inGameMenuManager.Show(LevelStateType.Cleared);
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
                _inGameMenuManager.Show(LevelStateType.Failed);
            }
        }
        
        private void OnLevelFailed()
        {
            StopGamePhase();
            _inGameMenuManager.Show(LevelStateType.Failed);
        }
        
        #endregion

        #region UIInteraction

        private void NextLevelEnterFromWinPanel()
        {
            _inGameMenuManager.Hide();
            StartGamePhase();
            _levelController.LevelUpAndStart();
            _backgroundController.ChangeBackground();
            
            _playerSaveSystem.IncreaseCurrentLevel();
        }
        
        private void VisitShop()
        {
            _inGameMenuManager.Hide();
            _shopManager.coinShop.RefreshShopPanel(_playerSaveSystem.GetMoneyAmount(), _playerSaveSystem.HasAmulet);
            _shopManager.OpenShop();
        }
        
        private void OnShopCloseRequest()
        {
            _shopManager.CloseShop();
            _inGameMenuManager.Show(LevelStateType.Cleared);
        }
        
        private void RestartFromWinPanel()
        {
            _inGameMenuManager.Hide();
            StartGamePhase();
            _levelController.RestartLevel();
        }

        private void MenuExitFromWinPanel()
        {
            _playerSaveSystem.SaveParameters();
            
            SceneManager.LoadScene("CatchGame_Menu");
        }
        
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
                _shopManager.coinShop.RefreshShopPanel(_playerSaveSystem.GetMoneyAmount(), _playerSaveSystem.HasAmulet);
            }
            else
            {
                _inGameAdsManager.OpenAdOfferPanel();
            }
        }

        #region PremiumShop

        private void OnVipPassPurchased()
        {
            Debug.Log("VipPass purchased");
        }

        private void OnNoAdsPurchased()
        {
            Debug.Log("NoAds purchased");
            _isNoAdsActive = true;
        }

        private void OnNoAdsIsActive()
        {
            Debug.Log("NoAds is active");
            _isNoAdsActive = true;
        }

        private void OnCoinsPurchased()
        {
            _playerSaveSystem.AddMoneyAmount(moneyAmountInPremiumShop);
            _shopManager.coinShop.RefreshShopPanel(_playerSaveSystem.GetMoneyAmount(), _playerSaveSystem.HasAmulet);
            Debug.Log("Coins purchased");
        }

        #endregion
        
        #endregion

        #region Ads

        private void OnAdWatched()
        {
            _playerSaveSystem.AddMoneyAmount(moneyGainFromAdd);
            _shopManager.coinShop.RefreshShopPanel(_playerSaveSystem.GetMoneyAmount(), _playerSaveSystem.HasAmulet);
        }

        #endregion
    }
}