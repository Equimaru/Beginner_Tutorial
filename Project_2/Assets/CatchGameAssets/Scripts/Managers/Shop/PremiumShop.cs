using System;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.Purchasing.Extension;
using Zenject;

namespace Catch
{
    [Serializable]
    public class ConsumableItem
    {
        public string name;
        public string id;
        public string description;
        public float price;
    }

    [Serializable]
    public class NonConsumableItem
    {
        public string name;
        public string id;
        public string description;
        public float price;
    }

    [Serializable]
    public class SubscriptionItem
    {
        public string name;
        public string id;
        public string description;
        public float price;
        public int duration; //In days
    }
    
    public class PremiumShop : IDetailedStoreListener, IInitializable
    {
        public Action OnCoinsPurchased;
        public Action OnNoAdsPurchased;
        public Action OnNoAdsIsActive;
        public Action OnVipPassPurchased;

        private ShopManagerView _shopManagerView;
        private GameObject _premiumShopPanel;

        private IStoreController _storeController;

        private ConsumableItem _consItem;
        private NonConsumableItem _nConsItem;
        private SubscriptionItem _subItem;

        [Inject]
        public void Inject(ShopManagerView shopManagerView, ConsumableItem consItem, NonConsumableItem nConsItem,
            SubscriptionItem subItem)
        {
            _consItem = consItem;
            _nConsItem = nConsItem;
            _subItem = subItem;
            _shopManagerView = shopManagerView;
            _premiumShopPanel = _shopManagerView.premiumShopPanel;
        }

        public void Initialize()
        {
            _shopManagerView.OnCoinsPurchaseButtonPressed += PurchaseCoins;
            _shopManagerView.OnNoAdsPurchaseButtonPressed += PurchaseNoAds;
            _shopManagerView.OnVipPassButtonPressed += PurchaseSubscription;
            Debug.Log("Initialize");
            
            SetupBuilder();
        }

        private void SetupBuilder()
        {
            var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

            builder.AddProduct(_consItem.id, ProductType.Consumable);
            builder.AddProduct(_nConsItem.id, ProductType.NonConsumable);
            builder.AddProduct(_subItem.id, ProductType.Subscription);
            
            UnityPurchasing.Initialize(this, builder);
        }

        private void PurchaseCoins()
        {
            _storeController.InitiatePurchase(_consItem.id);
        }

        private void PurchaseNoAds()
        {
            _storeController.InitiatePurchase(_nConsItem.id);
        }

        private void PurchaseSubscription()
        {
            _storeController.InitiatePurchase(_subItem.id);
        }

        private void CheckNonConsumable(string id)
        {
            if (_storeController != null)
            {
                var product = _storeController.products.WithID(id);
                
                if (product == null) return;
                
                if (product.hasReceipt)
                {
                    Debug.Log("NoAds is active");
                    OnNoAdsIsActive?.Invoke();
                }
                else
                {
                    Debug.Log("NoAds isn't active");
                }
            }
        }

        private void CheckSubscription(string id)
        {
            var subProduct = _storeController.products.WithID(_subItem.id);
            if (subProduct != null)
            {
                try
                {
                    if (subProduct.hasReceipt)
                    {
                        var subManager = new SubscriptionManager(subProduct, null);
                        var info = subManager.getSubscriptionInfo();
                        Debug.Log(info.getExpireDate());

                        if (info.isSubscribed() == Result.True)
                        {
                            Debug.Log("Subscription is active");
                            //Activate Vip-Pass
                        }
                        else
                        {
                            Debug.Log("Subscription is not active");
                            //Deactivate Vip-Pass
                        }
                    }
                    else
                    {
                        Debug.Log("Receipt not found");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    Debug.Log("Subscription check doesn't work in UE");
                }
            }
            else
            {
                Debug.Log("Product not found");
            }
        }

        public void Show()
        {
            _premiumShopPanel.SetActive(true);
        }

        public void Hide()
        {
            _premiumShopPanel.SetActive(false);
        }

        #region IDetailedStoreListener methods

        public void OnInitializeFailed(InitializationFailureReason error)
        {
            Debug.Log("Initialization failed");
        }

        public void OnInitializeFailed(InitializationFailureReason error, string message)
        {
            Debug.Log("Initialization failed + " + message);
        }

        public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs purchaseEvent)
        {
            var product = purchaseEvent.purchasedProduct;
            
            Debug.Log("Purchase complete + " + product.definition.id);

            if (product.definition.id == _consItem.id)
            {
                OnCoinsPurchased?.Invoke();
            }
            else if (product.definition.id == _nConsItem.id)
            {
                OnNoAdsPurchased?.Invoke();
            }
            else if (product.definition.id == _subItem.id)
            {
                OnVipPassPurchased?.Invoke();
            }
            
            return PurchaseProcessingResult.Complete;
        }

        public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
        {
            Debug.Log("Purchase failed + reason");
        }

        public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
        {
            _storeController = controller;
            Debug.Log("IAP initialized");
            CheckNonConsumable(_nConsItem.id);
            CheckSubscription(_subItem.id);
        }

        public void OnPurchaseFailed(Product product, PurchaseFailureDescription failureDescription)
        {
            Debug.Log("Purchase failed");
        }

        #endregion
    }
}