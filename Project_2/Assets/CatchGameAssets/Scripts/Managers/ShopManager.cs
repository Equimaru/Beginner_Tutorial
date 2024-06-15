using System;
using UnityEngine;

namespace Catch
{
    public class ShopManager : MonoBehaviour
    {
        public Action OnAmuletBuyAttemptRequest;
        public Action OnCloseShopPanelRequest;

        [SerializeField] private GameObject shopPanel;

        public void BuyAmuletRequest()
        {
            OnAmuletBuyAttemptRequest?.Invoke();
        }

        public void CloseShopPanelRequest()
        {
            OnCloseShopPanelRequest?.Invoke();
        }

        public void OpenShop()
        {
            shopPanel.SetActive(true);
        }

        public void CloseShop()
        {
            shopPanel.SetActive(false);
        }
    }
}

