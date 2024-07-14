using System;
using UnityEngine;
using UnityEngine.Purchasing;

namespace Catch
{
    public class PremiumShop : MonoBehaviour, IStoreListener
    {
        public Action OnCoinsPurchased;
        public Action OnNoAdsPurchased;
        public Action OnVipPassPurchased;
        
        [SerializeField] private GameObject premiumShopPanel;

        public void Show()
        {
            premiumShopPanel.SetActive(true);
        }

        public void Hide()
        {
            premiumShopPanel.SetActive(false);
        }

        public void SendCoinPurchaseConfirmation(Product product)
        {
            OnCoinsPurchased?.Invoke();
        }

        public void SendNoAdsPurchaseConfirmation()
        {
            OnNoAdsPurchased?.Invoke();
        }

        public void SendVipPassPurchaseConfirmation()
        {
            OnVipPassPurchased?.Invoke();
        }

        public void OnInitializeFailed(InitializationFailureReason error)
        {
            throw new NotImplementedException();
        }

        public void OnInitializeFailed(InitializationFailureReason error, string message)
        {
            throw new NotImplementedException();
        }

        public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs purchaseEvent)
        {
            throw new NotImplementedException();
        }

        public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
        {
            throw new NotImplementedException();
        }

        public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
        {
            throw new NotImplementedException();
        }
    }
}