using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Catch
{
    public class CoinShop
    {
        public Action<ShopItemType> OnItemBuyRequest;

        private ShopManagerView _shopManagerView;

        private GameObject coinShopPanel;

        private Button amuletBuyButton;

        private TextMeshProUGUI currentCoinsAmountText;

        public CoinShop(ShopManagerView shopManagerView)
        {
            _shopManagerView = shopManagerView;
            coinShopPanel = _shopManagerView.coinShopPanel;
            amuletBuyButton = _shopManagerView.amuletPurchaseButton;
            currentCoinsAmountText = _shopManagerView.currentCoinsAmountText;
        }


        public void Show()
        {
            coinShopPanel.SetActive(true);
        }

        public void Hide()
        {
            coinShopPanel.SetActive(false);
        }

        public void AmuletBuyRequest()
        {
            ShopItemType amulet = ShopItemType.Amulet;
            OnItemBuyRequest?.Invoke(amulet);
        }

        public void RefreshShopPanel(int moneyAmount, bool hasAmulet)
        {
            amuletBuyButton.interactable = !hasAmulet;
            currentCoinsAmountText.text = "You have " + moneyAmount;
        }
    }
}