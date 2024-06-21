using System;
using TMPro;
using UnityEngine;

namespace Catch
{
    public class ShopManager : MonoBehaviour
    {
        public Action<ShopItemType> OnItemBuyRequest;
        public Action OnCloseShopPanelRequest;

        [SerializeField] private GameObject shopPanel;
        [SerializeField] private TextMeshProUGUI moneyAmountText;

        public void AmuletBuyRequest()
        {
            ShopItemType amulet = ShopItemType.Amulet;
            OnItemBuyRequest?.Invoke(amulet);
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

