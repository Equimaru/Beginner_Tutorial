using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Catch
{
    public class ShopManager : MonoBehaviour
    {
        public Action<ShopItemType> OnItemBuyRequest;
        public Action OnCloseShopPanelRequest;

        [SerializeField] private GameObject shopPanel;
        [SerializeField] private Button amuletBuyButton;
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

        public void RefreshShopPanel(int moneyAmount, bool hasAmulet)
        {
            amuletBuyButton.interactable = !hasAmulet;
            moneyAmountText.text = "You have " + moneyAmount + " coins";
        }
    }
}

