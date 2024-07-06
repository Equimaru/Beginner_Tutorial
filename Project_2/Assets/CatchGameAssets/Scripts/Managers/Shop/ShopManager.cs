using System;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Catch
{
    public class ShopManager : MonoBehaviour
    {
        public Action<ShopItemType> OnItemBuyRequest;

        [SerializeField] private GameObject shopPanel;
        [SerializeField] private Button amuletBuyButton;
        [SerializeField] private TextMeshProUGUI moneyAmountText;

        public void AmuletBuyRequest()
        {
            ShopItemType amulet = ShopItemType.Amulet;
            OnItemBuyRequest?.Invoke(amulet);
        }

        public void CloseShop()
        {
            if (_shopVisitCompletionSource != null)
            {
                _shopVisitCompletionSource.SetResult(true);
            }
        }

        private TaskCompletionSource<bool> _shopVisitCompletionSource;
        
        public async Task VisitShop()
        {
            _shopVisitCompletionSource = new TaskCompletionSource<bool>();
            shopPanel.SetActive(true);
            await _shopVisitCompletionSource.Task;
            shopPanel.SetActive(false);
        }

        public void RefreshShopPanel(int moneyAmount, bool hasAmulet)
        {
             amuletBuyButton.interactable = !hasAmulet;
            moneyAmountText.text = "You have " + moneyAmount + " coins";
        }
    }
}

