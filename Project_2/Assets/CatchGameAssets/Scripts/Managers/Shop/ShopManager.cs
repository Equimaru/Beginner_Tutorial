using System;
using UnityEngine;
using Zenject;

namespace Catch
{
    public class ShopManager
    {
        public Action OnShopCloseRequest;
        
        [Inject] ShopManagerView _shopManagerView;
        [Inject] public PremiumShop premiumShop;
        [Inject] public CoinShop coinShop;

        [Inject]
        private void Inject(ShopManagerView shopManagerView)
        {
            Debug.Log("ShopManager created");
            _shopManagerView = shopManagerView;
            
            _shopManagerView.OnCoinShopTabPressed += OpenCoinsShopTab;
            _shopManagerView.OnPremiumShopTabPressed += OpenPremiumShopTab;

            _shopManagerView.OnShopCloseButtonPressed += ShopCloseRequest;
        }
        
        
        public void OpenShop()
        {
            _shopManagerView.gameObject.SetActive(true);
            _shopManagerView.premiumShopTab.interactable = true;
            _shopManagerView.coinShopTab.interactable = false;
            _shopManagerView.coinShop.Show();
        }

        public void OpenPremiumShopTab()
        {
            _shopManagerView.premiumShop.Show();
            _shopManagerView.coinShop.Hide();
            _shopManagerView.premiumShopTab.interactable = false;
            _shopManagerView.coinShopTab.interactable = true;
        }

        public void OpenCoinsShopTab()
        {
            _shopManagerView.coinShop.Show();
            _shopManagerView.premiumShop.Hide();
            _shopManagerView.coinShopTab.interactable = false;
            _shopManagerView.premiumShopTab.interactable = true;
        }
        
        public void ShopCloseRequest()
        {
            OnShopCloseRequest?.Invoke();
        }

        public void CloseShop()
        {
            _shopManagerView.gameObject.SetActive(false);
            Debug.Log("Close shop");
        }
    }
}

