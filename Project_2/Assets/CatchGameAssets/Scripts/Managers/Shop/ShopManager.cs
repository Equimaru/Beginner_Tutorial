using System;
using UnityEngine;
using Zenject;

namespace Catch
{
    public class ShopManager : IInitializable
    {
        public Action OnShopCloseRequest;
        
        private ShopManagerView _shopManagerView;
        public PremiumShop premiumShop;
        public CoinShop coinShop;

        public ShopManager(ShopManagerView shopManagerView, PremiumShop premiumShop, CoinShop coinShop)
        {
            _shopManagerView = shopManagerView;
            this.premiumShop = premiumShop;
            this.coinShop = coinShop;
        }


        public void Initialize()
        {
            Debug.Log("Init");
            _shopManagerView.OnCoinShopTabPressed += OpenCoinsShopTab;
            _shopManagerView.OnPremiumShopTabPressed += OpenPremiumShopTab;

            _shopManagerView.OnShopCloseButtonPressed += ShopCloseRequest;
        }

        public void OpenShop()
        {
            _shopManagerView.gameObject.SetActive(true);
            _shopManagerView.premiumShopTab.interactable = true;
            _shopManagerView.coinShopTab.interactable = false;
            coinShop.Show();
        }

        public void OpenPremiumShopTab()
        {
            premiumShop.Show();
            coinShop.Hide();
            _shopManagerView.premiumShopTab.interactable = false;
            _shopManagerView.coinShopTab.interactable = true;
        }

        public void OpenCoinsShopTab()
        {
            coinShop.Show();
            premiumShop.Hide();
            _shopManagerView.coinShopTab.interactable = false;
            _shopManagerView.premiumShopTab.interactable = true;
        }

        public void ShopCloseRequest()
        {
            Debug.Log("Request");
            OnShopCloseRequest?.Invoke();
        }

        public void CloseShop()
        {
            _shopManagerView.gameObject.SetActive(false);
            Debug.Log("Close shop");
        }
    }
}

