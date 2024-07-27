using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Catch
{
    public class ShopManagerView : MonoBehaviour
    {
        #region Actions

        public Action OnCoinShopTabPressed;
        public Action OnPremiumShopTabPressed;
        public Action OnCoinsPurchaseButtonPressed;
        public Action OnNoAdsPurchaseButtonPressed;
        public Action OnVipPassButtonPressed;
        public Action OnAmuletPurchaseButtonPressed;
        public Action OnShopCloseButtonPressed;

        #endregion
        
        
        public Button premiumShopTab;
        public Button coinShopTab;

        public Button shopCloseButton;

        public GameObject premiumShopPanel;
        public GameObject coinShopPanel;
        
        [Inject] public CoinShop coinShop;
        [Inject] public PremiumShop premiumShop;

        [Header("Premium panel")] 
        public Button coinsPurchaseButton;
        public Button noAdsPurchaseButton;
        public Button vipPassPurchaseButton;

        [Header("Coins panel")] 
        public Button amuletPurchaseButton; // Switch to item1,item2 e.t.c.

        public TextMeshProUGUI currentCoinsAmountText;
        
        private void Start()
        {
            premiumShopTab.onClick.AddListener(PremiumShopTabPressed);
            coinShopTab.onClick.AddListener(CoinShopTabPressed);
            
            shopCloseButton.onClick.AddListener(ShopCloseButtonPressed);
            
            coinsPurchaseButton.onClick.AddListener(CoinPurchaseButtonPressed);
            noAdsPurchaseButton.onClick.AddListener(NoAdsPurchaseButtonPressed);
            vipPassPurchaseButton.onClick.AddListener(VipPassPurchaseButtonPressed);
            
            amuletPurchaseButton.onClick.AddListener(AmuletPurchaseButtonPressed);
        }

        private void PremiumShopTabPressed()
        {
            OnPremiumShopTabPressed?.Invoke();
        }

        private void CoinShopTabPressed()
        {
            OnCoinShopTabPressed?.Invoke();
        }

        private void CoinPurchaseButtonPressed()
        {
            OnCoinsPurchaseButtonPressed?.Invoke();
        }

        private void NoAdsPurchaseButtonPressed()
        {
            OnNoAdsPurchaseButtonPressed?.Invoke();
        }

        private void VipPassPurchaseButtonPressed()
        {
            OnVipPassButtonPressed?.Invoke();
        }

        private void AmuletPurchaseButtonPressed()
        {
            OnAmuletPurchaseButtonPressed?.Invoke();
        }

        private void ShopCloseButtonPressed()
        {
            Debug.Log("Close pressed");
            OnShopCloseButtonPressed?.Invoke();
        }
    }
}

