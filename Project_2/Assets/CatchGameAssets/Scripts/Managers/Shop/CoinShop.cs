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

        private ShopManager _shopManager;

        public CoinShop(ShopManager shopManager)
        {
            _shopManager = shopManager;
            _shopManager.OnAmuletPurchaseRequested += AmuletBuyRequest;
        }

        public void AmuletBuyRequest()
        {
            ShopItemType amulet = ShopItemType.Amulet;
            OnItemBuyRequest?.Invoke(amulet);
        }
    }
}