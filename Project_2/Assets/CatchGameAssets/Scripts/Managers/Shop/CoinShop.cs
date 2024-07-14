using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Catch
{
    public class CoinShop : MonoBehaviour
    {
        public Action<ShopItemType> OnItemBuyRequest;
        
        [SerializeField] private GameObject coinShopPanel;
        [SerializeField] private Button amuletBuyButton;
        [SerializeField] private TextMeshProUGUI currentCoinsAmountText;

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