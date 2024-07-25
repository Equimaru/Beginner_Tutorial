using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

        public GameObject premiumShopPanel;
        public GameObject coinShopPanel;
        
        public CoinShop coinShop;
        public PremiumShop premiumShop;

        [Header("Premium panel")] 
        public Button coinsPurchaseButton;
        public Button noAdsPurchaseButton;
        public Button vipPassPurchaseButton;

        [Header("Coins panel")] 
        public Button amuletPurchaseButton; // Switch to item1,item2 e.t.c.

        public TextMeshProUGUI currentCoinsAmountText;
        
        private void Awake()
        {
            premiumShopTab.onClick.AddListener(PremiumShopTabPressed);
            coinShopTab.onClick.AddListener(CoinShopTabPressed);
            
            
            
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
            OnShopCloseButtonPressed?.Invoke();
        }
    }
}

