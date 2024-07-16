using System;
using UnityEngine;
using UnityEngine.UI;

namespace Catch
{
    public class ShopManager : MonoBehaviour
    {
        public Action OnShopCloseRequest;

        [SerializeField] private GameObject shop;
        
        public CoinShop coinShop;
        public PremiumShop premiumShop;

        [SerializeField] private Button coinShopTab;
        [SerializeField] private Button premiumShopTab;

        public void OpenShop()
        {
            shop.SetActive(true);
            premiumShopTab.interactable = true;
            coinShopTab.interactable = false;
            coinShop.Show();
        }

        public void OpenPremiumShopTab()
        {
            premiumShop.Show();
            coinShop.Hide();
            premiumShopTab.interactable = false;
            coinShopTab.interactable = true;
        }

        public void OpenCoinsShopTab()
        {
            coinShop.Show();
            premiumShop.Hide();
            coinShopTab.interactable = false;
            premiumShopTab.interactable = true;
        }
        
        public void ShopCloseRequest()
        {
            OnShopCloseRequest?.Invoke();
        }

        public void CloseShop()
        {
            shop.SetActive(false);
        }


    }
}

