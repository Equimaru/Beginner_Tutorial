using System;
using TMPro;
using UnityEngine;

namespace Catch
{
    public class ShopManager : MonoBehaviour
    {
        public Action OnAmuletBuyRequest;
        public Action OnCloseShopPanelRequest;

        [SerializeField] private GameObject shopPanel;
        [SerializeField] private TextMeshProUGUI moneyAmountText;

        public void BuyAmuletRequest()
        {
            OnAmuletBuyRequest?.Invoke();
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

        public void SetMoneyAmountText(int moneyAmount)
        {
            moneyAmountText.text = "You have " + moneyAmount + " coins";
        }
    }
}

