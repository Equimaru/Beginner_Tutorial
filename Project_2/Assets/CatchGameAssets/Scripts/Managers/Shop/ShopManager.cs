using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Catch
{
    public class ShopManager : IInitializable
    {
        public Action CoinsPurchaseRequest;
        public Action NoAdsPurchaseRequest;
        public Action VipPassPurchaseRequest;
        public Action AmuletPurchaseRequest;
        public Action ShopCloseRequest;
        
        private ShopManagerView _shopManagerView;
        public GameObject premiumShopPanel;
        public GameObject coinShopPanel;
        public TextMeshProUGUI currentCoinsAmountText;
        public Button amuletBuyButton;

        public ShopManager(ShopManagerView shopManagerView)
        {
            _shopManagerView = shopManagerView;
            premiumShopPanel = _shopManagerView.premiumShopPanel;
            coinShopPanel = _shopManagerView.coinShopPanel;
            currentCoinsAmountText = _shopManagerView.currentCoinsAmountText;
            amuletBuyButton = _shopManagerView.amuletPurchaseButton;
        }


        public void Initialize()
        {
            _shopManagerView.OnCoinShopTabPressed += OpenCoinsShopTab;
            _shopManagerView.OnPremiumShopTabPressed += OpenPremiumShopTab;
            
            _shopManagerView.OnCoinsPurchaseButtonPressed += RequestCoinsPurchase;
            _shopManagerView.OnNoAdsPurchaseButtonPressed += RequestNoAdsPurchase;
            _shopManagerView.OnVipPassPurchaseButtonPressed += RequestVipPassPurchase;

            _shopManagerView.OnAmuletPurchaseButtonPressed += RequestAmuletPurchase;

            _shopManagerView.OnShopCloseButtonPressed += RequestShopClose;
        }

        public void OpenShop()
        {
            _shopManagerView.gameObject.SetActive(true);
            _shopManagerView.premiumShopTab.interactable = true;
            _shopManagerView.coinShopTab.interactable = false;
            coinShopPanel.SetActive(true);
            premiumShopPanel.SetActive(false);
        }

        #region Requests to Premium Shop

        private void RequestCoinsPurchase()
        {
            CoinsPurchaseRequest?.Invoke();
        }

        private void RequestNoAdsPurchase()
        {
            NoAdsPurchaseRequest?.Invoke();
        }

        private void RequestVipPassPurchase()
        {
            VipPassPurchaseRequest?.Invoke();
        }

        #endregion

        #region Requests to Coin Shop

        private void RequestAmuletPurchase()
        {
            AmuletPurchaseRequest?.Invoke();
        }

        #endregion
        

        public void OpenPremiumShopTab()
        {
            premiumShopPanel.SetActive(true);
            coinShopPanel.SetActive(false);
            _shopManagerView.premiumShopTab.interactable = false;
            _shopManagerView.coinShopTab.interactable = true;
        }

        public void OpenCoinsShopTab()
        {
            coinShopPanel.SetActive(true);
            premiumShopPanel.SetActive(false);
            _shopManagerView.coinShopTab.interactable = false;
            _shopManagerView.premiumShopTab.interactable = true;
        }

        public void RequestShopClose()
        {
            Debug.Log("Request");
            ShopCloseRequest?.Invoke();
        }

        public void CloseShop()
        {
            _shopManagerView.gameObject.SetActive(false);
            Debug.Log("Close shop");
        }
        
        
        public void RefreshShopPanel(int moneyAmount, bool hasAmulet)
        {
            amuletBuyButton.interactable = !hasAmulet;
            currentCoinsAmountText.text = "You have " + moneyAmount;
        }
        
    }
}

