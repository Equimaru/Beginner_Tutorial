using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Catch
{
    public class MenuController : MonoBehaviour
    {
        [Header("Custom Settings")] 
        [SerializeField] private bool useCustomSettings;
        [SerializeField] private int customLevel;
        [SerializeField] private int customCurrency;
        
        [Inject] private InMenuAdsManager _inMenuAdsManager;
        [Inject] private MainMenuManager _mainMenuManager;
        [Inject] private ShopManager _shopManager;
        
        [SerializeField] private int moneyGainFromAdd;
        [SerializeField] private int amuletPrice;
        [SerializeField] private int moneyAmountInPremiumShop;

        private PlayerSaveSystem _playerSaveSystem;
        
        private bool _isNoAdsActive;
        
        private void Start()
        {
            _playerSaveSystem = new PlayerSaveSystem();
            _playerSaveSystem.Init(useCustomSettings, customLevel, customCurrency);
            
            SignUpToAllEvents();
        }

        private void SignUpToAllEvents()
        {
            _mainMenuManager.OnPlayRequest += Play;
            _mainMenuManager.OnShopVisitRequest += VisitShop;
            _mainMenuManager.OnApplicationExitRequest += Exit;

            _shopManager.OnShopCloseRequest += OnShopCloseRequest;
            
            _shopManager.coinShop.OnItemBuyRequest += OnItemBuyRequest;
            
            _shopManager.premiumShop.OnCoinsPurchased += OnCoinsPurchased;
            _shopManager.premiumShop.OnNoAdsPurchased += OnNoAdsPurchased;
            _shopManager.premiumShop.OnNoAdsIsActive += OnNoAdsIsActive;
            _shopManager.premiumShop.OnVipPassPurchased += OnVipPassPurchased;
            
            _inMenuAdsManager.OnAdWatched += OnAdWatched;
        }

        private void Play()
        {
            _playerSaveSystem.SaveParameters();
            SceneManager.LoadScene("CatchGame");
        }

        private void VisitShop()
        {
            _mainMenuManager.Hide();
            _shopManager.coinShop.RefreshShopPanel(_playerSaveSystem.GetMoneyAmount(), _playerSaveSystem.HasAmulet);
            _shopManager.OpenShop();
        }

        private void Exit()
        {
            _playerSaveSystem.SaveParameters();
#if UNITY_ANDROID && !UNITY_EDITOR
            Application.Quit();
#elif UNITY_EDITOR
            EditorApplication.isPlaying = false;
#endif
        }

        #region CoinShop

        private void OnShopCloseRequest()
        {
            _shopManager.CloseShop();
            _mainMenuManager.Show();
        }

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
                _inMenuAdsManager.OpenAdOfferPanel();
            }
        }

        #endregion

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

        #region Ads

        private void ShowBanner()
        {
            
        }
        
        private void OnAdWatched()
        {
            _playerSaveSystem.AddMoneyAmount(moneyGainFromAdd);
            _shopManager.coinShop.RefreshShopPanel(_playerSaveSystem.GetMoneyAmount(), _playerSaveSystem.HasAmulet);
        }

        #endregion
        
    }
}
